namespace PhotoMover
{
    partial class JobDetailsForm
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
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.txtCalculatedDest = new System.Windows.Forms.TextBox();
            this.txtRealDest = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bgGoSrc = new System.Windows.Forms.Button();
            this.btGoCalculatedDest = new System.Windows.Forms.Button();
            this.btGoRealDest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSrc
            // 
            this.txtSrc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrc.Location = new System.Drawing.Point(145, 10);
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.ReadOnly = true;
            this.txtSrc.Size = new System.Drawing.Size(576, 26);
            this.txtSrc.TabIndex = 0;
            // 
            // txtCalculatedDest
            // 
            this.txtCalculatedDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCalculatedDest.Location = new System.Drawing.Point(145, 55);
            this.txtCalculatedDest.Name = "txtCalculatedDest";
            this.txtCalculatedDest.ReadOnly = true;
            this.txtCalculatedDest.Size = new System.Drawing.Size(576, 26);
            this.txtCalculatedDest.TabIndex = 1;
            // 
            // txtRealDest
            // 
            this.txtRealDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRealDest.Location = new System.Drawing.Point(145, 99);
            this.txtRealDest.Name = "txtRealDest";
            this.txtRealDest.ReadOnly = true;
            this.txtRealDest.Size = new System.Drawing.Size(576, 26);
            this.txtRealDest.TabIndex = 2;
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(145, 142);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(148, 26);
            this.txtStatus.TabIndex = 3;
            // 
            // txtLogs
            // 
            this.txtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogs.Location = new System.Drawing.Point(12, 187);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.Size = new System.Drawing.Size(790, 398);
            this.txtLogs.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Destination";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Real Destination";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Logs";
            // 
            // bgGoSrc
            // 
            this.bgGoSrc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bgGoSrc.Location = new System.Drawing.Point(727, 6);
            this.bgGoSrc.Name = "bgGoSrc";
            this.bgGoSrc.Size = new System.Drawing.Size(75, 34);
            this.bgGoSrc.TabIndex = 10;
            this.bgGoSrc.Text = "Go";
            this.bgGoSrc.UseVisualStyleBackColor = true;
            this.bgGoSrc.Click += new System.EventHandler(this.bgGoSrc_Click);
            // 
            // btGoCalculatedDest
            // 
            this.btGoCalculatedDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGoCalculatedDest.Location = new System.Drawing.Point(727, 51);
            this.btGoCalculatedDest.Name = "btGoCalculatedDest";
            this.btGoCalculatedDest.Size = new System.Drawing.Size(75, 34);
            this.btGoCalculatedDest.TabIndex = 12;
            this.btGoCalculatedDest.Text = "Go";
            this.btGoCalculatedDest.UseVisualStyleBackColor = true;
            this.btGoCalculatedDest.Click += new System.EventHandler(this.btGoCalculatedDest_Click);
            // 
            // btGoRealDest
            // 
            this.btGoRealDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGoRealDest.Location = new System.Drawing.Point(727, 95);
            this.btGoRealDest.Name = "btGoRealDest";
            this.btGoRealDest.Size = new System.Drawing.Size(75, 34);
            this.btGoRealDest.TabIndex = 13;
            this.btGoRealDest.Text = "Go";
            this.btGoRealDest.UseVisualStyleBackColor = true;
            this.btGoRealDest.Click += new System.EventHandler(this.btGoRealDest_Click);
            // 
            // JobDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 597);
            this.Controls.Add(this.btGoRealDest);
            this.Controls.Add(this.btGoCalculatedDest);
            this.Controls.Add(this.bgGoSrc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtRealDest);
            this.Controls.Add(this.txtCalculatedDest);
            this.Controls.Add(this.txtSrc);
            this.Name = "JobDetailsForm";
            this.Text = "JobDetails";
            this.Load += new System.EventHandler(this.JobDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.TextBox txtCalculatedDest;
        private System.Windows.Forms.TextBox txtRealDest;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bgGoSrc;
        private System.Windows.Forms.Button btGoCalculatedDest;
        private System.Windows.Forms.Button btGoRealDest;
    }
}