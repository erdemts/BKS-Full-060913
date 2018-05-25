
using BKS.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BKS.Helper
{
    public class ContentManager
    {

        private Thread loadThread { get; set; }
        private BaseEntityList listContent { get; set; }
        private Control container {get;set;}

        public ContentManager(Control container)
        {
            this.container = container;
        }


      

        
    }
}
