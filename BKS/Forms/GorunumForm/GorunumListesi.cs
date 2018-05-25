using BKS.DataModel;
using BKS.DataModel.Model;
using BKS.InfraStructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BKS.Forms.GorunumForm
{
    public partial class GorunumListesi : Form
    {

        public new BaseEntityList Parent { get; set; }

        public string GorunumTipi
        {
            get
            {
                return this.Parent.GetType().Name;
            }
        }

        public GorunumListesi()
        {
            InitializeComponent();

            this.Load += GorunumListesi_Load;
        }

        void GorunumListesi_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Application.UseWaitCursor = true;

            var dataList = from item in BKSEntities.DataContext.Gorunum
                           orderby item.GorunumAdi
                           where item.GorunumTipi == this.GorunumTipi
                           select item;

            this.itemImgList.Items.Clear();

            foreach (var dataitem in dataList)
            {
                this.itemImgList.Items.Add(new DevExpress.XtraEditors.Controls.ImageListBoxItem(dataitem, 0));
            }

            Application.UseWaitCursor = false;
        }
       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SetView();
        }

        private void itemImgList_DoubleClick(object sender, EventArgs e)
        {
            SetView();
        }

        private void SetView()
        {
            if (this.itemImgList.SelectedItem == null && this.itemImgList.SelectedItem is DevExpress.XtraEditors.Controls.ImageListBoxItem)
                return;

            Gorunum gorunum = (Gorunum)((DevExpress.XtraEditors.Controls.ImageListBoxItem)this.itemImgList.SelectedItem).Value;

            using (MemoryStream str = new MemoryStream(gorunum.GorunumData))
            {
                this.Parent.grdCtrl.FocusedView.RestoreLayoutFromStream(str);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #region Gorunum Islemleri

        private void brBtnRename_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.itemImgList.SelectedItem == null && this.itemImgList.SelectedItem is DevExpress.XtraEditors.Controls.ImageListBoxItem)
                return;

            Gorunum gorunum = (Gorunum)((DevExpress.XtraEditors.Controls.ImageListBoxItem)this.itemImgList.SelectedItem).Value;

            GorunumEdit gorunumedit = new GorunumEdit();
            gorunumedit.txtName.Text = gorunum.GorunumAdi;

            DialogResult result = gorunumedit.ShowDialog(this);

            if (result != System.Windows.Forms.DialogResult.OK)
                return;
            Application.UseWaitCursor = true;

            gorunum.GorunumAdi = gorunumedit.txtName.Text;

            string message = string.Empty;
            bool IsValid = gorunum.Validate(out message);

            if (IsValid)
            {
                BKSEntities.DataContext.SaveChanges();
                LoadData();
            }
            else
                MessageBox.Show(this, message, Messages.Message_Error_Head, MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.UseWaitCursor = false;
        }

        private void brBtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.itemImgList.SelectedItem == null && this.itemImgList.SelectedItem is DevExpress.XtraEditors.Controls.ImageListBoxItem)
                return;


            DialogResult result =  MessageBox.Show(this, Messages.Message_Delete_Msg, Messages.Message_Delete_Head, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            Gorunum gorunum = (Gorunum)((DevExpress.XtraEditors.Controls.ImageListBoxItem)this.itemImgList.SelectedItem).Value;

            BKSEntities.DataContext.Gorunum.Remove(gorunum);
            BKSEntities.DataContext.SaveChanges();

            LoadData();

        }

        private void ddlButton_Click(object sender, EventArgs e)
        {
            GorunumEdit gorunumedit = new GorunumEdit();
            DialogResult result =  gorunumedit.ShowDialog(this);

            if (result != System.Windows.Forms.DialogResult.OK)
                return;

            Application.UseWaitCursor = true;

            byte[] buffer = null;

            using (MemoryStream str = new MemoryStream())
            {
                this.Parent.grdCtrl.FocusedView.SaveLayoutToStream(str);
                buffer = str.ToArray();
            }

            if (buffer != null)
            {
                Gorunum gorunum = new Gorunum();
                gorunum.GorunumAdi = gorunumedit.txtName.Text;
                gorunum.GorunumTipi = this.GorunumTipi;
                gorunum.GorunumData = buffer;

                string message = string.Empty;
                bool IsValid = gorunum.Validate(out message);

                if (IsValid)
                {
                    BKSEntities.DataContext.Gorunum.Add(gorunum);
                    BKSEntities.DataContext.SaveChanges();

                    LoadData();
                }
                else
                    MessageBox.Show(this, message, Messages.Message_Error_Head, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.UseWaitCursor = false;
            }

        }

        #endregion

        

    }
}
