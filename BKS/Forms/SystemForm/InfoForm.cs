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

namespace BKS.Forms.SystemForm
{
    public partial class InfoForm : Form
    {
        public int ID { get; set; }

        public InfoForm()
        {
            InitializeComponent();

            this.Load += (sender, e) =>
                        {
                            
                        };

            this.btnOk.Click += (sender, e) =>
                                {
                                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                };

        
        }

        
    }
}
