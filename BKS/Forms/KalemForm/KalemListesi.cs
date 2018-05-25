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

namespace BKS.Forms.KalemForm
{
    public partial class KalemListesi : BaseEntityList
    {
        public KalemListesi()
        {
            InitializeComponent();
        }

        protected override void LoadedAsync()
        {
            this.LoadData<Kalem>();
        }

        protected override void OpenSelected(object opened)
        {
            this.ShowEdit<KalemEdit>(((IEntity)opened).ID);
        }

        public override void NewCommand()
        {
            this.ShowEdit<KalemEdit>(null);
        }

        protected override void SilSelected(object[] selected)
        {
            this.RemoveListData<Kalem>(selected);
        }

        
    }
}
