namespace BKS.Reports.Core
{
    partial class BaseReportControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseReportControl));
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelParam = new System.Windows.Forms.Panel();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.imgList = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rptView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelTop.SuspendLayout();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelParam);
            this.panelTop.Controls.Add(this.pnlButton);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 20);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(730, 77);
            this.panelTop.TabIndex = 2;
            // 
            // panelParam
            // 
            this.panelParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParam.Location = new System.Drawing.Point(0, 0);
            this.panelParam.Name = "panelParam";
            this.panelParam.Size = new System.Drawing.Size(632, 77);
            this.panelParam.TabIndex = 2;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnReport);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButton.Location = new System.Drawing.Point(632, 0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(98, 77);
            this.pnlButton.TabIndex = 1;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(12, 13);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 51);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "Raporu Çalıştır";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.imgList);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(730, 20);
            this.panelHeader.TabIndex = 4;
            // 
            // imgList
            // 
            this.imgList.Image = ((System.Drawing.Image)(resources.GetObject("imgList.Image")));
            this.imgList.Location = new System.Drawing.Point(5, 1);
            this.imgList.Name = "imgList";
            this.imgList.Size = new System.Drawing.Size(16, 18);
            this.imgList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgList.TabIndex = 1;
            this.imgList.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.Location = new System.Drawing.Point(27, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(692, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "...";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rptView
            // 
            this.rptView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptView.Location = new System.Drawing.Point(0, 97);
            this.rptView.Name = "rptView";
            this.rptView.Size = new System.Drawing.Size(730, 328);
            this.rptView.TabIndex = 5;
            // 
            // BaseReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rptView);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelHeader);
            this.Name = "BaseReportControl";
            this.Size = new System.Drawing.Size(730, 425);
            this.panelTop.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Panel panelParam;
        private System.Windows.Forms.Panel pnlButton;
        private DevExpress.XtraEditors.PanelControl panelHeader;
        private System.Windows.Forms.PictureBox imgList;
        private System.Windows.Forms.Label lblTitle;
        private Microsoft.Reporting.WinForms.ReportViewer rptView;
    }
}
