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

namespace BKS.Forms.AnahtarForm
{
    public partial class AnahtarListesi : BaseEntityList
    {
        public AnahtarListesi()
        {
            InitializeComponent();
        }

        protected override void LoadedAsync()
        {
            this.LoadData<Anahtar>();
        }

        protected override void OpenSelected(object opened)
        {
            this.ShowEdit<AnahtarEdit>(((IEntity)opened).ID);
        }

        public override void NewCommand()
        {
            this.ShowEdit<AnahtarEdit>(null);
        }

        
        protected override void SilSelected(object[] selected)
        {
            this.RemoveListData<Anahtar>(selected);
        }


        public void SyncTag()
        {

            var mainmenu = MainMenu.GetInstance();

            var device = mainmenu.HidDevice;

            if (!(mainmenu.IsDeviceAvailable && device.IsDeviceAttached))
            {
                MessageBox.Show(mainmenu, Messages.Sync_Wrn_Message, Messages.Sync_Wrn_Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult res_question = MessageBox.Show(mainmenu, Messages.Sync_Question_Message, Messages.Sync_Question_Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res_question == DialogResult.No)
                return;

            int usercapacity = mainmenu.HidDevice.GetTagCapacity(BKSUSBDriver.TAG_TYPE.USERS);
            int eventcapacity = mainmenu.HidDevice.GetTagCapacity(BKSUSBDriver.TAG_TYPE.EVENT);

            Action<BackroundProcessArg> method = (arg) =>
            {

                BKSEntities.DataContext.Anahtar.Load();
                int cntTag = BKSEntities.DataContext.Anahtar.Local.Count;

                arg.SetMaximum(cntTag+2);

                #region Clean Device
 
                device.DeleteAllTag(BKSUSBDriver.TAG_TYPE.EVENT);
                arg.UpdateProgress();
                device.DeleteAllTag(BKSUSBDriver.TAG_TYPE.USERS);
                arg.UpdateProgress();

                #endregion

                foreach (var item in BKSEntities.DataContext.Anahtar.Local)
                {

                    #region Add Device

                    int serino;
                    bool isInt = int.TryParse(item.SeriNo, out serino);

                    if (isInt)
                    {

                        if (item.AnahtarTipi == AnahtarTipi.Personel)
                        {
                            var result = device.AddTag(BKSUSBDriver.TAG_TYPE.USERS, serino);
                        }
                        else if (item.AnahtarTipi == AnahtarTipi.Olay)
                        {
                            var result = device.AddTag(BKSUSBDriver.TAG_TYPE.EVENT, serino);
                        }
                    }

                    #endregion

                    arg.UpdateProgress();
                }
            };

            BackroundProcess.ShowAction(Messages.Operation_SyncTag, method);
        }

        
    }
}
