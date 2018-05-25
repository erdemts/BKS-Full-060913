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

namespace BKS.Forms.NoktaForm
{
    public partial class NoktaListesi : BaseEntityList
    {
        public NoktaListesi()
        {
            InitializeComponent();
        }

        protected override void LoadedAsync()
        {
            this.LoadData<Nokta>();
        }

        protected override void OpenSelected(object opened)
        {
            this.ShowEdit<NoktaEdit>(((IEntity)opened).ID);
        }

        public override void NewCommand()
        {
            this.ShowEdit<NoktaEdit>(null);
        }


        protected override void SilSelected(object[] selected)
        {
            this.RemoveListData<Nokta>(selected);
        }

       

        public void SyncPoint()
        {

            var mainmenu = MainMenu.GetInstance();

            var device = mainmenu.HidDevice;

            if (!(mainmenu.IsDeviceAvailable && device.IsDeviceAttached))
            {
                MessageBox.Show(mainmenu, Messages.Sync_Wrn_Message, Messages.Sync_Wrn_Header, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult res_question = MessageBox.Show(mainmenu, Messages.Sync_Question_Message, Messages.Sync_Question_Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res_question == DialogResult.No)
                return;

            Action<BackroundProcessArg> method = (arg) =>
            {

                BKSEntities.DataContext.Nokta.Load();
                int cntPoint = BKSEntities.DataContext.Nokta.Local.Count;

                arg.SetMaximum(cntPoint + 1);

                #region Clean Device

                device.DeleteAllTag(BKSUSBDriver.TAG_TYPE.NODES);
                arg.UpdateProgress();

                #endregion

                foreach (var item in BKSEntities.DataContext.Nokta.Local)
                {

                    #region Add Device
                    int serino;
                    bool isInt = int.TryParse(item.SeriNo, out serino);
                    if (isInt)
                    {
                        bool isAdded = device.AddTag(BKSUSBDriver.TAG_TYPE.NODES, serino);
                    }

                    #endregion

                    arg.UpdateProgress();
                }

            };

            BackroundProcess.ShowAction(Messages.Operation_SyncTag, method);
        }
    }
}
