using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Reflection;

namespace BKS.DataModel.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class UniqueValueAttribute : ValidationAttribute
    {
        public UniqueValueAttribute()
            : base("{0} alanına girilen bilgi tekil olmalıdır.")
        {
            
        }

        //public UniqueValueAttribute(string TableName)
        //    : this()
        //{
        //    this.TableName = TableName;
        //}

        //public string TableName { get; private set; }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name);
        }


        string GetTableName(Type targetType)
        {
            PropertyInfo propStorage = typeof(BKSEntities).GetProperties().FirstOrDefault(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericArguments()[0] == targetType);
            if (propStorage == null)
                return null;
            else
                return propStorage.Name;
        }


        protected override ValidationResult IsValid(object propValue, ValidationContext validationContext)
        {
            

            IEntity entity = validationContext.ObjectInstance as IEntity;

            if (entity == null)
                throw new Exception("Unique Attribute IEntity Tipinde class için kullanılmalıdır.");

            string TableName = GetTableName(validationContext.ObjectType);
            if (string.IsNullOrEmpty(TableName))
                TableName = GetTableName(validationContext.ObjectType.BaseType);

            if (string.IsNullOrEmpty(TableName))
                throw new Exception("UniqueValueAttribute icinde Table olusturulamadi");

            string Sql = string.Format("Select Case When Exists(Select 1 from {0} Where {1} = {{0}} And ID<>{{1}}) Then 1 Else 0 End As Res", TableName, validationContext.MemberName);

            IEnumerable<int> values = BKSEntities.DataContext.Database.SqlQuery<int>(Sql, new object[] { propValue, entity.ID });

            int result = values.FirstOrDefault();

            if (result == 1)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }

        
    }
}
