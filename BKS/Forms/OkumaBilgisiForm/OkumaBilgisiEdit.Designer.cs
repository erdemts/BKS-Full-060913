namespace BKS.Forms.OkumaBilgisiForm
{
    partial class OkumaBilgisiEdit
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
            this.grpBtn = new System.Windows.Forms.GroupBox();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtIslemTarihi = new DevExpress.XtraEditors.DateEdit();
            this.tmIslemTarihi = new DevExpress.XtraEditors.TimeEdit();
            this.chkElleMudehale = new DevExpress.XtraEditors.CheckEdit();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkpPersonel = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lkpOlayTipi = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lkpNokta = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lkpKalem = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.grpBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtIslemTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIslemTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmIslemTarihi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkElleMudehale.Properties)).BeginInit();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPersonel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOlayTipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpNokta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpKalem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grpInfo);
            this.panelControl1.Controls.Add(this.grpBtn);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(429, 284);
            this.panelControl1.TabIndex = 0;
            // 
            // grpBtn
            // 
            this.grpBtn.Controls.Add(this.btnOk);
            this.grpBtn.Controls.Add(this.btnCancel);
            this.grpBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBtn.Location = new System.Drawing.Point(2, 235);
            this.grpBtn.Name = "grpBtn";
            this.grpBtn.Size = new System.Drawing.Size(425, 47);
            this.grpBtn.TabIndex = 0;
            this.grpBtn.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(220, 17);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Kaydet";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(325, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "İptal";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 35);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "İşlem Tarihi";
            // 
            // dtIslemTarihi
            // 
            this.dtIslemTarihi.EditValue = null;
            this.dtIslemTarihi.Location = new System.Drawing.Point(109, 32);
            this.dtIslemTarihi.Name = "dtIslemTarihi";
            this.dtIslemTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtIslemTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtIslemTarihi.Size = new System.Drawing.Size(150, 20);
            this.dtIslemTarihi.TabIndex = 7;
            // 
            // tmIslemTarihi
            // 
            this.tmIslemTarihi.EditValue = new System.DateTime(2012, 12, 16, 0, 0, 0, 0);
            this.tmIslemTarihi.Location = new System.Drawing.Point(109, 58);
            this.tmIslemTarihi.Name = "tmIslemTarihi";
            this.tmIslemTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tmIslemTarihi.Size = new System.Drawing.Size(100, 20);
            this.tmIslemTarihi.TabIndex = 11;
            // 
            // chkElleMudehale
            // 
            this.chkElleMudehale.Enabled = false;
            this.chkElleMudehale.Location = new System.Drawing.Point(107, 199);
            this.chkElleMudehale.Name = "chkElleMudehale";
            this.chkElleMudehale.Properties.Caption = "Elle Müdehale";
            this.chkElleMudehale.Size = new System.Drawing.Size(100, 19);
            this.chkElleMudehale.TabIndex = 13;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lkpKalem);
            this.grpInfo.Controls.Add(this.labelControl6);
            this.grpInfo.Controls.Add(this.lkpNokta);
            this.grpInfo.Controls.Add(this.labelControl5);
            this.grpInfo.Controls.Add(this.lkpOlayTipi);
            this.grpInfo.Controls.Add(this.labelControl4);
            this.grpInfo.Controls.Add(this.lkpPersonel);
            this.grpInfo.Controls.Add(this.labelControl2);
            this.grpInfo.Controls.Add(this.labelControl1);
            this.grpInfo.Controls.Add(this.chkElleMudehale);
            this.grpInfo.Controls.Add(this.tmIslemTarihi);
            this.grpInfo.Controls.Add(this.dtIslemTarihi);
            this.grpInfo.Controls.Add(this.labelControl3);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.Location = new System.Drawing.Point(2, 2);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(425, 233);
            this.grpInfo.TabIndex = 1;
            this.grpInfo.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 61);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "İşlem Saati";
            // 
            // lkpPersonel
            // 
            this.lkpPersonel.Location = new System.Drawing.Point(109, 84);
            this.lkpPersonel.Name = "lkpPersonel";
            this.lkpPersonel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpPersonel.Size = new System.Drawing.Size(203, 20);
            this.lkpPersonel.TabIndex = 15;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Personel";
            // 
            // lkpOlayTipi
            // 
            this.lkpOlayTipi.Location = new System.Drawing.Point(109, 136);
            this.lkpOlayTipi.Name = "lkpOlayTipi";
            this.lkpOlayTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpOlayTipi.Size = new System.Drawing.Size(203, 20);
            this.lkpOlayTipi.TabIndex = 17;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(22, 139);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(22, 13);
            this.labelControl4.TabIndex = 18;
            this.labelControl4.Text = "Olay";
            // 
            // lkpNokta
            // 
            this.lkpNokta.Location = new System.Drawing.Point(109, 110);
            this.lkpNokta.Name = "lkpNokta";
            this.lkpNokta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpNokta.Size = new System.Drawing.Size(203, 20);
            this.lkpNokta.TabIndex = 19;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(22, 113);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 13);
            this.labelControl5.TabIndex = 20;
            this.labelControl5.Text = "Nokta";
            // 
            // lkpKalem
            // 
            this.lkpKalem.Location = new System.Drawing.Point(109, 162);
            this.lkpKalem.Name = "lkpKalem";
            this.lkpKalem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpKalem.Size = new System.Drawing.Size(203, 20);
            this.lkpKalem.TabIndex = 21;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(22, 165);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(28, 13);
            this.labelControl6.TabIndex = 22;
            this.labelControl6.Text = "Kalem";
            // 
            // OkumaBilgisiEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 284);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OkumaBilgisiEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.grpBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtIslemTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIslemTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmIslemTarihi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkElleMudehale.Properties)).EndInit();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPersonel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpOlayTipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpNokta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpKalem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.GroupBox grpBtn;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.GroupBox grpInfo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkElleMudehale;
        private DevExpress.XtraEditors.TimeEdit tmIslemTarihi;
        private DevExpress.XtraEditors.DateEdit dtIslemTarihi;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lkpPersonel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lkpOlayTipi;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lkpNokta;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lkpKalem;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}