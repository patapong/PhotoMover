namespace PhotoMover
{
    partial class PluginManager
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
            this.extList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.handlerList = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // extList
            // 
            this.extList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.extList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.extList.FormattingEnabled = true;
            this.extList.ItemHeight = 29;
            this.extList.Location = new System.Drawing.Point(0, 0);
            this.extList.Name = "extList";
            this.extList.Size = new System.Drawing.Size(206, 562);
            this.extList.TabIndex = 1;
            this.extList.SelectedIndexChanged += new System.EventHandler(this.extList_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.handlerList);
            this.panel1.Location = new System.Drawing.Point(212, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 562);
            this.panel1.TabIndex = 2;
            // 
            // handlerList
            // 
            this.handlerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.handlerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.handlerList.FormattingEnabled = true;
            this.handlerList.Location = new System.Drawing.Point(0, 0);
            this.handlerList.Name = "handlerList";
            this.handlerList.Size = new System.Drawing.Size(762, 562);
            this.handlerList.TabIndex = 0;
            this.handlerList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.handlerList_ItemCheck);
            // 
            // PluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.extList);
            this.Name = "PluginManager";
            this.Text = "PluginManager";
            this.Load += new System.EventHandler(this.PluginManager_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox extList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox handlerList;
    }
}