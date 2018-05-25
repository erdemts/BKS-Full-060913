namespace BKS.Forms.NoktaForm
{
    partial class NoktaEdit
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAciklama = new DevExpress.XtraEditors.TextEdit();
            this.lblAdi = new DevExpress.XtraEditors.LabelControl();
            this.grpBtn = new System.Windows.Forms.GroupBox();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblSeriNo = new System.Windows.Forms.Label();
            this.btnReadSerial = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            this.grpBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grpInfo);
            this.panelControl1.Controls.Add(this.grpBtn);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(487, 184);
            this.panelControl1.TabIndex = 0;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblSeriNo);
            this.grpInfo.Controls.Add(this.btnReadSerial);
            this.grpInfo.Controls.Add(this.labelControl2);
            this.grpInfo.Controls.Add(this.txtAciklama);
            this.grpInfo.Controls.Add(this.lblAdi);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.Location = new System.Drawing.Point(2, 2);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(483, 133);
            this.grpInfo.TabIndex = 1;
            this.grpInfo.TabStop = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(65, 74);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(389, 20);
            this.txtAciklama.TabIndex = 4;
            // 
            // lblAdi
            // 
            this.lblAdi.Location = new System.Drawing.Point(17, 43);
            this.lblAdi.Name = "lblAdi";
            this.lblAdi.Size = new System.Drawing.Size(34, 13);
            this.lblAdi.TabIndex = 1;
            this.lblAdi.Text = "Seri No";
            // 
            // grpBtn
            // 
            this.grpBtn.Controls.Add(this.btnOk);
            this.grpBtn.Controls.Add(this.btnCancel);
            this.grpBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBtn.Location = new System.Drawing.Point(2, 135);
            this.grpBtn.Name = "grpBtn";
            this.grpBtn.Size = new System.Drawing.Size(483, 47);
            this.grpBtn.TabIndex = 0;
            this.grpBtn.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(275, 19);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Kaydet";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(380, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "İptal";
            // 
            // lblSeriNo
            // 
            this.lblSeriNo.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSeriNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeriNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSeriNo.Location = new System.Drawing.Point(65, 39);
            this.lblSeriNo.Name = "lblSeriNo";
            this.lblSeriNo.Size = new System.Drawing.Size(153, 23);
            this.lblSeriNo.TabIndex = 14;
            this.lblSeriNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReadSerial
            // 
            this.btnReadSerial.Location = new System.Drawing.Point(224, 39);
            this.btnReadSerial.Name = "btnReadSerial";
            this.btnReadSerial.Size = new System.Drawing.Size(80, 23);
            this.btnReadSerial.TabIndex = 13;
            this.btnReadSerial.Text = "Cihazdan Oku";
            this.btnReadSerial.Click += new System.EventHandler(this.btnReadSerial_Click);
            // 
            // NoktaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 184);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoktaEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            this.grpBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.GroupBox grpBtn;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtAciklama;
        private DevExpress.XtraEditors.LabelControl lblAdi;
        private System.Windows.Forms.Label lblSeriNo;
        private DevExpress.XtraEditors.SimpleButton btnReadSerial;
    }
}