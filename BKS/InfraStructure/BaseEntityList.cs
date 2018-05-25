using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKS.Helper;
using DevExpress.XtraGrid;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using BKS.DataModel;
using System.Reflection;
using BKS.Forms.GorunumForm;


namespace BKS.InfraStructure
{
    public class BaseEntityList : UserControl
    {
        public GridView grdView { get; set; }
        public GridControl grdCtrl { get; set; }

        public void OnLoad()
        {
            this.FindGridControl(this.Controls);
            this.LoadedAsync();
        }


        protected void FindGridControl(ControlCollection parent)
        {
            #region Dispose Old Control

            if (this.grdView != null)
            {
                grdView.DoubleClick -= grdView_DoubleClick;
                grdView = null;
            }
            if (this.grdCtrl != null)
                this.grdCtrl = null;
            
            #endregion

            this.grdCtrl = parent.FindControl<GridControl>();

            if (grdCtrl != null && grdCtrl.MainView is GridView)
            {
                grdView = (GridView)grdCtrl.MainView;
                grdView.DoubleClick += grdView_DoubleClick;
            }
        }

        protected virtual void LoadedAsync()
        {
            
        }
        
        #region Open

        public virtual void OpenCommand()
        {
           object selected =  GetSelectedRecord();

           if (selected != null)
               this.OpenSelected(selected);
        }

        void grdView_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);

            GridHitInfo info = view.CalcHitInfo(pt);

            if (info.InRow || info.InRowCell)
            {
                object selected = this.grdView.GetRow(info.RowHandle);
                if (selected != null)
                    this.OpenSelected(selected);
            }
        }

        protected virtual void OpenSelected(object opened)
        {

        }

        #endregion

        #region New

        public virtual void NewCommand()
        {
 
        }

        #endregion

        #region Sil

        public virtual void SilCommand()
        {
            int[] rows = this.grdView.GetSelectedRows();

            if (rows.Length == 0)
                return;

            DialogResult dialogResult = MessageBox.Show(this, Messages.Message_Delete_Msg, Messages.Message_Delete_Head, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.No)
                return;


            object[] list = new object[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                list[i] = this.grdView.GetRow(rows[i]);
            }

            this.SilSelected(list);
        }

        protected virtual void SilSelected(object[] opened)
        {

        }

        #endregion

        #region Arama

        public virtual void GelismisBul()
        {
            if (this.grdView == null)
                return;

            this.grdView.ShowFilterEditor(this.grdView.Columns[0]);
        }

        public virtual void HizliBul()
        {
            if (this.grdView == null)
                return;

            if (!this.grdView.IsFindPanelVisible)
                this.grdView.ShowFindPanel();
            else
                this.grdView.HideFindPanel();
        }

        public virtual void Gorunumler()
        {
            if (this.grdCtrl == null)
                return;


            GorunumListesi gorunumlistesi = new GorunumListesi();
            gorunumlistesi.Parent = this;

            DialogResult dlgResult = gorunumlistesi.ShowDialog(this);

            if (gorunumlistesi.chkOpenFilter.Checked)
                this.GelismisBul();
        }

        public virtual void FiltreyiKaldir()
        {
            if (this.grdView == null)
                return;

            this.grdView.ClearColumnsFilter();
        }

        #endregion

        #region Yazdir

        public virtual void YazdirCommand()
        {
            if (this.grdCtrl == null)
                return;

            this.grdCtrl.ShowRibbonPrintPreview();
        }

        #endregion

        #region Export/Import

        public virtual void DosyaAktar()
        {
            MessageBox.Show(this, Messages.Message_Dosya_Msg, Messages.Message_Dosya_Head, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public virtual void DosyaAl()
        {
            MessageBox.Show(this, Messages.Message_Dosya_Msg, Messages.Message_Dosya_Head, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion


        public object GetSelectedRecord()
        {
            int[] rows = this.grdView.GetSelectedRows();

            if (rows.Length > 0)
                return this.grdView.GetRow(rows[0]);
            else
                return null;
        }

        protected void ShowEdit<TForm>(int? ID) where TForm : Form
        {
            TForm editForm = Activator.CreateInstance<TForm>();
            
            if (ID.HasValue)
            {
                PropertyInfo propId = typeof(TForm).GetProperty("ID");
                propId.SetValue(editForm, ID.Value, null);
            }

            DialogResult diagResult =  editForm.ShowDialog();
            editForm.Dispose();
            editForm = null;

            if (diagResult == DialogResult.OK && this.grdCtrl != null)
                this.grdCtrl.RefreshDataSource();


            
        }

        protected void LoadData<TEntity>() where TEntity : class, IEntity
        {
            Application.UseWaitCursor = true;

            var dataList = BKSEntities.DataContext.ToBindingList<TEntity>();

            this.grdCtrl.SafeInvoke(() => { this.grdCtrl.DataSource = dataList; Application.UseWaitCursor = false; }, false);
        }

        protected void RemoveListData<TEntity>(object[] listentity) where TEntity : class, IEntity
        {
            Action<BackroundProcessArg> method = (arg) =>
            {
                arg.SetMaximum(listentity.Length);

                foreach (var entity in listentity)
                {
                    BKSEntities.DataContext.Remove<TEntity>((TEntity)entity);
                    arg.UpdateProgress();
                }
            };

            BackroundProcess.ShowAction(Messages.Delete_Records, method);

            
        }


      
    }
}
