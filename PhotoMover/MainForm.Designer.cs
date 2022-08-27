namespace PhotoMover
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.cbSrc = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Logs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.retryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goSource = new System.Windows.Forms.ToolStripMenuItem();
            this.goDest = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbDest = new System.Windows.Forms.ComboBox();
            this.chkEmpty = new System.Windows.Forms.CheckBox();
            this.btPauseResume = new System.Windows.Forms.Button();
            this.btMgr = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtRenameTemplate = new System.Windows.Forms.TextBox();
            this.txtRenameFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRenameFiles = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSrcFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btPreview = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.gridMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(738, 330);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 72);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "开始";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkSub
            // 
            this.chkSub.AutoSize = true;
            this.chkSub.Location = new System.Drawing.Point(290, 60);
            this.chkSub.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSub.Name = "chkSub";
            this.chkSub.Size = new System.Drawing.Size(115, 24);
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
            this.cbTreeType.Location = new System.Drawing.Point(130, 161);
            this.cbTreeType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTreeType.Name = "cbTreeType";
            this.cbTreeType.Size = new System.Drawing.Size(317, 34);
            this.cbTreeType.TabIndex = 7;
            this.cbTreeType.Text = "yyyy\\yyyy-mm\\yyyymmdd";
            // 
            // btnD
            // 
            this.btnD.Location = new System.Drawing.Point(20, 109);
            this.btnD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(99, 34);
            this.btnD.TabIndex = 5;
            this.btnD.Text = "目标目录";
            this.btnD.UseVisualStyleBackColor = true;
            this.btnD.Click += new System.EventHandler(this.btnD_Click);
            // 
            // btnS
            // 
            this.btnS.Location = new System.Drawing.Point(20, 17);
            this.btnS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(99, 34);
            this.btnS.TabIndex = 0;
            this.btnS.Text = "源目录";
            this.btnS.UseVisualStyleBackColor = true;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // bgw
            // 
            this.bgw.WorkerSupportsCancellation = true;
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
            this.groupBox1.Location = new System.Drawing.Point(20, 245);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(427, 71);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "如果目标文件已存在";
            // 
            // rbtRename
            // 
            this.rbtRename.AutoSize = true;
            this.rbtRename.Location = new System.Drawing.Point(341, 31);
            this.rbtRename.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbtRename.Name = "rbtRename";
            this.rbtRename.Size = new System.Drawing.Size(66, 24);
            this.rbtRename.TabIndex = 2;
            this.rbtRename.Text = "改名";
            this.rbtRename.UseVisualStyleBackColor = true;
            // 
            // rbtReplace
            // 
            this.rbtReplace.AutoSize = true;
            this.rbtReplace.Location = new System.Drawing.Point(128, 31);
            this.rbtReplace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbtReplace.Name = "rbtReplace";
            this.rbtReplace.Size = new System.Drawing.Size(66, 24);
            this.rbtReplace.TabIndex = 0;
            this.rbtReplace.Text = "覆盖";
            this.rbtReplace.UseVisualStyleBackColor = true;
            // 
            // rbtSkip
            // 
            this.rbtSkip.AutoSize = true;
            this.rbtSkip.Checked = true;
            this.rbtSkip.Location = new System.Drawing.Point(232, 31);
            this.rbtSkip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbtSkip.Name = "rbtSkip";
            this.rbtSkip.Size = new System.Drawing.Size(66, 24);
            this.rbtSkip.TabIndex = 1;
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
            this.groupBox2.Location = new System.Drawing.Point(20, 329);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(356, 72);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "复制方式";
            // 
            // rbtCopy
            // 
            this.rbtCopy.AutoSize = true;
            this.rbtCopy.Checked = true;
            this.rbtCopy.Location = new System.Drawing.Point(128, 33);
            this.rbtCopy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbtCopy.Name = "rbtCopy";
            this.rbtCopy.Size = new System.Drawing.Size(66, 24);
            this.rbtCopy.TabIndex = 0;
            this.rbtCopy.TabStop = true;
            this.rbtCopy.Text = "复制";
            this.rbtCopy.UseVisualStyleBackColor = true;
            // 
            // rbtMove
            // 
            this.rbtMove.AutoSize = true;
            this.rbtMove.Location = new System.Drawing.Point(232, 33);
            this.rbtMove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbtMove.Name = "rbtMove";
            this.rbtMove.Size = new System.Drawing.Size(66, 24);
            this.rbtMove.TabIndex = 1;
            this.rbtMove.Text = "移动";
            this.rbtMove.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 172);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 99;
            this.label1.Text = "目录结构";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 1029);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(878, 32);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssTotal
            // 
            this.tssTotal.Name = "tssTotal";
            this.tssTotal.Size = new System.Drawing.Size(68, 25);
            this.tssTotal.Text = "Total: 0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(16, 25);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // tssCurrent
            // 
            this.tssCurrent.Name = "tssCurrent";
            this.tssCurrent.Size = new System.Drawing.Size(89, 25);
            this.tssCurrent.Text = "Current: 0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(16, 25);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // tssSkipped
            // 
            this.tssSkipped.Name = "tssSkipped";
            this.tssSkipped.Size = new System.Drawing.Size(81, 25);
            this.tssSkipped.Text = "Skipped:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 25);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // tssRenamed
            // 
            this.tssRenamed.Name = "tssRenamed";
            this.tssRenamed.Size = new System.Drawing.Size(90, 25);
            this.tssRenamed.Text = "Renamed:";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(16, 25);
            this.toolStripStatusLabel5.Text = "|";
            // 
            // tssError
            // 
            this.tssError.Name = "tssError";
            this.tssError.Size = new System.Drawing.Size(69, 25);
            this.tssError.Text = "Error: 0";
            // 
            // cbSrc
            // 
            this.cbSrc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSrc.FormattingEnabled = true;
            this.cbSrc.Items.AddRange(new object[] {
            "E:\\DCIM",
            "F:\\DCIM",
            "G:\\DCIM"});
            this.cbSrc.Location = new System.Drawing.Point(130, 17);
            this.cbSrc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSrc.Name = "cbSrc";
            this.cbSrc.Size = new System.Drawing.Size(737, 28);
            this.cbSrc.TabIndex = 1;
            this.cbSrc.Text = "F:\\DCIM\\";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Location = new System.Drawing.Point(738, 330);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 72);
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
            this.panel1.Location = new System.Drawing.Point(18, 406);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 15);
            this.panel1.TabIndex = 15;
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
            this.Status,
            this.Logs});
            this.listView1.ContextMenuStrip = this.gridMenu;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(18, 432);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(852, 588);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // Source
            // 
            this.Source.Text = "Source";
            this.Source.Width = 300;
            // 
            // Dest
            // 
            this.Dest.Text = "Dest";
            this.Dest.Width = 300;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 120;
            // 
            // Logs
            // 
            this.Logs.Text = "Logs";
            this.Logs.Width = 250;
            // 
            // gridMenu
            // 
            this.gridMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.gridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retryToolStripMenuItem,
            this.goSource,
            this.goDest,
            this.undoToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.gridMenu.Name = "gridMenu";
            this.gridMenu.Size = new System.Drawing.Size(188, 164);
            // 
            // retryToolStripMenuItem
            // 
            this.retryToolStripMenuItem.Name = "retryToolStripMenuItem";
            this.retryToolStripMenuItem.Size = new System.Drawing.Size(187, 32);
            this.retryToolStripMenuItem.Text = "Retry";
            this.retryToolStripMenuItem.Click += new System.EventHandler(this.retryToolStripMenuItem_Click);
            // 
            // goSource
            // 
            this.goSource.Name = "goSource";
            this.goSource.Size = new System.Drawing.Size(187, 32);
            this.goSource.Text = "Go Source";
            this.goSource.Click += new System.EventHandler(this.goSource_Click);
            // 
            // goDest
            // 
            this.goDest.Name = "goDest";
            this.goDest.Size = new System.Drawing.Size(187, 32);
            this.goDest.Text = "Go Dest";
            this.goDest.Click += new System.EventHandler(this.goDest_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(187, 32);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(187, 32);
            this.exportToolStripMenuItem.Text = "Export Result";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // cbDest
            // 
            this.cbDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDest.FormattingEnabled = true;
            this.cbDest.Items.AddRange(new object[] {
            "D:\\Photos\\"});
            this.cbDest.Location = new System.Drawing.Point(130, 111);
            this.cbDest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDest.Name = "cbDest";
            this.cbDest.Size = new System.Drawing.Size(737, 28);
            this.cbDest.TabIndex = 6;
            this.cbDest.Text = "D:\\Photos\\";
            // 
            // chkEmpty
            // 
            this.chkEmpty.AutoSize = true;
            this.chkEmpty.Location = new System.Drawing.Point(428, 60);
            this.chkEmpty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkEmpty.Name = "chkEmpty";
            this.chkEmpty.Size = new System.Drawing.Size(115, 24);
            this.chkEmpty.TabIndex = 3;
            this.chkEmpty.Text = "删除空目录";
            this.chkEmpty.UseVisualStyleBackColor = true;
            // 
            // btPauseResume
            // 
            this.btPauseResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPauseResume.Location = new System.Drawing.Point(602, 329);
            this.btPauseResume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btPauseResume.Name = "btPauseResume";
            this.btPauseResume.Size = new System.Drawing.Size(120, 72);
            this.btPauseResume.TabIndex = 17;
            this.btPauseResume.Text = "暂停";
            this.btPauseResume.UseVisualStyleBackColor = true;
            this.btPauseResume.Visible = false;
            this.btPauseResume.Click += new System.EventHandler(this.btPauseResume_Click);
            // 
            // btMgr
            // 
            this.btMgr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMgr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btMgr.Location = new System.Drawing.Point(383, 338);
            this.btMgr.Name = "btMgr";
            this.btMgr.Size = new System.Drawing.Size(64, 58);
            this.btMgr.TabIndex = 11;
            this.btMgr.Text = "⚙";
            this.btMgr.UseVisualStyleBackColor = true;
            this.btMgr.Click += new System.EventHandler(this.btMgr_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "CSV files|*.csv|All files|*.*";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtRenameTemplate);
            this.panel2.Controls.Add(this.txtRenameFilter);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbRenameFiles);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(469, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 156);
            this.panel2.TabIndex = 10;
            // 
            // txtRenameTemplate
            // 
            this.txtRenameTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRenameTemplate.Location = new System.Drawing.Point(132, 102);
            this.txtRenameTemplate.Name = "txtRenameTemplate";
            this.txtRenameTemplate.Size = new System.Drawing.Size(244, 26);
            this.txtRenameTemplate.TabIndex = 2;
            this.txtRenameTemplate.Text = "N-yyyy-mm-dd-hh-ww-ss#";
            // 
            // txtRenameFilter
            // 
            this.txtRenameFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRenameFilter.Location = new System.Drawing.Point(132, 52);
            this.txtRenameFilter.Name = "txtRenameFilter";
            this.txtRenameFilter.Size = new System.Drawing.Size(244, 26);
            this.txtRenameFilter.TabIndex = 1;
            this.txtRenameFilter.Text = "C*.jpg|A*.mov";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 99;
            this.label3.Text = "改名模板";
            // 
            // cbRenameFiles
            // 
            this.cbRenameFiles.AutoSize = true;
            this.cbRenameFiles.Location = new System.Drawing.Point(13, 7);
            this.cbRenameFiles.Name = "cbRenameFiles";
            this.cbRenameFiles.Size = new System.Drawing.Size(115, 24);
            this.cbRenameFiles.TabIndex = 0;
            this.cbRenameFiles.Text = "文件重命名";
            this.cbRenameFiles.UseVisualStyleBackColor = true;
            this.cbRenameFiles.CheckedChanged += new System.EventHandler(this.cbRenameFiles_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 99;
            this.label2.Text = "文件名筛选";
            // 
            // txtSrcFilter
            // 
            this.txtSrcFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrcFilter.Location = new System.Drawing.Point(775, 54);
            this.txtSrcFilter.Name = "txtSrcFilter";
            this.txtSrcFilter.Size = new System.Drawing.Size(91, 26);
            this.txtSrcFilter.TabIndex = 4;
            this.txtSrcFilter.Text = "*.jpg|*.mov";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(692, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 99;
            this.label4.Text = "文件类型";
            // 
            // btPreview
            // 
            this.btPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPreview.Location = new System.Drawing.Point(469, 329);
            this.btPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btPreview.Name = "btPreview";
            this.btPreview.Size = new System.Drawing.Size(120, 72);
            this.btPreview.TabIndex = 12;
            this.btPreview.Text = " 预览";
            this.btPreview.UseVisualStyleBackColor = true;
            this.btPreview.Click += new System.EventHandler(this.btPreview_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(126, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "yyyy: 年 mm:月 dd:日 hh:时 ww:分 ss:秒";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(749, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 100;
            this.label6.Text = "e.g. a*.jpg|C*.avi";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 1061);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btPreview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSrcFilter);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btMgr);
            this.Controls.Add(this.btPauseResume);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkEmpty);
            this.Controls.Add(this.cbDest);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.cbSrc);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbTreeType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnS);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.chkSub);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 510);
            this.Name = "MainForm";
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.ComboBox cbSrc;
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
        private System.Windows.Forms.ComboBox cbDest;
        private System.Windows.Forms.CheckBox chkEmpty;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ContextMenuStrip gridMenu;
        private System.Windows.Forms.ToolStripMenuItem goSource;
        private System.Windows.Forms.ToolStripMenuItem goDest;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Button btPauseResume;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.Button btMgr;
        private System.Windows.Forms.ColumnHeader Logs;
        private System.Windows.Forms.ToolStripMenuItem retryToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbRenameFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSrcFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btPreview;
        private System.Windows.Forms.TextBox txtRenameTemplate;
        private System.Windows.Forms.TextBox txtRenameFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

