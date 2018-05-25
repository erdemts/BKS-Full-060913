namespace BKS.Forms.OperasyonForm
{
    partial class OperasyonEdit
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
            this.label3 = new System.Windows.Forms.Label();
            this.ddlStatu = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdOperasyonNokta = new DevExpress.XtraGrid.GridControl();
            this.gridViewSelected = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clOperasyonStatuIsim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNokta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNoktaSaat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clOkumaSaat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPersonelIsim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKalemIsim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clOlayIsim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.lkpDevriye = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkpPersonel = new DevExpress.XtraEditors.LookUpEdit();
            this.tmNobetSaati = new DevExpress.XtraEditors.TimeEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.dtNobetTarihi = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAdi = new DevExpress.XtraEditors.LabelControl();
            this.grpBtn = new System.Windows.Forms.GroupBox();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatu.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOperasyonNokta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDevriye.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPersonel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmNobetSaati.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNobetTarihi.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNobetTarihi.Properties)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(578, 342);
            this.panelControl1.TabIndex = 0;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.label3);
            this.grpInfo.Controls.Add(this.ddlStatu);
            this.grpInfo.Controls.Add(this.groupBox1);
            this.grpInfo.Controls.Add(this.lkpDevriye);
            this.grpInfo.Controls.Add(this.labelControl1);
            this.grpInfo.Controls.Add(this.lkpPersonel);
            this.grpInfo.Controls.Add(this.tmNobetSaati);
            this.grpInfo.Controls.Add(this.label2);
            this.grpInfo.Controls.Add(this.dtNobetTarihi);
            this.grpInfo.Controls.Add(this.label1);
            this.grpInfo.Controls.Add(this.lblAdi);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.Location = new System.Drawing.Point(2, 2);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(574, 291);
            this.grpInfo.TabIndex = 1;
            this.grpInfo.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Statü";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddlStatu
            // 
            this.ddlStatu.Location = new System.Drawing.Point(346, 53);
            this.ddlStatu.Name = "ddlStatu";
            this.ddlStatu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlStatu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ddlStatu.Size = new System.Drawing.Size(168, 20);
            this.ddlStatu.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdOperasyonNokta);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 167);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nokta Okuma Bilgileri";
            // 
            // grdOperasyonNokta
            // 
            this.grdOperasyonNokta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOperasyonNokta.Location = new System.Drawing.Point(3, 16);
            this.grdOperasyonNokta.MainView = this.gridViewSelected;
            this.grdOperasyonNokta.Name = "grdOperasyonNokta";
            this.grdOperasyonNokta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1});
            this.grdOperasyonNokta.Size = new System.Drawing.Size(562, 148);
            this.grdOperasyonNokta.TabIndex = 2;
            this.grdOperasyonNokta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSelected});
            // 
            // gridViewSelected
            // 
            this.gridViewSelected.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clOperasyonStatuIsim,
            this.clNokta,
            this.clNoktaSaat,
            this.clOkumaSaat,
            this.clPersonelIsim,
            this.clKalemIsim,
            this.clOlayIsim});
            this.gridViewSelected.GridControl = this.grdOperasyonNokta;
            this.gridViewSelected.Name = "gridViewSelected";
            this.gridViewSelected.OptionsCustomization.AllowFilter = false;
            this.gridViewSelected.OptionsSelection.MultiSelect = true;
            this.gridViewSelected.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewSelected.OptionsView.ShowGroupPanel = false;
            // 
            // clOperasyonStatuIsim
            // 
            this.clOperasyonStatuIsim.Caption = "Statü";
            this.clOperasyonStatuIsim.FieldName = "OperasyonStatuIsim";
            this.clOperasyonStatuIsim.Name = "clOperasyonStatuIsim";
            this.clOperasyonStatuIsim.OptionsColumn.AllowEdit = false;
            this.clOperasyonStatuIsim.OptionsColumn.AllowFocus = false;
            this.clOperasyonStatuIsim.Visible = true;
            this.clOperasyonStatuIsim.VisibleIndex = 4;
            // 
            // clNokta
            // 
            this.clNokta.Caption = "Nokta";
            this.clNokta.FieldName = "NoktaIsim";
            this.clNokta.Name = "clNokta";
            this.clNokta.OptionsColumn.AllowEdit = false;
            this.clNokta.OptionsColumn.AllowFocus = false;
            this.clNokta.Visible = true;
            this.clNokta.VisibleIndex = 0;
            // 
            // clNoktaSaat
            // 
            this.clNoktaSaat.Caption = "Nokta Saati";
            this.clNoktaSaat.FieldName = "NoktaSaati";
            this.clNoktaSaat.Name = "clNoktaSaat";
            this.clNoktaSaat.OptionsColumn.AllowEdit = false;
            this.clNoktaSaat.OptionsColumn.AllowFocus = false;
            this.clNoktaSaat.Visible = true;
            this.clNoktaSaat.VisibleIndex = 1;
            // 
            // clOkumaSaat
            // 
            this.clOkumaSaat.Caption = "Okuma Saati";
            this.clOkumaSaat.FieldName = "OkumaSaati";
            this.clOkumaSaat.Name = "clOkumaSaat";
            this.clOkumaSaat.OptionsColumn.AllowEdit = false;
            this.clOkumaSaat.OptionsColumn.AllowFocus = false;
            this.clOkumaSaat.Visible = true;
            this.clOkumaSaat.VisibleIndex = 2;
            // 
            // clPersonelIsim
            // 
            this.clPersonelIsim.Caption = "Personel";
            this.clPersonelIsim.FieldName = "PersonelIsim";
            this.clPersonelIsim.Name = "clPersonelIsim";
            this.clPersonelIsim.OptionsColumn.AllowEdit = false;
            this.clPersonelIsim.OptionsColumn.AllowFocus = false;
            this.clPersonelIsim.Visible = true;
            this.clPersonelIsim.VisibleIndex = 3;
            // 
            // clKalemIsim
            // 
            this.clKalemIsim.Caption = "Kalem";
            this.clKalemIsim.FieldName = "KalemIsim";
            this.clKalemIsim.Name = "clKalemIsim";
            this.clKalemIsim.OptionsColumn.AllowEdit = false;
            this.clKalemIsim.OptionsColumn.AllowFocus = false;
            this.clKalemIsim.Visible = true;
            this.clKalemIsim.VisibleIndex = 6;
            // 
            // clOlayIsim
            // 
            this.clOlayIsim.Caption = "Olay";
            this.clOlayIsim.FieldName = "OlayIsim";
            this.clOlayIsim.Name = "clOlayIsim";
            this.clOlayIsim.OptionsColumn.AllowEdit = false;
            this.clOlayIsim.OptionsColumn.AllowFocus = false;
            this.clOlayIsim.Visible = true;
            this.clOlayIsim.VisibleIndex = 5;
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // lkpDevriye
            // 
            this.lkpDevriye.Location = new System.Drawing.Point(75, 25);
            this.lkpDevriye.Name = "lkpDevriye";
            this.lkpDevriye.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpDevriye.Size = new System.Drawing.Size(168, 20);
            this.lkpDevriye.TabIndex = 20;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Devriye";
            // 
            // lkpPersonel
            // 
            this.lkpPersonel.Location = new System.Drawing.Point(346, 25);
            this.lkpPersonel.Name = "lkpPersonel";
            this.lkpPersonel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpPersonel.Size = new System.Drawing.Size(168, 20);
            this.lkpPersonel.TabIndex = 18;
            // 
            // tmNobetSaati
            // 
            this.tmNobetSaati.EditValue = new System.DateTime(2012, 12, 9, 0, 0, 0, 0);
            this.tmNobetSaati.Location = new System.Drawing.Point(75, 79);
            this.tmNobetSaati.Name = "tmNobetSaati";
            this.tmNobetSaati.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tmNobetSaati.Size = new System.Drawing.Size(134, 20);
            this.tmNobetSaati.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Saati";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtNobetTarihi
            // 
            this.dtNobetTarihi.EditValue = null;
            this.dtNobetTarihi.Location = new System.Drawing.Point(75, 53);
            this.dtNobetTarihi.Name = "dtNobetTarihi";
            this.dtNobetTarihi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNobetTarihi.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNobetTarihi.Size = new System.Drawing.Size(134, 20);
            this.dtNobetTarihi.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tarih";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAdi
            // 
            this.lblAdi.Location = new System.Drawing.Point(290, 28);
            this.lblAdi.Name = "lblAdi";
            this.lblAdi.Size = new System.Drawing.Size(41, 13);
            this.lblAdi.TabIndex = 13;
            this.lblAdi.Text = "Personel";
            // 
            // grpBtn
            // 
            this.grpBtn.Controls.Add(this.btnOk);
            this.grpBtn.Controls.Add(this.btnCancel);
            this.grpBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBtn.Location = new System.Drawing.Point(2, 293);
            this.grpBtn.Name = "grpBtn";
            this.grpBtn.Size = new System.Drawing.Size(574, 47);
            this.grpBtn.TabIndex = 0;
            this.grpBtn.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(379, 14);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Kaydet";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(484, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "İptal";
            // 
            // OperasyonEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 342);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperasyonEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStatu.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOperasyonNokta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpDevriye.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpPersonel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmNobetSaati.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNobetTarihi.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNobetTarihi.Properties)).EndInit();
            this.grpBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.GroupBox grpBtn;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LookUpEdit lkpPersonel;
        private DevExpress.XtraEditors.TimeEdit tmNobetSaati;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit dtNobetTarihi;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl lblAdi;
        private DevExpress.XtraEditors.LookUpEdit lkpDevriye;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl grdOperasyonNokta;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clNokta;
        private DevExpress.XtraGrid.Columns.GridColumn clNoktaSaat;
        private DevExpress.XtraGrid.Columns.GridColumn clOperasyonStatuIsim;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.ComboBoxEdit ddlStatu;
        private DevExpress.XtraGrid.Columns.GridColumn clOkumaSaat;
        private DevExpress.XtraGrid.Columns.GridColumn clPersonelIsim;
        private DevExpress.XtraGrid.Columns.GridColumn clKalemIsim;
        private DevExpress.XtraGrid.Columns.GridColumn clOlayIsim;
    }
}