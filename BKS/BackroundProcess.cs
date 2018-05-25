using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKS.Helper;

namespace BKS
{
    public partial class BackroundProcess : Form
    {
        private Action<BackroundProcessArg> Method { get; set; }
        private BackgroundWorker _backgroundWorker { get; set; }


        public BackroundProcess()
        {
            InitializeComponent();

            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerReportsProgress = true;

            _backgroundWorker.DoWork += (sender, e) =>
            {
                try
                {
                    if (Method != null)
                        Method(new BackroundProcessArg(this.progBar, this._backgroundWorker));
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            _backgroundWorker.RunWorkerCompleted += (sender, e) =>
            {
                Close();

                if (e.Result is Exception)
                {
                    Exception ex = (Exception)e.Result;
                    string message = ex.GetDeepMessage();
                    MessageBox.Show(message, Messages.Message_Error_Head, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //else if (CallBack != null)
                //{
                //    CallBack();
                //}
            };

            _backgroundWorker.ProgressChanged += (sender, e) =>
            {
                this.progBar.PerformStep();
                this.progBar.Update();
            };


            this.Load += (sender, e) =>
            {
                this._backgroundWorker.RunWorkerAsync();
            };

        }

     
        public static void ShowAction(string processMsg, Action<BackroundProcessArg> action)
        {
            BackroundProcess form = new BackroundProcess();
            form.lblProcess.Text = processMsg;
            form.Method = action;
            form.ShowDialog();
        }

    }

    public class BackroundProcessArg
    {
        private DevExpress.XtraEditors.ProgressBarControl progBar;
        private BackgroundWorker _backgroundWorker { get; set; }

        public BackroundProcessArg(DevExpress.XtraEditors.ProgressBarControl progBar,BackgroundWorker _backgroundWorker )
        {
            this.progBar = progBar;
            this._backgroundWorker = _backgroundWorker;
        }

        public void SetMaximum(int MaximumVal)
        {
            this.progBar.SafeInvoke(()=> this.progBar.Properties.Maximum = MaximumVal,true);
        }

        public void UpdateProgress()
        {
            _backgroundWorker.ReportProgress(1);
        }
    }
}
