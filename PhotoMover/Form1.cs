using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PhotosTool.EXIF;
using System.Xml;

namespace PhotoMover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            srcIdx = new Dictionary<string, int>();
            initStatus();
            btnStop.Visible = false;
        }
        public enum STATE
        {
            todo,
            processing,
            done,
            skipped,
            error_info,
            error_copy,
            error_rename,
            error_delete
        }
        int _total, _current, _skipped, _renamed, _error;

        private int sortColumn = -1;
        private string[] getFiles(string SourceFolder, string Filter, System.IO.SearchOption searchOption)
        {
            // ArrayList will hold all file names
            ArrayList alFiles = new ArrayList();

            // Create an array of filter string
            string[] MultipleFilters = Filter.Split('|');

            // for each filter find mathing file names
            foreach (string FileFilter in MultipleFilters)
            {
                // add found file names to array list
                alFiles.AddRange(Directory.GetFiles(SourceFolder, FileFilter, searchOption));
            }

            // returns string array of relevant file names
            return (string[])alFiles.ToArray(typeof(string));
        }
        string createFolder(string parent, string subFolders)
        {
            if (subFolders.IndexOf('\\') == -1)
            {
                DirectoryInfo di;
                di = Directory.CreateDirectory(parent + subFolders);
                return di.FullName;
                //  return parent+subFolders;
            }
            else
            {
                string newParent = parent + subFolders.Substring(0, subFolders.IndexOf('\\')) + "\\";
                Directory.CreateDirectory(newParent);
                return createFolder(newParent, subFolders.Substring(subFolders.IndexOf('\\') + 1));
            }
        }

        private void MovePhoto(BackgroundWorker worker, DoWorkEventArgs e)
        {
            string[] strArray;
            object[] argument = (object[])e.Argument;
            string src = (string)argument[0];
            string dest = (string)argument[1];
            if ((bool)argument[2])
            {
                strArray = getFiles(src, "*.*", SearchOption.AllDirectories);
                //strArray = getFiles(src, "*.jpg|*.mov|*.avi", SearchOption.AllDirectories);
            }
            else
            {
                strArray = getFiles(src, "*.*", SearchOption.TopDirectoryOnly);
            }
            _total = strArray.Length;
            UpdateStatusBar(tssTotal, LangRes.str_total + _total.ToString());
            string folderStructure = (string)argument[3];
            foreach (string objFile in strArray)
            {
                _current++;
                UpdateStatusBar(tssCurrent, LangRes.str_current + _current.ToString());
                FileInfo info;
                string[] strArrayDate;
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                info = new FileInfo(objFile);
                UpdateState(info.FullName, state: STATE.processing);
                DateTime dt;
                try
                {
                    dt = FileProcessorFactory.getReader(objFile).GetDate(objFile);
                }
                catch (Exception ex)
                {
                    UpdateState(info.FullName, state: STATE.error_info);
                    _error++;
                    UpdateStatusBar(tssError, LangRes.str_error + _error);
                    continue;
                }
                strArrayDate = new string[] { dt.Year.ToString(), dt.Month.ToString().PadLeft(2, '0'), dt.Day.ToString().PadLeft(2, '0') };
                //string strYMD = strArrayDate[0] + strArrayDate[1] + strArrayDate[2];
                string folder4CurFile = folderStructure;
                folder4CurFile = folder4CurFile.Replace("yyyy", strArrayDate[0]);
                folder4CurFile = folder4CurFile.Replace("mm", strArrayDate[1]);
                folder4CurFile = folder4CurFile.Replace("dd", strArrayDate[2]);
                folder4CurFile = folder4CurFile.Replace("yy", strArrayDate[0].Substring(2));
                //string[] subFolders = folderStructure.Split('\\');
                string destDirName = createFolder(dest, folder4CurFile);

                string name = info.Name;
                if (File.Exists(destDirName + @"\" + name))
                {
                    if (this.rbtSkip.Checked)
                    {
                        _skipped++;
                        UpdateStatusBar(tssSkipped, LangRes.str_skip + _skipped.ToString());
                        UpdateState(info.FullName, state: STATE.skipped);
                        continue;
                    }
                    else if (this.rbtRename.Checked)
                    {
                        string extension = info.Extension;
                        int num = 2;
                        while (num < 1000)
                        {
                            if (!File.Exists(destDirName + @"\" + name.Replace(extension, " (" + num.ToString() + ")" + extension)))
                            {
                                destDirName = destDirName + @"\" + name.Replace(extension, " (" + num.ToString() + ")" + extension);
                                _renamed++;
                                UpdateStatusBar(tssRenamed, LangRes.str_rename + _renamed.ToString());
                                break;
                            }
                            num++;
                        }
                        if (num >= 1000)
                        {
                            //num up to 1000, rename failed
                            _error++;
                            UpdateStatusBar(tssError, LangRes.str_error + _error.ToString());
                            UpdateState(info.FullName, state: STATE.error_rename);
                            continue;
                        }
                    }
                    else // replace, so delete existing file
                    {
                        File.Delete(destDirName + @"\" + name);
                        destDirName = destDirName + @"\" + name;
                    }
                }
                else
                {
                    destDirName = destDirName + @"\" + name;
                }
                //dest direname ready, now start copy or move
                if (this.rbtMove.Checked && (objFile.Substring(0, 3) == destDirName.Substring(0, 3))) //same partition, move
                {
                    Directory.Move(objFile, destDirName);
                }
                else
                {
                    File.Copy(objFile, destDirName);
                    UpdateState(info.FullName, destDirName, STATE.done);
                    if (this.rbtMove.Checked)
                    {
                        try
                        {
                            File.Delete(objFile);
                        }
                        catch (Exception ex)
                        {
                            _error++;
                            UpdateStatusBar(tssError, LangRes.str_error + _error.ToString());
                            UpdateState(info.FullName, state: STATE.error_delete);
                        }
                    }
                }
                if (chkEmpty.Checked)
                {
                    strArray = getFiles(src, "*.*", SearchOption.AllDirectories);
                    if (strArray.Length == 0)
                        Directory.Delete(src, true);
                }
            }
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            this.fbd.SelectedPath = this.comboBox1.Text;
            this.fbd.Description = LangRes.tip_pleaseSelectSourceFolder;
            this.fbd.ShowDialog();
            if (this.fbd.SelectedPath != "")
            {
                this.comboBox1.Text = this.fbd.SelectedPath;
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            this.fbd.SelectedPath = this.comboBox2.Text;
            this.fbd.Description = LangRes.tip_pleaseSelectDestinationFolder;
            this.fbd.ShowDialog();
            if (this.fbd.SelectedPath != "")
            {
                this.comboBox2.Text = this.fbd.SelectedPath;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Text.EndsWith(@"\"))
            {
                comboBox1.Text = comboBox1.Text + @"\";
            }
            if (!comboBox2.Text.EndsWith(@"\"))
            {
                comboBox2.Text = comboBox2.Text + @"\";
            }

            if (!Directory.Exists(comboBox1.Text))
            {
                MessageBox.Show(LangRes.msg_srcNotExist + "\n\n" + LangRes.msg_pleaseSelectAgain, this.Text);
                comboBox1.SelectAll();
            }
            else if (!Directory.Exists(comboBox2.Text))
            {
                MessageBox.Show(LangRes.msg_destNotExist + "\n\n" + LangRes.msg_pleaseSelectAgain, this.Text);
                comboBox2.SelectAll();
            }
            else if (comboBox2.Text.StartsWith(comboBox1.Text))
            {

                MessageBox.Show(LangRes.msg_srcAndDestShouldNotBeSame + "\n\n" + LangRes.msg_pleaseSelectAgain, this.Text);
                comboBox2.SelectAll();
            }
            else
            {
                object[] argument = new object[] { comboBox1.Text, comboBox2.Text, chkSub.Checked, cbTreeType.Text };
                initStatus();
                this.bgw.RunWorkerAsync(argument);
                btnOk.Enabled = false;
                btnStop.Visible = true;
            }
        }

        private void initStatus()
        {
            _total = 0;
            tssTotal.Text = LangRes.str_total + _total.ToString();
            _current = 0;
            tssCurrent.Text = LangRes.str_current + _current.ToString();
            _skipped = 0;
            tssSkipped.Text = LangRes.str_skip + _skipped.ToString();
            _renamed = 0;
            tssRenamed.Text = LangRes.str_rename + _renamed.ToString();
            _error = 0;
            tssError.Text = LangRes.str_error + _error.ToString();
            ResetState();
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            this.MovePhoto(worker, e);
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show(LangRes.msg_processAborted);
            }
            else
            {
                //MessageBox.Show("Finished!", "Photo Mover", MessageBoxButtons.OK, MessageBoxIcon.Information);
                msgShower(LangRes.msg_finished);
            }
            btnOk.Enabled = true;
            btnStop.Visible = false;
        }

        static void msgShower(string msg)
        {
            MessageBox.Show(msg, "PhotoMover");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] strArrayDate = { "1999", "22", "33" };
            string folderStructure = @"yyyy\mm\yymmdd";
            folderStructure = folderStructure.Replace("yyyy", strArrayDate[0]);
            folderStructure = folderStructure.Replace("mm", strArrayDate[1]);
            folderStructure = folderStructure.Replace("dd", strArrayDate[2]);
            folderStructure = folderStructure.Replace("yy", strArrayDate[0].Substring(2));
            string destDirName = createFolder("R:\\", folderStructure);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            bgw.CancelAsync();
            btnStop.Visible = false;
        }

        public void ResetState()
        {
            this.listView1.Items.Clear();
            srcIdx.Clear();
        }
        Dictionary<string, int> srcIdx;
        public void UpdateState(string srcState, string destPath = "", STATE state = STATE.todo)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new MethodInvoker(
                    delegate() { UpdateState(srcState, destPath, state); }));
            }
            else
            {
                if (srcIdx.ContainsKey(srcState))
                {
                    int idx = srcIdx[srcState];
                    this.listView1.Items[idx].SubItems[1].Text = destPath;
                    this.listView1.Items[idx].SubItems[2].Text = state.ToString();
                }
                else
                {
                    srcIdx.Add(srcState, -1);
                    ListViewItem lvi = this.listView1.Items.Add(srcState);
                    srcIdx[srcState] = lvi.Index;
                    lvi.SubItems.Add(destPath);
                    lvi.SubItems.Add(state.ToString());
                }
                int visibleItems = listView1.ClientSize.Height / listView1.Items[0].Bounds.Height;
                if (visibleItems > 1)
                    listView1.TopItem = listView1.Items[Math.Max(listView1.Items.Count - visibleItems + 1, 0)];
            }
        }

        public void UpdateStatusBar(ToolStripStatusLabel label, string state)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new MethodInvoker(
                    delegate() { UpdateStatusBar(label, state); }));
            }
            else
            {
                label.Text = state;
            }
        }
        int listHeight = 300;
        private void panel1_Click(object sender, EventArgs e)
        {
            listView1.Visible = !listView1.Visible;
            if (listView1.Visible)
            {
                this.Height = this.Height + listHeight;
            }
            else
            {
                listHeight = listView1.Height;
                this.Height = this.Height - listHeight;
            }
            Program.ShowList = listView1.Visible;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            openExplorer(listView1.SelectedItems[0].Text);
        }
        private void openExplorer(string fn)
        {
            if (File.Exists(fn))
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select," + fn);
            }
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            setCombo(Program.SrcList, comboBox1);
            chkSub.Checked = Program.IncludeSub;
            chkEmpty.Checked = Program.DeleteEmpty;
            setCombo(Program.DestList, comboBox2);
            setCombo(Program.StructList, cbTreeType);
            ((RadioButton)groupBox1.Controls[Program.ExistTarget - 1]).Checked = true;
            ((RadioButton)groupBox2.Controls[Program.CopyOrMove - 1]).Checked = true;

            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            if (!Program.ShowList)
            {
                this.listView1.Visible = false;
                this.Height = this.Height - listView1.Height;
            }
        }
        private void setCombo(string sList, ComboBox cb)
        {
            if (!string.IsNullOrEmpty(sList))
            {
                string[] s = sList.Split(';');
                cb.Text = s[0];
                cb.Items.Clear();
                for (int i = 0; i < s.Length; i++)
                {
                    if (!(cb.Items.Contains(s[i])))
                        cb.Items.Add(s[i]);
                }
            }
        }
        private void saveCombo(out string sList, ComboBox cb)
        {
            sList = cb.Text;
            foreach (object o in cb.Items)
            {
                sList = sList + ";" + o.ToString();
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveCombo(out Program.SrcList, comboBox1);
            saveCombo(out Program.DestList, comboBox2);
            saveCombo(out Program.StructList, cbTreeType);
            if (rbtSkip.Checked) Program.ExistTarget = 3;
            else if (rbtReplace.Checked) Program.ExistTarget = 2;
            else Program.ExistTarget = 1;//rename
            if (rbtCopy.Checked) Program.CopyOrMove = 1;
            else Program.CopyOrMove = 2;
            IniFile ini = new IniFile(Program.cfgPath);
            ini.IniWriteValue("Config", "Src", Program.SrcList);
            ini.IniWriteValue("Config", "IncludeSub", chkSub.Checked.ToString());
            ini.IniWriteValue("Config", "DeleteEmpty", chkEmpty.Checked.ToString());
            ini.IniWriteValue("Config", "Dest", Program.DestList);
            ini.IniWriteValue("Config", "Struct", Program.StructList);
            ini.IniWriteValue("Config", "ExistTarget", Program.ExistTarget.ToString());
            ini.IniWriteValue("Config", "CopyOrMove", Program.CopyOrMove.ToString());
            ini.IniWriteValue("Config", "ShowList", listView1.Visible.ToString());
            ini.IniWriteValue("Config", "TimeField", Program.TimeFieldName);
        }

        private void goDest_Click(object sender, EventArgs e)
        {
            openExplorer(listView1.SelectedItems[0].SubItems[1].Text);
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                listView1.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listView1.Sorting == SortOrder.Ascending)
                    listView1.Sorting = SortOrder.Descending;
                else
                    listView1.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            listView1.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                              listView1.Sorting);
        }

        private void goSource_Click(object sender, EventArgs e)
        {
            openExplorer(listView1.SelectedItems[0].Text);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    gridMenu.Show(Cursor.Position);
                }
            } 
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if(saveFileDialog1.ShowDialog().Equals(DialogResult.OK)){
            //    saveFileDialog1.FileName
            //}
            exportList2Clipboard(listView1);
        }
        private void exportList2Clipboard(ListView lv)
        {
            string s = "";
            bool firstCol = true;
            foreach (ColumnHeader h in lv.Columns)
            {
                if (firstCol)
                {
                    s += h.Text;
                    firstCol = false;
                }
                else
                    s += "," + h.Text;
            }
            s += Environment.NewLine;

            foreach (ListViewItem lvi in lv.Items)
            {
                firstCol = true;
                if (lvi.Selected)
                {
                    foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                    {
                        if (firstCol)
                        {
                            s += lvsi.Text.Trim();
                            firstCol = false;
                        }
                        else
                            s += "," + lvsi.Text.Trim();

                    }
                    s += Environment.NewLine;
                }
            }
            Clipboard.SetText(s);
        }

    }
}
