using BKS.DataModel;
using BKS.DataModel.Model;
using BKS.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BKS.Forms.AlarmForm
{
    public partial class AlarmEdit : Form, BKS.InfraStructure.IEntityForm<Alarm>
    {
        public int ID { get; set; }

        public AlarmEdit()
        {
            InitializeComponent();
            
            //this.Load += LoadForm;
            this.Load += (sender, e) =>
            {

                this.chkHaftaGunleri.SetDayItems();

                this.LoadData<Alarm>();
            };

            this.btnOk.Click += (sender, e) =>
            {
                this.SaveEntity<Alarm>();
            };

            this.btnCancel.Click += (sender, e) =>
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            };
            
        }


        #region Get/Set Data

        public void GetData(Alarm alarm)
        {
            this.chkHaftaGunleri.SetEditValue(alarm.HaftaGunleri);
            this.tmBaslangic.EditValue = alarm.FormatedAlarmSaati;
            this.nmSure.Value = (alarm.Sure < 1 || alarm.Sure > 255) ? 1 : alarm.Sure;
            this.txtAciklama.Text = alarm.Aciklama;
        }

        public void SetData(Alarm alarm)
        {
            alarm.HaftaGunleri = (string)chkHaftaGunleri.EditValue;

            TimeSpan time = (this.tmBaslangic.EditValue is DateTime) ? ((DateTime)this.tmBaslangic.EditValue).TimeOfDay : (TimeSpan)this.tmBaslangic.EditValue;
            alarm.FormatedAlarmSaati = time;
            alarm.Sure = (int) nmSure.Value;
            alarm.Aciklama = this.txtAciklama.Text;

        }

        #endregion

    }
}
