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

namespace BKS.Forms.AlarmForm
{
    public partial class AlarmListesi : BaseEntityList
    {
        public AlarmListesi()
        {
            InitializeComponent();
        }

        protected override void LoadedAsync()
        {
            this.LoadData<Alarm>();
        }

        protected override void OpenSelected(object opened)
        {
            this.ShowEdit<AlarmEdit>(((IEntity)opened).ID);
        }

        public override void NewCommand()
        {
            this.ShowEdit<AlarmEdit>(null);
        }


        protected override void SilSelected(object[] selected)
        {
            this.RemoveListData<Alarm>(selected);
        }

       

        public void SyncAlarm()
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

                BKSEntities.DataContext.Alarm.Load();
                int cntPoint = BKSEntities.DataContext.Alarm.Local.Count;
                var weekdays = Enum.GetValues(typeof(DayOfWeek));


                arg.SetMaximum(cntPoint + weekdays.Length);

                #region Clean Device

                foreach (var day in weekdays)
                {
                    bool result = device.CleanAlarms((DayOfWeek)day);
                }
                
                arg.UpdateProgress();

                #endregion

                foreach (var alarm in BKSEntities.DataContext.Alarm.Local)
                {

                    #region Add Device
                   
                    string[] days = alarm.HaftaGunleri.Split(',');

                    foreach (var day in days)
	                {
                        bool isAdded = device.AddAlarms((DayOfWeek)int.Parse(day), alarm.FormatedAlarmSaati.Hours, alarm.FormatedAlarmSaati.Minutes, alarm.Sure);
	                }

                    #endregion

                    arg.UpdateProgress();
                }

            };

            BackroundProcess.ShowAction(Messages.Operation_SyncAlarm, method);
        }
    }
}
