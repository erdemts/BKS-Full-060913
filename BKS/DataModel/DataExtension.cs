using BKS.DataModel;
using BKS.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace BKS.DataModel
{
    public static class DataExtension
    {

        public static string GetValidationErrorMessage(this Exception sender)
        {
            StringBuilder sb = new StringBuilder();

            if (sender is System.Data.Entity.Validation.DbEntityValidationException)
            {
                var valEx = sender as System.Data.Entity.Validation.DbEntityValidationException;
                foreach (var entry in valEx.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} :\n", entry.Entry.Entity.GetType().Name);
                    foreach (var error in entry.ValidationErrors)
                    {
                        sb.AppendLine(error.ErrorMessage);
                    }
                }
            }

            return sb.ToString();
        }

        public static string GetAnahtarTipiText(this AnahtarTipi sender)
        {
            return Messages.ResourceManager.GetString(string.Format("AnahtarTipi_{0}", sender.ToString()));
        }

        public static string GetOperasyonStatuText(this OperasyonStatu sender)
        {
            return Messages.ResourceManager.GetString(string.Format("OperasyonStatu_{0}", sender.ToString()));
        }

        public static ObservableCollection<TEntity> ToObservableCollection<TEntity>(this ICollection<TEntity> list)
        {
            ObservableCollection<TEntity> tempList = new ObservableCollection<TEntity>();

            if (list == null)
                return tempList;

            foreach (var item in list)
            {
                tempList.Add(item);
            }

            return tempList;
        }

        public static bool Validate<TEntity>(this TEntity entity, out string message) where TEntity : class
        {
            DbEntityEntry entry = BKSEntities.DataContext.Entry<TEntity>(entity);
            var valResult = entry.GetValidationResult();
            
            message = String.Join(Environment.NewLine, valResult.ValidationErrors.Select(err => err.ErrorMessage).ToArray());

            if (!valResult.IsValid && entry.State == EntityState.Modified)
                entry.Reload();

            return valResult.IsValid;
                    
        }

        public static string GetErrorsAndDiscardChanges(this DbContext context)
        {
            StringBuilder messages = new StringBuilder();
            IEnumerable<DbEntityValidationResult> valResults = context.GetValidationErrors();
            
            foreach (var result in valResults)
            {
                foreach (var error in result.ValidationErrors)
                {
                    //messages.AppendLine(string.Format("{0}: {1}", error.PropertyName, error.ErrorMessage));
                    messages.AppendLine(error.ErrorMessage);
                }

                if (result.Entry.State != EntityState.Added)
                    result.Entry.Reload();
            }

            return messages.ToString();

        }

    }
}
