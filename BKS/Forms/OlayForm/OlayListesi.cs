using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKS.InfraStructure;
using BKS.Helper;
using System.Data.Entity;
using BKS.DataModel;
using BKS.DataModel.Model;

namespace BKS.Forms.OlayForm
{
    public partial class OlayListesi : BaseEntityList
    {
        public OlayListesi()
        {
            InitializeComponent();
        }

        protected override void LoadedAsync()
        {
            this.LoadData();
        }

        protected override void OpenSelected(object opened)
        {
            Olay olay = (Olay)opened;
            ShowEdit(olay.ID);
        }

        public override void NewCommand()
        {
            ShowEdit(null);
        }

        protected override void SilSelected(object[] selected)
        {
            this.RemoveListData<Olay>(selected);
           
        }

        #region Entity Process

        private void LoadData()
        {
            Application.UseWaitCursor = true;

            BKSEntities.DataContext.Olay.Load();
            var dataList = BKSEntities.DataContext.Olay.Local.ToBindingList();

            this.grdCtrl.SafeInvoke(() => { this.grdCtrl.DataSource = dataList; Application.UseWaitCursor = false; }, false);
        }

        void ShowEdit(int? ID)
        {
            OlayEdit editForm = (ID.HasValue) ? new OlayEdit(ID.Value) : new OlayEdit();
            editForm.ShowDialog();
            editForm.Dispose();
            editForm = null;
        }

        #endregion

    }
}
