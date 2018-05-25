namespace BKS.Forms.OkumaBilgisiForm
{
    partial class OkumaBilgisiListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OkumaBilgisiListesi));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.imgList = new System.Windows.Forms.PictureBox();
            this.lblList = new System.Windows.Forms.Label();
            this.grdCtrl = new DevExpress.XtraGrid.GridControl();
            this.personelView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clIslemTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clIslemSaati = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clPersonel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNoktaIsim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clOlayIsim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKalemIsim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clEslesme = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelView)).BeginInit();
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
            this.lblList.Size = new System.Drawing.Size(167, 23);
            this.lblList.TabIndex = 0;
            this.lblList.Text = "Veri Transferi";
            this.lblList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdCtrl
            // 
            this.grdCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrl.Location = new System.Drawing.Point(0, 30);
            this.grdCtrl.MainView = this.personelView;
            this.grdCtrl.Name = "grdCtrl";
            this.grdCtrl.Size = new System.Drawing.Size(619, 313);
            this.grdCtrl.TabIndex = 1;
            this.grdCtrl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.personelView});
            // 
            // personelView
            // 
            this.personelView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clIslemTarihi,
            this.clIslemSaati,
            this.clPersonel,
            this.clNoktaIsim,
            this.clOlayIsim,
            this.clKalemIsim,
            this.clEslesme});
            this.personelView.GridControl = this.grdCtrl;
            this.personelView.Name = "personelView";
            this.personelView.OptionsCustomization.AllowFilter = false;
            this.personelView.OptionsSelection.MultiSelect = true;
            this.personelView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            // 
            // clIslemTarihi
            // 
            this.clIslemTarihi.Caption = "Tarih";
            this.clIslemTarihi.FieldName = "Tarih";
            this.clIslemTarihi.Name = "clIslemTarihi";
            this.clIslemTarihi.OptionsColumn.AllowEdit = false;
            this.clIslemTarihi.OptionsColumn.AllowFocus = false;
            this.clIslemTarihi.Visible = true;
            this.clIslemTarihi.VisibleIndex = 0;
            // 
            // clIslemSaati
            // 
            this.clIslemSaati.Caption = "Saat";
            this.clIslemSaati.FieldName = "Saat";
            this.clIslemSaati.Name = "clIslemSaati";
            this.clIslemSaati.OptionsColumn.AllowEdit = false;
            this.clIslemSaati.OptionsColumn.AllowFocus = false;
            this.clIslemSaati.Visible = true;
            this.clIslemSaati.VisibleIndex = 1;
            // 
            // clPersonel
            // 
            this.clPersonel.Caption = "Personel";
            this.clPersonel.FieldName = "PersonelIsim";
            this.clPersonel.Name = "clPersonel";
            this.clPersonel.OptionsColumn.AllowEdit = false;
            this.clPersonel.OptionsColumn.AllowFocus = false;
            this.clPersonel.Visible = true;
            this.clPersonel.VisibleIndex = 2;
            // 
            // clNoktaIsim
            // 
            this.clNoktaIsim.Caption = "Nokta";
            this.clNoktaIsim.FieldName = "NoktaIsim";
            this.clNoktaIsim.Name = "clNoktaIsim";
            this.clNoktaIsim.OptionsColumn.AllowEdit = false;
            this.clNoktaIsim.OptionsColumn.AllowFocus = false;
            this.clNoktaIsim.Visible = true;
            this.clNoktaIsim.VisibleIndex = 3;
            // 
            // clOlayIsim
            // 
            this.clOlayIsim.Caption = "Olay";
            this.clOlayIsim.FieldName = "OlayIsim";
            this.clOlayIsim.Name = "clOlayIsim";
            this.clOlayIsim.OptionsColumn.AllowEdit = false;
            this.clOlayIsim.OptionsColumn.AllowFocus = false;
            this.clOlayIsim.Visible = true;
            this.clOlayIsim.VisibleIndex = 4;
            // 
            // clKalemIsim
            // 
            this.clKalemIsim.Caption = "Kalem";
            this.clKalemIsim.FieldName = "KalemIsim";
            this.clKalemIsim.Name = "clKalemIsim";
            this.clKalemIsim.OptionsColumn.AllowEdit = false;
            this.clKalemIsim.OptionsColumn.AllowFocus = false;
            this.clKalemIsim.Visible = true;
            this.clKalemIsim.VisibleIndex = 5;
            // 
            // clEslesme
            // 
            this.clEslesme.Caption = "Eşleşme";
            this.clEslesme.FieldName = "IsEslesme";
            this.clEslesme.Name = "clEslesme";
            this.clEslesme.OptionsColumn.AllowEdit = false;
            this.clEslesme.OptionsColumn.AllowFocus = false;
            this.clEslesme.Visible = true;
            this.clEslesme.VisibleIndex = 6;
            // 
            // OkumaBilgisiListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdCtrl);
            this.Controls.Add(this.panelControl1);
            this.Name = "OkumaBilgisiListesi";
            this.Size = new System.Drawing.Size(619, 343);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.PictureBox imgList;
        private System.Windows.Forms.Label lblList;
        private DevExpress.XtraGrid.GridControl grdCtrl;
        private DevExpress.XtraGrid.Views.Grid.GridView personelView;
        private DevExpress.XtraGrid.Columns.GridColumn clIslemTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn clIslemSaati;
        private DevExpress.XtraGrid.Columns.GridColumn clNoktaIsim;
        private DevExpress.XtraGrid.Columns.GridColumn clKalemIsim;
        private DevExpress.XtraGrid.Columns.GridColumn clEslesme;
        private DevExpress.XtraGrid.Columns.GridColumn clPersonel;
        private DevExpress.XtraGrid.Columns.GridColumn clOlayIsim;
    }
}
