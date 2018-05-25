using BKS.DataModel;
using BKS.DataModel.Model;
using BKS.InfraStructure;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace BKS.Helper
{
    public static class Extension
    {

        public static string GetSelectedDayNames(string selecteddays)
        {
            string[] days = selecteddays.Split(',');

            List<string> dayNames = new List<string>();

            foreach (var day in days)
            {
                string dayName = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.GetDayName((DayOfWeek)int.Parse(day));
                dayNames.Add(dayName);
            }

            return (dayNames.Any()) ? String.Join(", ", dayNames) : string.Empty;
        }

        public static void SetDayItems(this DevExpress.XtraEditors.CheckedComboBoxEdit chkHaftaGunleri)
        {
            var days = Enum.GetValues(typeof(DayOfWeek));

            int firstindex = (int)System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.FirstDayOfWeek;

            for (int i = 0; i < days.Length; i++)
            {
                int index = (firstindex + i) % 7;

                var item = days.GetValue(index);

                string text = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.GetDayName((DayOfWeek)item);
                int value = (int)item;
                chkHaftaGunleri.Properties.Items.Add(new DevExpress.XtraEditors.Controls.CheckedListBoxItem(value, text));
            }
        }


        public static string GetDeepMessage(this Exception ex)
        {
            string msg = string.Empty;

            if (ex.InnerException != null)
                msg = ex.InnerException.GetDeepMessage();
            else
                msg = ex.Message;

            return msg;
        }

        #region Form Extension
        public static void LoadData<TEntity>(this IEntityForm<TEntity> form) where TEntity : class, IEntity
        {
            Application.UseWaitCursor = true;

            ((Form)form).SafeInvoke(() =>
                {
                    TEntity entity = (form.ID > 0) ? BKSEntities.DataContext.Find<TEntity>(form.ID) : Activator.CreateInstance<TEntity>();
                    form.GetData(entity);

                    Application.UseWaitCursor = false;
                }, false);
            
        }

        public static TEntity SaveEntity<TEntity>(this IEntityForm<TEntity> form, TEntity saved_entity = null) where TEntity : class, IEntity
        {
            Application.UseWaitCursor = true;

            bool IsValid = false;
            string ex_message = "";

            TEntity entity = (saved_entity != null) ? saved_entity :  Activator.CreateInstance<TEntity>();
            entity.ID = form.ID;
            form.SetData(entity);

            IsValid = ((IEntity)entity).Validate(out ex_message);

            if (IsValid && form.ID > 0)
            {
                TEntity original = BKSEntities.DataContext.Find<TEntity>(form.ID);
                form.SetData(original);
            }
            else if (IsValid)
            {
                BKSEntities.DataContext.Add<TEntity>(entity);
            }

            //TEntity entity = (saved_entity!=null) ? saved_entity : (form.ID > 0) ? BKSEntities.DataContext.Find<TEntity>(form.ID) : Activator.CreateInstance<TEntity>();
            //form.SetData(entity);
            //IsValid = ((IEntity)entity).Validate(out ex_message);

            //if (IsValid && entity.ID < 1)
            //    BKSEntities.DataContext.Add<TEntity>(entity);

            Action save = () =>
                {
                    try
                    {
                        if (IsValid)
                            BKSEntities.DataContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ex_message = ex.Message;
                    }
                };

           IAsyncResult async= save.BeginInvoke(null,null);

           async.AsyncWaitHandle.WaitOne();

           Application.UseWaitCursor = false;

           if (!IsValid)
               MessageBox.Show(((Form)form), ex_message, Messages.Message_Error_Head, MessageBoxButtons.OK, MessageBoxIcon.Error);

           if (IsValid)
               ((Form)form).DialogResult = System.Windows.Forms.DialogResult.OK;

           return entity;
        }

       

        #endregion

        #region Control

        public static T FindControl<T>(this Control.ControlCollection startFrom)
        {
            foreach (object child in startFrom)
            {
                if (child.GetType().IsAssignableFrom(typeof(T)))
                {
                    return (T)child;
                }
                else
                {
                    return FindControl<T>(((Control)child).Controls);
                }
            }
            return default(T);
        }

        public static void SafeInvoke(this Control uiElement, Action updater, bool forceSynchronous)
        {
            if (uiElement == null)
            {
                throw new ArgumentNullException("SafeInvoke Error");
            }

            if (uiElement.InvokeRequired)
            {
              
                
                if (forceSynchronous)
                {
                    uiElement.Invoke((Action)delegate { SafeInvoke(uiElement, updater, forceSynchronous); });
                }

                else
                {
                    uiElement.BeginInvoke((Action)delegate { SafeInvoke(uiElement, updater, forceSynchronous); });
                }
            }
            else
            {
                if (!uiElement.IsHandleCreated)
                {
                    // Do nothing if the handle isn't created already.  The user's responsible
                    // for ensuring that the handle they give us exists.
                    return;
                }

                if (uiElement.IsDisposed)
                {
                    throw new ObjectDisposedException("Control is already disposed.");
                }

                updater();
            }

        }

        #endregion

        #region Combobox
        
        public static void AddParameters(this ComboBoxEdit combobox, List<ParametreItem> paramList)
        {
            combobox.SafeInvoke(() =>
            {
                combobox.Properties.DropDownItemHeight = 20;

                ComboBoxItemCollection coll = combobox.Properties.Items;
                coll.BeginUpdate();
                try
                {
                    paramList.ForEach(p => coll.Add(p));
                }
                finally
                {
                    coll.EndUpdate();
                }

            }, true);
        }

        #endregion


        #region Lookup

        public static void LookupInit(this LookUpEdit lookup, string  DisplayName,LookUpColumnInfo[] columns)
        {
            
            lookup.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            lookup.Properties.DisplayMember = DisplayName;
            lookup.Properties.DropDownItemHeight = 20;
            lookup.Properties.NullText = "";
            lookup.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick;

            lookup.Properties.Buttons.Clear();

            // new DevExpress.Utils.SerializableAppearanceObject()
            lookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, false, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Delete),null, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, BKS.Properties.Resources.lkp_search , new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), null, "", null, null, true)});

            lookup.Properties.ActionButtonIndex = 1;

            lookup.Properties.Columns.Clear();
            columns.ToList().ForEach(column => lookup.Properties.Columns.Add(column));

            lookup.ButtonClick += (sender, e) =>
                {
                    if (e.Button.Index == 0)
                    {
                        ((LookUpEdit)sender).EditValue = null;
                    }
                };

            lookup.EditValueChanged += (sender, e) =>
                 {
                     ((LookUpEdit)sender).Properties.Buttons[0].Enabled = (((LookUpEdit)sender).EditValue != null);
                 };
        }
        #endregion
    }
}
