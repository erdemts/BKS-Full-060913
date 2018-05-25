namespace BKS.Forms.OperasyonForm
{
    partial class OperasyonListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperasyonListesi));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.imgList = new System.Windows.Forms.PictureBox();
            this.lblList = new System.Windows.Forms.Label();
            this.grdCtrlDevriye = new DevExpress.XtraGrid.GridControl();
            this.personelView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clDevriyeGunu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDevriyeSaati = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDevriyeIsim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPersonel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clOperasyonStatuIsim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clElleDegisim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabDevriye = new System.Windows.Forms.TabPage();
            this.tabNokta = new System.Windows.Forms.TabPage();
            this.grdOperasyonNokta = new DevExpress.XtraGrid.GridControl();
            this.gridViewSelected = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clStatu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNokta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNoktaSaat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clOkumaSaat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPersonelIsim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKalemIsim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clOlayIsim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDevriye = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clDevriyeTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlDevriye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelView)).BeginInit();
            this.tabCtrl.SuspendLayout();
            this.tabDevriye.SuspendLayout();
            this.tabNokta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOperasyonNokta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.imgList);
            this.panelControl1.Controls.Add(this.lblList);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(619, 30);
            this.panelControl1.TabIndex = 0;
            // 
            // imgList
            // 
            this.imgList.Image = ((System.Drawing.Image)(resources.GetObject("imgList.Image")));
            this.imgList.Location = new System.Drawing.Point(5, 5);
            this.imgList.Name = "imgList";
            this.imgList.Size = new System.Drawing.Size(16, 23);
            this.imgList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgList.TabIndex = 1;
            this.imgList.TabStop = false;
            // 
            // lblList
            // 
            this.lblList.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblList.Location = new System.Drawing.Point(27, 5);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(176, 23);
            this.lblList.TabIndex = 0;
            this.lblList.Text = "Tur Hareketleri";
            this.lblList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdCtrlDevriye
            // 
            this.grdCtrlDevriye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrlDevriye.Location = new System.Drawing.Point(0, 0);
            this.grdCtrlDevriye.MainView = this.personelView;
            this.grdCtrlDevriye.Name = "grdCtrlDevriye";
            this.grdCtrlDevriye.Size = new System.Drawing.Size(611, 283);
            this.grdCtrlDevriye.TabIndex = 1;
            this.grdCtrlDevriye.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.personelView});
            // 
            // personelView
            // 
            this.personelView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clDevriyeGunu,
            this.clDevriyeSaati,
            this.clDevriyeIsim,
            this.clPersonel,
            this.clOperasyonStatuIsim,
            this.clElleDegisim});
            this.personelView.GridControl = this.grdCtrlDevriye;
            this.personelView.Name = "personelView";
            this.personelView.OptionsCustomization.AllowFilter = false;
            this.personelView.OptionsSelection.MultiSelect = true;
            this.personelView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            // 
            // clDevriyeGunu
            // 
            this.clDevriyeGunu.Caption = "Tarih";
            this.clDevriyeGunu.FieldName = "DevriyeGunu";
            this.clDevriyeGunu.Name = "clDevriyeGunu";
            this.clDevriyeGunu.OptionsColumn.AllowEdit = false;
            this.clDevriyeGunu.OptionsColumn.AllowFocus = false;
            this.clDevriyeGunu.Visible = true;
            this.clDevriyeGunu.VisibleIndex = 0;
            this.clDevriyeGunu.Width = 105;
            // 
            // clDevriyeSaati
            // 
            this.clDevriyeSaati.Caption = "Saat";
            this.clDevriyeSaati.FieldName = "DevriyeSaati";
            this.clDevriyeSaati.Name = "clDevriyeSaati";
            this.clDevriyeSaati.OptionsColumn.AllowEdit = false;
            this.clDevriyeSaati.OptionsColumn.AllowFocus = false;
            this.clDevriyeSaati.Visible = true;
            this.clDevriyeSaati.VisibleIndex = 1;
            this.clDevriyeSaati.Width = 105;
            // 
            // clDevriyeIsim
            // 
            this.clDevriyeIsim.Caption = "Devriye";
            this.clDevriyeIsim.FieldName = "DevriyeIsim";
            this.clDevriyeIsim.Name = "clDevriyeIsim";
            this.clDevriyeIsim.OptionsColumn.AllowEdit = false;
            this.clDevriyeIsim.OptionsColumn.AllowFocus = false;
            this.clDevriyeIsim.Visible = true;
            this.clDevriyeIsim.VisibleIndex = 2;
            this.clDevriyeIsim.Width = 105;
            // 
            // clPersonel
            // 
            this.clPersonel.Caption = "Personel";
            this.clPersonel.FieldName = "PersonelIsim";
            this.clPersonel.Name = "clPersonel";
            this.clPersonel.OptionsColumn.AllowEdit = false;
            this.clPersonel.OptionsColumn.AllowFocus = false;
            this.clPersonel.Visible = true;
            this.clPersonel.VisibleIndex = 3;
            this.clPersonel.Width = 105;
            // 
            // clOperasyonStatuIsim
            // 
            this.clOperasyonStatuIsim.Caption = "Durum";
            this.clOperasyonStatuIsim.FieldName = "OperasyonStatuIsim";
            this.clOperasyonStatuIsim.Name = "clOperasyonStatuIsim";
            this.clOperasyonStatuIsim.OptionsColumn.AllowEdit = false;
            this.clOperasyonStatuIsim.OptionsColumn.AllowFocus = false;
            this.clOperasyonStatuIsim.Visible = true;
            this.clOperasyonStatuIsim.VisibleIndex = 4;
            this.clOperasyonStatuIsim.Width = 106;
            // 
            // clElleDegisim
            // 
            this.clElleDegisim.Caption = "Elle Deg.";
            this.clElleDegisim.FieldName = "IsElleDegisim";
            this.clElleDegisim.Name = "clElleDegisim";
            this.clElleDegisim.OptionsColumn.FixedWidth = true;
            this.clElleDegisim.Visible = true;
            this.clElleDegisim.VisibleIndex = 5;
            this.clElleDegisim.Width = 50;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabDevriye);
            this.tabCtrl.Controls.Add(this.tabNokta);
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.Location = new System.Drawing.Point(0, 30);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.Padding = new System.Drawing.Point(10, 5);
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(619, 313);
            this.tabCtrl.TabIndex = 2;
            // 
            // tabDevriye
            // 
            this.tabDevriye.Controls.Add(this.grdCtrlDevriye);
            this.tabDevriye.Location = new System.Drawing.Point(4, 26);
            this.tabDevriye.Margin = new System.Windows.Forms.Padding(0);
            this.tabDevriye.Name = "tabDevriye";
            this.tabDevriye.Size = new System.Drawing.Size(611, 283);
            this.tabDevriye.TabIndex = 0;
            this.tabDevriye.Text = "Tur Hareketleri";
            this.tabDevriye.UseVisualStyleBackColor = true;
            // 
            // tabNokta
            // 
            this.tabNokta.BackColor = System.Drawing.Color.Transparent;
            this.tabNokta.Controls.Add(this.grdOperasyonNokta);
            this.tabNokta.Location = new System.Drawing.Point(4, 26);
            this.tabNokta.Margin = new System.Windows.Forms.Padding(0);
            this.tabNokta.Name = "tabNokta";
            this.tabNokta.Size = new System.Drawing.Size(611, 283);
            this.tabNokta.TabIndex = 1;
            this.tabNokta.Text = "Nokta Hareketleri";
            // 
            // grdOperasyonNokta
            // 
            this.grdOperasyonNokta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOperasyonNokta.Location = new System.Drawing.Point(0, 0);
            this.grdOperasyonNokta.MainView = this.gridViewSelected;
            this.grdOperasyonNokta.Name = "grdOperasyonNokta";
            this.grdOperasyonNokta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1});
            this.grdOperasyonNokta.Size = new System.Drawing.Size(611, 283);
            this.grdOperasyonNokta.TabIndex = 3;
            this.grdOperasyonNokta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSelected});
            // 
            // gridViewSelected
            // 
            this.gridViewSelected.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clStatu,
            this.clNokta,
            this.clNoktaSaat,
            this.clOkumaSaat,
            this.clPersonelIsim,
            this.clKalemIsim,
            this.clOlayIsim,
            this.clDevriye,
            this.clDevriyeTarihi});
            this.gridViewSelected.GridControl = this.grdOperasyonNokta;
            this.gridViewSelected.Name = "gridViewSelected";
            this.gridViewSelected.OptionsCustomization.AllowFilter = false;
            this.gridViewSelected.OptionsSelection.MultiSelect = true;
            this.gridViewSelected.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            // 
            // clStatu
            // 
            this.clStatu.Caption = "Statü";
            this.clStatu.FieldName = "OperasyonStatuIsim";
            this.clStatu.Name = "clStatu";
            this.clStatu.OptionsColumn.AllowEdit = false;
            this.clStatu.OptionsColumn.AllowFocus = false;
            this.clStatu.Visible = true;
            this.clStatu.VisibleIndex = 6;
            // 
            // clNokta
            // 
            this.clNokta.Caption = "Nokta";
            this.clNokta.FieldName = "NoktaIsim";
            this.clNokta.Name = "clNokta";
            this.clNokta.OptionsColumn.AllowEdit = false;
            this.clNokta.OptionsColumn.AllowFocus = false;
            this.clNokta.Visible = true;
            this.clNokta.VisibleIndex = 2;
            // 
            // clNoktaSaat
            // 
            this.clNoktaSaat.Caption = "Nokta Saati";
            this.clNoktaSaat.FieldName = "NoktaSaati";
            this.clNoktaSaat.Name = "clNoktaSaat";
            this.clNoktaSaat.OptionsColumn.AllowEdit = false;
            this.clNoktaSaat.OptionsColumn.AllowFocus = false;
            this.clNoktaSaat.Visible = true;
            this.clNoktaSaat.VisibleIndex = 3;
            // 
            // clOkumaSaat
            // 
            this.clOkumaSaat.Caption = "Okuma Saati";
            this.clOkumaSaat.FieldName = "OkumaSaati";
            this.clOkumaSaat.Name = "clOkumaSaat";
            this.clOkumaSaat.OptionsColumn.AllowEdit = false;
            this.clOkumaSaat.OptionsColumn.AllowFocus = false;
            this.clOkumaSaat.Visible = true;
            this.clOkumaSaat.VisibleIndex = 4;
            // 
            // clPersonelIsim
            // 
            this.clPersonelIsim.Caption = "Personel";
            this.clPersonelIsim.FieldName = "PersonelIsim";
            this.clPersonelIsim.Name = "clPersonelIsim";
            this.clPersonelIsim.OptionsColumn.AllowEdit = false;
            this.clPersonelIsim.OptionsColumn.AllowFocus = false;
            this.clPersonelIsim.Visible = true;
            this.clPersonelIsim.VisibleIndex = 5;
            // 
            // clKalemIsim
            // 
            this.clKalemIsim.Caption = "Kalem";
            this.clKalemIsim.FieldName = "KalemIsim";
            this.clKalemIsim.Name = "clKalemIsim";
            this.clKalemIsim.OptionsColumn.AllowEdit = false;
            this.clKalemIsim.OptionsColumn.AllowFocus = false;
            this.clKalemIsim.Visible = true;
            this.clKalemIsim.VisibleIndex = 8;
            // 
            // clOlayIsim
            // 
            this.clOlayIsim.Caption = "Olay";
            this.clOlayIsim.FieldName = "OlayIsim";
            this.clOlayIsim.Name = "clOlayIsim";
            this.clOlayIsim.OptionsColumn.AllowEdit = false;
            this.clOlayIsim.OptionsColumn.AllowFocus = false;
            this.clOlayIsim.Visible = true;
            this.clOlayIsim.VisibleIndex = 7;
            // 
            // clDevriye
            // 
            this.clDevriye.Caption = "Devriye";
            this.clDevriye.FieldName = "DevriyeIsim";
            this.clDevriye.Name = "clDevriye";
            this.clDevriye.OptionsColumn.AllowEdit = false;
            this.clDevriye.OptionsColumn.AllowFocus = false;
            this.clDevriye.Visible = true;
            this.clDevriye.VisibleIndex = 1;
            // 
            // clDevriyeTarihi
            // 
            this.clDevriyeTarihi.Caption = "Nokta Tarihi";
            this.clDevriyeTarihi.FieldName = "NoktaTarihi";
            this.clDevriyeTarihi.Name = "clDevriyeTarihi";
            this.clDevriyeTarihi.OptionsColumn.AllowEdit = false;
            this.clDevriyeTarihi.OptionsColumn.AllowFocus = false;
            this.clDevriyeTarihi.Visible = true;
            this.clDevriyeTarihi.VisibleIndex = 0;
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // OperasyonListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.panelControl1);
            this.Name = "OperasyonListesi";
            this.Size = new System.Drawing.Size(619, 343);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlDevriye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelView)).EndInit();
            this.tabCtrl.ResumeLayout(false);
            this.tabDevriye.ResumeLayout(false);
            this.tabNokta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOperasyonNokta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.PictureBox imgList;
        private System.Windows.Forms.Label lblList;
        private DevExpress.XtraGrid.GridControl grdCtrlDevriye;
        private DevExpress.XtraGrid.Views.Grid.GridView personelView;
        private DevExpress.XtraGrid.Columns.GridColumn clDevriyeGunu;
        private DevExpress.XtraGrid.Columns.GridColumn clDevriyeIsim;
        private DevExpress.XtraGrid.Columns.GridColumn clDevriyeSaati;
        private DevExpress.XtraGrid.Columns.GridColumn clOperasyonStatuIsim;
        private DevExpress.XtraGrid.Columns.GridColumn clPersonel;
        private DevExpress.XtraGrid.Columns.GridColumn clElleDegisim;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabDevriye;
        private System.Windows.Forms.TabPage tabNokta;
        private DevExpress.XtraGrid.GridControl grdOperasyonNokta;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSelected;
        private DevExpress.XtraGrid.Columns.GridColumn clStatu;
        private DevExpress.XtraGrid.Columns.GridColumn clNokta;
        private DevExpress.XtraGrid.Columns.GridColumn clNoktaSaat;
        private DevExpress.XtraGrid.Columns.GridColumn clOkumaSaat;
        private DevExpress.XtraGrid.Columns.GridColumn clPersonelIsim;
        private DevExpress.XtraGrid.Columns.GridColumn clKalemIsim;
        private DevExpress.XtraGrid.Columns.GridColumn clOlayIsim;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn clDevriye;
        private DevExpress.XtraGrid.Columns.GridColumn clDevriyeTarihi;
    }
}
