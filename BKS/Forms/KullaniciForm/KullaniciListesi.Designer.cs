namespace BKS.Forms.KullaniciForm
{
    partial class KullaniciListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciListesi));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.imgList = new System.Windows.Forms.PictureBox();
            this.lblList = new System.Windows.Forms.Label();
            this.grdCtrl = new DevExpress.XtraGrid.GridControl();
            this.personelView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clAdiSoyadi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKullaniciAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clIsGiris = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.lblList.Size = new System.Drawing.Size(100, 23);
            this.lblList.TabIndex = 0;
            this.lblList.Text = "Kullanıcılar";
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
            this.clAdiSoyadi,
            this.clKullaniciAdi,
            this.clIsGiris});
            this.personelView.GridControl = this.grdCtrl;
            this.personelView.Name = "personelView";
            // 
            // clAdiSoyadi
            // 
            this.clAdiSoyadi.Caption = "Adı Soyadi";
            this.clAdiSoyadi.FieldName = "AdiSoyadi";
            this.clAdiSoyadi.Name = "clAdiSoyadi";
            this.clAdiSoyadi.OptionsColumn.AllowEdit = false;
            this.clAdiSoyadi.OptionsColumn.AllowFocus = false;
            this.clAdiSoyadi.OptionsFilter.AllowAutoFilter = false;
            this.clAdiSoyadi.OptionsFilter.AllowFilter = false;
            this.clAdiSoyadi.Visible = true;
            this.clAdiSoyadi.VisibleIndex = 0;
            // 
            // clKullaniciAdi
            // 
            this.clKullaniciAdi.Caption = "Kullanıcı Adı";
            this.clKullaniciAdi.FieldName = "KullaniciAdi";
            this.clKullaniciAdi.Name = "clKullaniciAdi";
            this.clKullaniciAdi.OptionsColumn.AllowEdit = false;
            this.clKullaniciAdi.OptionsColumn.AllowFocus = false;
            this.clKullaniciAdi.OptionsFilter.AllowAutoFilter = false;
            this.clKullaniciAdi.OptionsFilter.AllowFilter = false;
            this.clKullaniciAdi.Visible = true;
            this.clKullaniciAdi.VisibleIndex = 1;
            // 
            // clIsGiris
            // 
            this.clIsGiris.Caption = "Giriş";
            this.clIsGiris.FieldName = "IsGiris";
            this.clIsGiris.Name = "clIsGiris";
            this.clIsGiris.OptionsColumn.AllowEdit = false;
            this.clIsGiris.OptionsColumn.AllowFocus = false;
            this.clIsGiris.OptionsFilter.AllowAutoFilter = false;
            this.clIsGiris.OptionsFilter.AllowFilter = false;
            this.clIsGiris.Visible = true;
            this.clIsGiris.VisibleIndex = 2;
            // 
            // KullaniciListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdCtrl);
            this.Controls.Add(this.panelControl1);
            this.Name = "KullaniciListesi";
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
        private DevExpress.XtraGrid.Columns.GridColumn clAdiSoyadi;
        private DevExpress.XtraGrid.Columns.GridColumn clKullaniciAdi;
        private DevExpress.XtraGrid.Columns.GridColumn clIsGiris;
    }
}
