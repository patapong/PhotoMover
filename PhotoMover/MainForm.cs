using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace PhotoMover
{
    public partial class MainForm : Form
    {
        private List<JobUnit> jobs;
        public MainForm()
        {
            InitializeComponent();
            listView1.SetDoubleBuffered(true);
            srcIdx = new Dictionary<string, int>();
            initStatus();
            btnStop.Visible = false;
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

        private void MovePhoto(BackgroundWorker worker, DoWorkEventArgs e)
        {
            string[] strArray;
            Config cfg = Program.AppConfig;
            string src = cfg.SourceBasePath;
            string dest = cfg.TargetBasePath;
            if (cfg.Recursive)
            {
                strArray = getFiles(src, cfg.SourceFileFilter, SearchOption.AllDirectories);
                //strArray = getFiles(src, "*.jpg|*.mov|*.avi", SearchOption.AllDirectories);
            }
            else
            {
                strArray = getFiles(src, cfg.SourceFileFilter, SearchOption.TopDirectoryOnly);
            }
            _total = strArray.Length;
            UpdateStatusBar(tssTotal, Resources.str_total + _total.ToString());
            //string folderStructure = (string)argument[3];
            List<JobUnit> jobs = strArray.Select(s => new JobUnit(s)).ToList();
            foreach (var job in jobs)
            {
                _current++;
                UpdateStatusBar(tssCurrent, Resources.str_current + _current.ToString());
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                if (cfg.isPreviewOnly)
                    job.RenamePreview();
                else
                    job.Process();

                UpdateState(job);
                switch (job.Status)
                {
                    case JobStatus.Error:
                        _error++;
                        UpdateStatusBar(tssError, Resources.str_error + _error);
                        break;
                    case JobStatus.Skipped:
                        _skipped++;
                        UpdateStatusBar(tssSkipped, Resources.str_skip + _skipped);
                        break;
                    case JobStatus.Rename_Copied:
                    case JobStatus.Rename_Moved:
                        _renamed++;
                        UpdateStatusBar(tssRenamed, Resources.str_rename + _renamed);
                        break;
                    case JobStatus.Copied:
                    case JobStatus.Moved:
                    default:
                        break;
                }
            }
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            this.fbd.SelectedPath = this.cbSrc.Text;
            this.fbd.Description = Resources.tip_pleaseSelectSourceFolder;
            this.fbd.ShowDialog();
            if (this.fbd.SelectedPath != "")
            {
                this.cbSrc.Text = this.fbd.SelectedPath;
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            this.fbd.SelectedPath = this.cbDest.Text;
            this.fbd.Description = Resources.tip_pleaseSelectDestinationFolder;
            this.fbd.ShowDialog();
            if (this.fbd.SelectedPath != "")
            {
                this.cbDest.Text = this.fbd.SelectedPath;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Program.AppConfig.isPreviewOnly = false;
            trigger_bgw();
        }
        private void btPreview_Click(object sender, EventArgs e)
        {
            Program.AppConfig.isPreviewOnly = true;
            trigger_bgw();
        }
        private void initStatus()
        {
            _total = 0;
            tssTotal.Text = Resources.str_total + _total.ToString();
            _current = 0;
            tssCurrent.Text = Resources.str_current + _current.ToString();
            _skipped = 0;
            tssSkipped.Text = Resources.str_skip + _skipped.ToString();
            _renamed = 0;
            tssRenamed.Text = Resources.str_rename + _renamed.ToString();
            _error = 0;
            tssError.Text = Resources.str_error + _error.ToString();
            ResetState();
        }

        private void trigger_bgw()
        {
            if (!cbSrc.Text.EndsWith(@"\"))
            {
                cbSrc.Text = cbSrc.Text + @"\";
            }
            if (!cbDest.Text.EndsWith(@"\"))
            {
                cbDest.Text = cbDest.Text + @"\";
            }

            if (!Directory.Exists(cbSrc.Text))
            {
                MessageBox.Show(Resources.msg_srcNotExist + "\n\n" + Resources.msg_pleaseSelectAgain, this.Text);
                cbSrc.SelectAll();
            }
            else if (!Directory.Exists(cbDest.Text))
            {
                MessageBox.Show(Resources.msg_destNotExist + "\n\n" + Resources.msg_pleaseSelectAgain, this.Text);
                cbDest.SelectAll();
            }
            else if (cbDest.Text.StartsWith(cbSrc.Text))
            {

                MessageBox.Show(Resources.msg_srcAndDestShouldNotBeSame + "\n\n" + Resources.msg_pleaseSelectAgain, this.Text);
                cbDest.SelectAll();
            }
            else
            {
                Config cfg = Program.AppConfig;
                cfg.SourceFileFilter = txtSrcFilter.Text.Trim();
                cfg.SourceBasePath = cbSrc.Text;
                cfg.TargetBasePath = cbDest.Text;
                cfg.DeleteEmptySrcFolder = chkEmpty.Checked;
                cfg.Recursive = chkSub.Checked;
                cfg.FolderStructure = cbTreeType.Text;
                cfg.DeleteSourceFile = rbtMove.Checked;
                cfg.RenameFiles = cbRenameFiles.Checked;
                cfg.RenameFileFilter = txtRenameFilter.Text;
                cfg.RenameFileTemplate = txtRenameTemplate.Text;
                cfg.TargetRule = rbtSkip.Checked ? RuleForTargetExists.skip : rbtReplace.Checked ? RuleForTargetExists.overwrite : RuleForTargetExists.rename;
                jobs = new List<JobUnit>();
                initStatus();
                //object[] argument = new object[] { cbSrc.Text, cbDest.Text, chkSub.Checked, cbTreeType.Text };
                this.bgw.RunWorkerAsync(cfg);
                btnOk.Enabled = false;
                btPreview.Enabled = false;
                btnStop.Visible = true;
            }
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
                MessageBox.Show(Resources.msg_processAborted);
            }
            else
            {
                //MessageBox.Show("Finished!", "Photo Mover", MessageBoxButtons.OK, MessageBoxIcon.Information);
                msgShower(Resources.msg_finished);
            }
            btnOk.Enabled = true;
            btPreview.Enabled = true;
            btnStop.Visible = false;
        }

        static void msgShower(string msg)
        {
            MessageBox.Show(msg, "PhotoMover");
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
        public void UpdateState(JobUnit job)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new MethodInvoker(
                    delegate() { UpdateState(job); }));
            }
            else
            {
                if (srcIdx.ContainsKey(job.SourcePath))
                {
                    int idx = srcIdx[job.SourcePath];
                    this.listView1.Items[idx].SubItems[1].Text = job.CalculatedTargetPath;
                    this.listView1.Items[idx].SubItems[2].Text = job.Status.ToString();
                    this.listView1.Items[idx].SubItems[3].Text = job.StatusLog;
                }
                else
                {
                    srcIdx.Add(job.SourcePath, -1);
                    ListViewItem lvi = this.listView1.Items.Add(job.SourcePath);
                    lvi.Tag = job;
                    srcIdx[job.SourcePath] = lvi.Index;
                    lvi.SubItems.Add(job.CalculatedTargetPath);
                    lvi.SubItems.Add(job.Status.ToString());
                    lvi.SubItems.Add(job.StatusLog);
                }

                if (Program.AppConfig.ShowList)
                {
                    //scroll to end
                    int visibleItems = listView1.ClientSize.Height / listView1.Items[0].Bounds.Height;
                    if (visibleItems > 1)
                        listView1.TopItem = listView1.Items[Math.Max(listView1.Items.Count - visibleItems + 1, 0)];
                }
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
            Program.AppConfig.ShowList = listView1.Visible;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            var detailForm = new JobDetailsForm((JobUnit)listView1.SelectedItems[0].Tag);
            detailForm.ShowDialog(this);
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            var cfg = Program.AppConfig;
            
            if (string.IsNullOrEmpty(cfg.SourceFileFilter))
            {
                cfg.SourceFileFilter = "*.*";
            }
            txtSrcFilter.Text = cfg.SourceFileFilter;
            setCombo(cfg.HistorySourcePathes, cbSrc);
            chkSub.Checked = cfg.Recursive;
            chkEmpty.Checked = cfg.DeleteEmptySrcFolder;
            setCombo(cfg.HistoryTargetPathes, cbDest);
            setCombo(cfg.HistoryFolderStructures, cbTreeType);
            if(cfg.TargetRule == RuleForTargetExists.skip)
                rbtSkip.Checked = true;
            else if(cfg.TargetRule == RuleForTargetExists.overwrite)
                rbtReplace.Checked = true;
            else
                rbtRename.Checked = true;
            
            //
            if(cfg.DeleteSourceFile)
                rbtMove.Checked = true;
            else
                rbtCopy.Checked = true;

            cbRenameFiles.Checked = cfg.RenameFiles;
            txtRenameFilter.Text = cfg.RenameFileFilter;
            txtRenameTemplate.Text = cfg.RenameFileTemplate;
            txtRenameFilter.Enabled = cfg.RenameFiles;
            txtRenameTemplate.Enabled = cfg.RenameFiles;

            if (!Program.AppConfig.ShowList)
            {
                listView1.Visible = false;
                Height = Height - listView1.Height;
            }
        }
        private void setCombo(List<string> sList, ComboBox cb)
        {
            if (sList != null && sList.Count > 0)
            {                
                cb.Text = sList[0];
                cb.Items.Clear();
                foreach (var s in sList)
                {
                    if (!cb.Items.Contains(s))
                        cb.Items.Add(s);
                }
            }
        }
        private List<string> saveCombo(ComboBox cb)
        {
            var sList = new List<string>();
            sList.Add(cb.Text);
            foreach (object o in cb.Items)
            {
                sList.Add(o.ToString());
            }
            return sList;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            var cfg = Program.AppConfig;
            cfg.SourceFileFilter = txtSrcFilter.Text;
            cfg.RenameFiles = cbRenameFiles.Checked;
            cfg.RenameFileFilter = txtRenameFilter.Text;
            cfg.RenameFileTemplate = txtRenameTemplate.Text;
            cfg.HistorySourcePathes = saveCombo(cbSrc);
            cfg.HistoryTargetPathes = saveCombo(cbDest);
            cfg.HistoryFolderStructures = saveCombo(cbTreeType);
            cfg.Recursive = chkSub.Checked;
            cfg.DeleteEmptySrcFolder = chkEmpty.Checked;
            
            if (rbtSkip.Checked) cfg.TargetRule = RuleForTargetExists.skip;
            else if (rbtReplace.Checked) cfg.TargetRule = RuleForTargetExists.overwrite;
            else cfg.TargetRule = RuleForTargetExists.rename;
            
            if (rbtCopy.Checked) cfg.DeleteSourceFile = false;
            else cfg.DeleteSourceFile = true;
            cfg.SaveConfig(Program.cfgPath);
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

        private void btPauseResume_Click(object sender, EventArgs e)
        {
        }

        private void btMgr_Click(object sender, EventArgs e)
        {
            new PluginManager().ShowDialog(this);
        }

        private void goSource_Click(object sender, EventArgs e)
        {
            ((JobUnit)listView1.SelectedItems[0].Tag).GoSrc();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((JobUnit)listView1.SelectedItems[0].Tag).Undo();
        }

        private void retryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((JobUnit)listView1.SelectedItems[0].Tag).Retry();
        }

        private void cbRenameFiles_CheckedChanged(object sender, EventArgs e)
        {
            txtRenameFilter.Enabled = cbRenameFiles.Checked;
            txtRenameTemplate.Enabled = cbRenameFiles.Checked;
        }

        private void goDest_Click(object sender, EventArgs e)
        {
            ((JobUnit)listView1.SelectedItems[0].Tag).GoDest();
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
            if(saveFileDialog1.ShowDialog().Equals(DialogResult.OK)){
                string[] result = convertList2String(listView1, 3);
                File.WriteAllLines(saveFileDialog1.FileName, result);
            }
        }
        private string[] convertList2String(ListView lv, int columnLimit)
        {
            List<string> result = new List<string>();
            int i = 1;
            bool firstCol = true;
            string line = "";
            foreach (ColumnHeader h in lv.Columns)
            {
                if (i > columnLimit)
                    break;
                if (firstCol)
                {
                    line += h.Text;
                    firstCol = false;
                }
                else
                    line += "," + h.Text;
                i++;
            }
            result.Add(line); //header line

            foreach (ListViewItem lvi in lv.Items)
            {
                firstCol = true;
                i = 1;
                line = "";
                if (lvi.Selected)
                {
                    foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                    {
                        if (i > columnLimit)
                            break;
                        if (firstCol)
                        {
                            line += lvsi.Text.Trim();
                            firstCol = false;
                        }
                        else
                            line += "," + lvsi.Text.Trim();

                        i++;
                    }
                    result.Add(line);
                }
            }
            return result.ToArray();
        }

    }
    /// <summary>
    /// Extension methods for List Views
    /// </summary>
    public static class ListViewExtensions
    {
        /// <summary>
        /// Sets the double buffered property of a list view to the specified value. code by WraithNath@stackoverflow
        /// </summary>
        /// <param name="listView">The List view</param>
        /// <param name="doubleBuffered">Double Buffered or not</param>
        public static void SetDoubleBuffered(this System.Windows.Forms.ListView listView, bool doubleBuffered = true)
        {
            listView
                .GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(listView, doubleBuffered, null);
        }
    }
}
