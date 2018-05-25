
using BKSUSBDriver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace BKS
{
    public partial class Form1 : Form
    {

        HIDConnector device = null;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;


            device = new HIDConnector();
            device.UsbChanged += device_UsbChanged;
            
            
            device.Connect();
        }

        
        
        void Form1_Load(object sender, EventArgs e)
        {
            ViewStatus();
        }

        void device_UsbChanged(object sender, EventArgs e)
        {
            ViewStatus();
        }

        private void ViewStatus()
        {
            if (device.IsDeviceAttached)
                this.lblStatusUSB.Text = "Device Attached";
            else
                this.lblStatusUSB.Text = "Device Not Found";
        }


       



        private void btnSend_Click(object sender, EventArgs e)
        {

            
            
            device.Beep();

            var weekdays = Enum.GetValues(typeof(DayOfWeek));


            foreach (var day in weekdays)
            {
                bool result = device.CleanAlarms((DayOfWeek)day);
            }

            //bool result2 =device.AddAlarms(DateTime.Now.DayOfWeek,DateTime.Now.AddMinutes(1).TimeOfDay);
        }

      

    }
}