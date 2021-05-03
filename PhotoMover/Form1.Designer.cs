namespace PhotoMover
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "src aaa",
            "aaaa",
            "a1"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "bbb",
            "bbb"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOk = new System.Windows.Forms.Button();
            this.chkSub = new System.Windows.Forms.CheckBox();
            this.cbTreeType = new System.Windows.Forms.ComboBox();
            this.btnD = new System.Windows.Forms.Button();
            this.btnS = new System.Windows.Forms.Button();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtRename = new System.Windows.Forms.RadioButton();
            this.rbtReplace = new System.Windows.Forms.RadioButton();
            this.rbtSkip = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtCopy = new System.Windows.Forms.RadioButton();
            this.rbtMove = new System.Windows.Forms.RadioButton();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssCurrent = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSkipped = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRenamed = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssError = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goSource = new System.Windows.Forms.ToolStripMenuItem();
            this.goDest = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.chkEmpty = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.gridMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(491, 214);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(88, 47);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "开始";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkSub
            // 
            this.chkSub.AutoSize = true;
            this.chkSub.Checked = true;
            this.chkSub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSub.Location = new System.Drawing.Point(193, 39);
            this.chkSub.Name = "chkSub";
            this.chkSub.Size = new System.Drawing.Size(86, 17);
            this.chkSub.TabIndex = 2;
            this.chkSub.Text = "处理子目录";
            this.chkSub.UseVisualStyleBackColor = true;
            // 
            // cbTreeType
            // 
            this.cbTreeType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTreeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbTreeType.FormattingEnabled = true;
            this.cbTreeType.Items.AddRange(new object[] {
            "yyyy\\yyyymmdd",
            "yyyy\\mmdd",
            "yyyy\\mm\\dd",
            "yyyy\\mm\\mmdd",
            "yyyy\\mm\\yyyymmdd",
            "yyyymmdd",
            "yy\\mm\\dd",
            "yy\\mmdd",
            "yyyy\\yyyy-mm\\yyyymmdd"});
            this.cbTreeType.Location = new System.Drawing.Point(87, 114);
            this.cbTreeType.Name = "cbTreeType";
            this.cbTreeType.Size = new System.Drawing.Size(578, 26);
            this.cbTreeType.TabIndex = 6;
            this.cbTreeType.Text = "yyyy\\yyyy-mm\\yyyymmdd";
            // 
            // btnD
            // 
            this.btnD.Location = new System.Drawing.Point(13, 71);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(66, 22);
            this.btnD.TabIndex = 4;
            this.btnD.Text = "目标目录";
            this.btnD.UseVisualStyleBackColor = true;
            this.btnD.Click += new System.EventHandler(this.btnD_Click);
            // 
            // btnS
            // 
            this.btnS.Location = new System.Drawing.Point(13, 11);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(66, 22);
            this.btnS.TabIndex = 0;
            this.btnS.Text = "源目录";
            this.btnS.UseVisualStyleBackColor = true;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbtRename);
            this.groupBox1.Controls.Add(this.rbtReplace);
            this.groupBox1.Controls.Add(this.rbtSkip);
            this.groupBox1.Location = new System.Drawing.Point(13, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 46);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "如果目标文件已存在";
            // 
            // rbtRename
            // 
            this.rbtRename.AutoSize = true;
            this.rbtRename.Location = new System.Drawing.Point(74, 21);
            this.rbtRename.Name = "rbtRename";
            this.rbtRename.Size = new System.Drawing.Size(49, 17);
            this.rbtRename.TabIndex = 0;
            this.rbtRename.Text = "改名";
            this.rbtRename.UseVisualStyleBackColor = true;
            // 
            // rbtReplace
            // 
            this.rbtReplace.AutoSize = true;
            this.rbtReplace.Location = new System.Drawing.Point(165, 21);
            this.rbtReplace.Name = "rbtReplace";
            this.rbtReplace.Size = new System.Drawing.Size(49, 17);
            this.rbtReplace.TabIndex = 1;
            this.rbtReplace.Text = "覆盖";
            this.rbtReplace.UseVisualStyleBackColor = true;
            // 
            // rbtSkip
            // 
            this.rbtSkip.AutoSize = true;
            this.rbtSkip.Checked = true;
            this.rbtSkip.Location = new System.Drawing.Point(249, 21);
            this.rbtSkip.Name = "rbtSkip";
            this.rbtSkip.Size = new System.Drawing.Size(49, 17);
            this.rbtSkip.TabIndex = 2;
            this.rbtSkip.TabStop = true;
            this.rbtSkip.Text = "跳过";
            this.rbtSkip.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rbtCopy);
            this.groupBox2.Controls.Add(this.rbtMove);
            this.groupBox2.Location = new System.Drawing.Point(13, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 47);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "复制方式";
            // 
            // rbtCopy
            // 
            this.rbtCopy.AutoSize = true;
            this.rbtCopy.Location = new System.Drawing.Point(74, 22);
            this.rbtCopy.Name = "rbtCopy";
            this.rbtCopy.Size = new System.Drawing.Size(49, 17);
            this.rbtCopy.TabIndex = 0;
            this.rbtCopy.Text = "复制";
            this.rbtCopy.UseVisualStyleBackColor = true;
            // 
            // rbtMove
            // 
            this.rbtMove.AutoSize = true;
            this.rbtMove.Checked = true;
            this.rbtMove.Location = new System.Drawing.Point(165, 22);
            this.rbtMove.Name = "rbtMove";
            this.rbtMove.Size = new System.Drawing.Size(49, 17);
            this.rbtMove.TabIndex = 1;
            this.rbtMove.TabStop = true;
            this.rbtMove.Text = "移动";
            this.rbtMove.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "目录结构";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssTotal,
            this.toolStripStatusLabel2,
            this.tssCurrent,
            this.toolStripStatusLabel4,
            this.tssSkipped,
            this.toolStripStatusLabel1,
            this.tssRenamed,
            this.toolStripStatusLabel5,
            this.tssError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 702);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(674, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssTotal
            // 
            this.tssTotal.Name = "tssTotal";
            this.tssTotal.Size = new System.Drawing.Size(44, 17);
            this.tssTotal.Text = "Total: 0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // tssCurrent
            // 
            this.tssCurrent.Name = "tssCurrent";
            this.tssCurrent.Size = new System.Drawing.Size(59, 17);
            this.tssCurrent.Text = "Current: 0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // tssSkipped
            // 
            this.tssSkipped.Name = "tssSkipped";
            this.tssSkipped.Size = new System.Drawing.Size(52, 17);
            this.tssSkipped.Text = "Skipped:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // tssRenamed
            // 
            this.tssRenamed.Name = "tssRenamed";
            this.tssRenamed.Size = new System.Drawing.Size(60, 17);
            this.tssRenamed.Text = "Renamed:";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel5.Text = "|";
            // 
            // tssError
            // 
            this.tssError.Name = "tssError";
            this.tssError.Size = new System.Drawing.Size(44, 17);
            this.tssError.Text = "Error: 0";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "D:\\Photos\\100EOS5D",
            "K:\\DCIM",
            "E:\\DCIM",
            "F:\\DCIM",
            "G:\\DCIM"});
            this.comboBox1.Location = new System.Drawing.Point(85, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(583, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "D:\\Trans";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Location = new System.Drawing.Point(583, 214);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(86, 47);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.YellowGreen;
            this.panel1.Location = new System.Drawing.Point(12, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 10);
            this.panel1.TabIndex = 16;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Source,
            this.Dest,
            this.Status});
            this.listView1.ContextMenuStrip = this.gridMenu;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(12, 281);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(658, 418);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // Source
            // 
            this.Source.Text = "Source";
            this.Source.Width = 248;
            // 
            // Dest
            // 
            this.Dest.Text = "Dest";
            this.Dest.Width = 128;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            // 
            // gridMenu
            // 
            this.gridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goSource,
            this.goDest,
            this.exportToolStripMenuItem});
            this.gridMenu.Name = "gridMenu";
            this.gridMenu.Size = new System.Drawing.Size(144, 70);
            // 
            // goSource
            // 
            this.goSource.Name = "goSource";
            this.goSource.Size = new System.Drawing.Size(143, 22);
            this.goSource.Text = "Go Source";
            this.goSource.Click += new System.EventHandler(this.goSource_Click);
            // 
            // goDest
            // 
            this.goDest.Name = "goDest";
            this.goDest.Size = new System.Drawing.Size(143, 22);
            this.goDest.Text = "Go Dest";
            this.goDest.Click += new System.EventHandler(this.goDest_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exportToolStripMenuItem.Text = "Export Result";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "D:\\Photos\\100EOS5D"});
            this.comboBox2.Location = new System.Drawing.Point(87, 71);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(583, 21);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.Text = "D:\\Photos\\100EOS5D";
            // 
            // chkEmpty
            // 
            this.chkEmpty.AutoSize = true;
            this.chkEmpty.Checked = true;
            this.chkEmpty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmpty.Location = new System.Drawing.Point(285, 39);
            this.chkEmpty.Name = "chkEmpty";
            this.chkEmpty.Size = new System.Drawing.Size(86, 17);
            this.chkEmpty.TabIndex = 3;
            this.chkEmpty.Text = "删除空目录";
            this.chkEmpty.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 724);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkEmpty);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbTreeType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnS);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.chkSub);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Photo Mover";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gridMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkSub;
        private System.Windows.Forms.ComboBox cbTreeType;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button btnS;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtReplace;
        private System.Windows.Forms.RadioButton rbtRename;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtMove;
        private System.Windows.Forms.RadioButton rbtCopy;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtSkip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssTotal;
        private System.Windows.Forms.ToolStripStatusLabel tssCurrent;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripStatusLabel tssSkipped;
        private System.Windows.Forms.ToolStripStatusLabel tssRenamed;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tssError;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Source;
        private System.Windows.Forms.ColumnHeader Dest;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox chkEmpty;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ContextMenuStrip gridMenu;
        private System.Windows.Forms.ToolStripMenuItem goSource;
        private System.Windows.Forms.ToolStripMenuItem goDest;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
    }
}

