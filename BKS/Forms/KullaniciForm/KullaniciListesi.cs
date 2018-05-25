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

namespace BKS.Forms.KullaniciForm
{
    public partial class KullaniciListesi : BaseEntityList
    {
        public KullaniciListesi()
        {
            InitializeComponent();
        }

        protected override void LoadedAsync()
        {
            this.LoadData<Kullanici>();
        }

        protected override void OpenSelected(object opened)
        {
            this.ShowEdit<KullaniciEdit>(((IEntity)opened).ID);
        }

        public override void NewCommand()
        {
            this.ShowEdit<KullaniciEdit>(null);
        }

        
        protected override void SilSelected(object[] selected)
        {
            this.RemoveListData<Kullanici>(selected);
           
        }

        
    }
}
