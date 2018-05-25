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

namespace BKS.Forms.DevriyeForm
{
    public partial class DevriyeListesi : BaseEntityList
    {
        public DevriyeListesi()
        {
            InitializeComponent();
        }

        protected override void LoadedAsync()
        {
            this.LoadData<Devriye>();
        }

        protected override void OpenSelected(object opened)
        {
            this.ShowEdit<DevriyeEdit>(((IEntity)opened).ID);
        }

        public override void NewCommand()
        {
            this.ShowEdit<DevriyeEdit>(null);
        }

        
        protected override void SilSelected(object[] selected)
        {
            this.RemoveListData<Devriye>(selected);
           
        }
        
    }
}
