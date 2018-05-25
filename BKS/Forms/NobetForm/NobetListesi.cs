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

namespace BKS.Forms.NobetForm
{
    public partial class NobetListesi : BaseEntityList
    {
        public NobetListesi()
        {
            InitializeComponent();
        }

        protected override void LoadedAsync()
        {
            this.LoadData<Nobet>();
        }

        protected override void OpenSelected(object opened)
        {
            this.ShowEdit<NobetEdit>(((IEntity)opened).ID);
        }

        public override void NewCommand()
        {
            this.ShowEdit<NobetEdit>(null);
        }

        protected override void SilSelected(object[] selected)
        {
            this.RemoveListData<Nobet>(selected);
        }

        
    }
}
