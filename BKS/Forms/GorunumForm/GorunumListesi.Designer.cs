namespace BKS.Forms.GorunumForm
{
    partial class GorunumListesi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GorunumListesi));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddlButton = new DevExpress.XtraEditors.DropDownButton();
            this.ppMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.brBtnRename = new DevExpress.XtraBars.BarButtonItem();
            this.brBtnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.brMngr = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.itemImgList = new DevExpress.XtraEditors.ImageListBoxControl();
            this.chkOpenFilter = new DevExpress.XtraEditors.CheckEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ppMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brMngr)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemImgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOpenFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddlButton);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ddlButton
            // 
            this.ddlButton.DropDownControl = this.ppMenu;
            this.ddlButton.ImageIndex = 3;
            this.ddlButton.ImageList = this.imgList;
            this.ddlButton.Location = new System.Drawing.Point(12, 12);
            this.ddlButton.Name = "ddlButton";
            this.ddlButton.Size = new System.Drawing.Size(122, 23);
            this.ddlButton.TabIndex = 2;
            this.ddlButton.Text = "Yeni Görünüm";
            this.ddlButton.Click += new System.EventHandler(this.ddlButton_Click);
            // 
            // ppMenu
            // 
            this.ppMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.brBtnRename),
            new DevExpress.XtraBars.LinkPersistInfo(this.brBtnDelete, true)});
            this.ppMenu.Manager = this.brMngr;
            this.ppMenu.Name = "ppMenu";
            // 
            // brBtnRename
            // 
            this.brBtnRename.Caption = "Yeniden Adlandır";
            this.brBtnRename.Id = 1;
            this.brBtnRename.ImageIndex = 2;
            this.brBtnRename.Name = "brBtnRename";
            this.brBtnRename.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.brBtnRename_ItemClick);
            // 
            // brBtnDelete
            // 
            this.brBtnDelete.Caption = "Görünümü Sil";
            this.brBtnDelete.Id = 2;
            this.brBtnDelete.ImageIndex = 1;
            this.brBtnDelete.Name = "brBtnDelete";
            this.brBtnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.brBtnDelete_ItemClick);
            // 
            // brMngr
            // 
            this.brMngr.DockControls.Add(this.barDockControlTop);
            this.brMngr.DockControls.Add(this.barDockControlBottom);
            this.brMngr.DockControls.Add(this.barDockControlLeft);
            this.brMngr.DockControls.Add(this.barDockControlRight);
            this.brMngr.Form = this;
            this.brMngr.Images = this.imgList;
            this.brMngr.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.brBtnRename,
            this.brBtnDelete});
            this.brMngr.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(425, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 207);
            this.barDockControlBottom.Size = new System.Drawing.Size(425, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 207);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(425, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 207);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "SavedView_16.png");
            this.imgList.Images.SetKeyName(1, "DeleteView.gif");
            this.imgList.Images.SetKeyName(2, "ico_16_dev.png");
            this.imgList.Images.SetKeyName(3, "Save.png");
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Yeni Görünüm Ekle";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(338, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(257, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Uygula";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.itemImgList);
            this.groupBox2.Controls.Add(this.chkOpenFilter);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 163);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // itemImgList
            // 
            this.itemImgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemImgList.ImageList = this.imgList;
            this.itemImgList.Location = new System.Drawing.Point(3, 16);
            this.itemImgList.Name = "itemImgList";
            this.itemImgList.Size = new System.Drawing.Size(419, 125);
            this.itemImgList.TabIndex = 0;
            this.itemImgList.DoubleClick += new System.EventHandler(this.itemImgList_DoubleClick);
            // 
            // chkOpenFilter
            // 
            this.chkOpenFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkOpenFilter.Location = new System.Drawing.Point(3, 141);
            this.chkOpenFilter.MenuManager = this.brMngr;
            this.chkOpenFilter.Name = "chkOpenFilter";
            this.chkOpenFilter.Properties.Caption = "Filtre Penceresi Açılsın";
            this.chkOpenFilter.Size = new System.Drawing.Size(419, 19);
            this.chkOpenFilter.TabIndex = 1;
            // 
            // GorunumListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 207);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GorunumListesi";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Görünüm Listesi";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ppMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brMngr)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemImgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOpenFilter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.DropDownButton ddlButton;
        private System.Windows.Forms.ImageList imgList;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.ImageListBoxControl itemImgList;
        private DevExpress.XtraBars.PopupMenu ppMenu;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem brBtnRename;
        private DevExpress.XtraBars.BarButtonItem brBtnDelete;
        private DevExpress.XtraBars.BarManager brMngr;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraEditors.CheckEdit chkOpenFilter;


    }
}