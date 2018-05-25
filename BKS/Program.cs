using BKS.DataModel;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BKSUSBDriver;
using BKS.DataModel.Model;

namespace BKS
{
    static class Program
    {

        public static Kullanici ApplicationUser = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

            WelcomeScreen wel = new WelcomeScreen();
            DialogResult dlgRslt =  wel.ShowDialog();

           


            if (dlgRslt == DialogResult.OK && Program.ApplicationUser != null)
                Application.Run(new MainMenu());

        }
    }
}
