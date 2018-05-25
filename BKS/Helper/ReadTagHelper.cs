using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BKS.Helper
{
    public static class ReadTagHelper
    {
        public static void Read(Form targetForm, Label lbl)
        {
            targetForm.Enabled = false;

            Action<Form> readTag = (form) =>
            {
                var mainmenu = MainMenu.GetInstance();

                if (mainmenu.HidDevice.IsDeviceAttached)
                {
                    mainmenu.HidDevice.Beep();

                    bool isTimeout;
                    int data = mainmenu.HidDevice.ReadTagNumber(out isTimeout);

                    if (isTimeout)
                    {
                        form.SafeInvoke(() =>
                            MessageBox.Show(form, Messages.ReadTag_Timeout_Message, Messages.ReadTag_Timeout_Header, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        , false);

                    }
                    else
                    {
                        lbl.SafeInvoke(() => lbl.Text = data.ToString(), false);
                        mainmenu.HidDevice.Beep();
                    }
                    
                }
                else
                {
                    form.SafeInvoke(() =>
                            MessageBox.Show(form, Messages.ReadTag_Wrn_Message, Messages.ReadTag_Wrn_Header, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        , false);
                }

                targetForm.SafeInvoke(() => targetForm.Enabled = true, false);
            };

            readTag.BeginInvoke(targetForm, null, null);
        }
    }
}
