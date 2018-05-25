namespace BKS
{
    partial class BackroundProcess
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
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.progBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblProcess = new System.Windows.Forms.Label();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblProcess);
            this.grpInfo.Controls.Add(this.progBar);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.Location = new System.Drawing.Point(0, 0);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(370, 170);
            this.grpInfo.TabIndex = 2;
            this.grpInfo.TabStop = false;
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(54, 72);
            this.progBar.Name = "progBar";
            this.progBar.Properties.Step = 1;
            this.progBar.Size = new System.Drawing.Size(263, 26);
            this.progBar.TabIndex = 2;
            // 
            // lblProcess
            // 
            this.lblProcess.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProcess.Location = new System.Drawing.Point(54, 32);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(263, 23);
            this.lblProcess.TabIndex = 3;
            this.lblProcess.Text = "...";
            this.lblProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BackroundProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 170);
            this.ControlBox = false;
            this.Controls.Add(this.grpInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackroundProcess";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "İşlem Yapılıyor !..";
            this.grpInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progBar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblProcess;
        private DevExpress.XtraEditors.ProgressBarControl progBar;


    }
}