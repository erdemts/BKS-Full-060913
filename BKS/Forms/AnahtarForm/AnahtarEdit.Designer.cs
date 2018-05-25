namespace BKS.Forms.AnahtarForm
{
    partial class AnahtarEdit
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
            this.lblSeriNo = new System.Windows.Forms.Label();
            this.btnReadSerial = new DevExpress.XtraEditors.SimpleButton();
            this.lkpOlayTipi = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lkpPersonel = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbAnahtarTip = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAciklama = new DevExpress.XtraEditors.TextEdit();
            this.lblAdi = new DevExpress.XtraEditors.LabelControl();
            this.grpBtn = new System.Windows.Forms.GroupBox();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOlayTipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPersonel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAnahtarTip.Properties)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(487, 259);
            this.panelControl1.TabIndex = 0;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblSeriNo);
            this.grpInfo.Controls.Add(this.btnReadSerial);
            this.grpInfo.Controls.Add(this.lkpOlayTipi);
            this.grpInfo.Controls.Add(this.labelControl4);
            this.grpInfo.Controls.Add(this.lkpPersonel);
            this.grpInfo.Controls.Add(this.labelControl3);
            this.grpInfo.Controls.Add(this.labelControl1);
            this.grpInfo.Controls.Add(this.cmbAnahtarTip);
            this.grpInfo.Controls.Add(this.labelControl2);
            this.grpInfo.Controls.Add(this.txtAciklama);
            this.grpInfo.Controls.Add(this.lblAdi);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.Location = new System.Drawing.Point(2, 2);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(483, 208);
            this.grpInfo.TabIndex = 1;
            this.grpInfo.TabStop = false;
            // 
            // lblSeriNo
            // 
            this.lblSeriNo.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSeriNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeriNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSeriNo.Location = new System.Drawing.Point(81, 34);
            this.lblSeriNo.Name = "lblSeriNo";
            this.lblSeriNo.Size = new System.Drawing.Size(153, 23);
            this.lblSeriNo.TabIndex = 12;
            this.lblSeriNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReadSerial
            // 
            this.btnReadSerial.Location = new System.Drawing.Point(240, 34);
            this.btnReadSerial.Name = "btnReadSerial";
            this.btnReadSerial.Size = new System.Drawing.Size(80, 23);
            this.btnReadSerial.TabIndex = 11;
            this.btnReadSerial.Text = "Cihazdan Oku";
            this.btnReadSerial.Click += new System.EventHandler(this.btnReadSerial_Click);
            // 
            // lkpOlayTipi
            // 
            this.lkpOlayTipi.Enabled = false;
            this.lkpOlayTipi.Location = new System.Drawing.Point(81, 123);
            this.lkpOlayTipi.Name = "lkpOlayTipi";
            this.lkpOlayTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpOlayTipi.Size = new System.Drawing.Size(203, 20);
            this.lkpOlayTipi.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(17, 126);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(22, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Olay";
            // 
            // lkpPersonel
            // 
            this.lkpPersonel.Enabled = false;
            this.lkpPersonel.Location = new System.Drawing.Point(81, 97);
            this.lkpPersonel.Name = "lkpPersonel";
            this.lkpPersonel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpPersonel.Size = new System.Drawing.Size(203, 20);
            this.lkpPersonel.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 100);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Personel";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Anahtar Tipi";
            // 
            // cmbAnahtarTip
            // 
            this.cmbAnahtarTip.Location = new System.Drawing.Point(81, 66);
            this.cmbAnahtarTip.Name = "cmbAnahtarTip";
            this.cmbAnahtarTip.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAnahtarTip.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick;
            this.cmbAnahtarTip.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbAnahtarTip.Size = new System.Drawing.Size(150, 20);
            this.cmbAnahtarTip.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 168);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(81, 165);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(389, 20);
            this.txtAciklama.TabIndex = 4;
            // 
            // lblAdi
            // 
            this.lblAdi.Location = new System.Drawing.Point(17, 39);
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
            this.grpBtn.Location = new System.Drawing.Point(2, 210);
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
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Kaydet";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(380, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "İptal";
            // 
            // AnahtarEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 259);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnahtarEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOlayTipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPersonel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAnahtarTip.Properties)).EndInit();
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
        private DevExpress.XtraEditors.ComboBoxEdit cmbAnahtarTip;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkpOlayTipi;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lkpPersonel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.Label lblSeriNo;
        private DevExpress.XtraEditors.SimpleButton btnReadSerial;
    }
}