using BKS.DataModel.CustomAttribute;
using BKS.DataModel.Model;
using BKS.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BKS.DataModel
{
    public class BKSEntities :  DbContext
    {
        public BKSEntities()
            : base("BKSEntities")
        {

            //this.Configuration.ValidateOnSaveEnabled = false;
        }

        public DbSet<Anahtar> Anahtar { get; set; }
        public DbSet<Devriye> Devriye { get; set; }
        public DbSet<DevriyeNokta> DevriyeNokta { get; set; }
        public DbSet<Kalem> Kalem { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Nokta> Nokta { get; set; }
        public DbSet<OkumaBilgisi> OkumaBilgisi { get; set; }
        public DbSet<Olay> Olay { get; set; }
        public DbSet<Operasyon> Operasyon { get; set; }
        public DbSet<OperasyonNokta> OperasyonNokta { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Nobet> Nobet { get; set; }
        public DbSet<Gorunum> Gorunum { get; set; }
        public DbSet<Alarm> Alarm { get; set; }
        public DbSet<LisansBilgisi> LisansBilgisi { get; set; }
        
        #region Generic Method

        public void Remove<TEntity>(TEntity obj) where TEntity : class, IEntity
        {

            if (obj is Operasyon)
            {
                Operasyon opr = obj as Operasyon;

                opr.OperasyonNokta.ToList().ForEach((on) =>
                    {
                        this.OperasyonNokta.Remove(on);
                    }
                );
                this.Operasyon.Remove(opr);
            }
            else
            {
                DbSet<TEntity> propStorage = GetStorageProperty<TEntity>();
                propStorage.Remove(obj);

                BKSEntities.DataContext.SaveChanges();
            }
            
        }

        public void Add<TEntity>(TEntity obj) where TEntity : class, IEntity
        {
            DbSet<TEntity> propStorage = GetStorageProperty<TEntity>();
            
            //if (threadSafe)
            //{
            //    Form form = (Form.ActiveForm != null) ? Form.ActiveForm : Application.OpenForms[0];
            //    form.SafeInvoke(() => propStorage.Add(obj), true);
            //}
            //else
            propStorage.Add(obj);
        }


        DbSet<TEntity>  GetStorageProperty<TEntity>() where TEntity : class, IEntity
        {
            PropertyInfo propStorage = typeof(BKSEntities).GetProperties().FirstOrDefault(p => p.PropertyType == typeof(DbSet<TEntity>));
            DbSet<TEntity> objStorage = (DbSet<TEntity>)propStorage.GetValue(BKSEntities.DataContext, null);

            return objStorage;
        }


        public BindingList<TEntity> ToBindingList<TEntity>() where TEntity : class, IEntity
        {
            DbSet<TEntity> propStorage = GetStorageProperty<TEntity>();
            propStorage.Load();
            return propStorage.Local.ToBindingList();
        }

        public TEntity Find<TEntity>(int id) where TEntity : class, IEntity
        {
            
            DbSet<TEntity> propStorage = GetStorageProperty<TEntity>();
            TEntity obj = propStorage.Find(id);
            return obj;
        }

       

        public void CancelChanges<TEntity>() where TEntity : class, IEntity
        {
            var items = this.ChangeTracker.Entries<TEntity>();

            DbSet<TEntity> propStorage = GetStorageProperty<TEntity>();

            foreach (var item in items)
            {
                if (item.State == EntityState.Added)
                    propStorage.Remove(item.Entity);
                else if (item.State == EntityState.Modified)
                    item.Reload();
            }
        }

        public override int SaveChanges()
        {
            var items = this.ChangeTracker.Entries<Author>();

            foreach (var item in items)
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.Olusturan = Program.ApplicationUser;
                    item.Entity.Olusturma = DateTime.Now;
                }
                else if (item.State == EntityState.Modified)
                {
                    item.Entity.Degistiren = Program.ApplicationUser;
                    item.Entity.Degistirme = DateTime.Now;
                }

            }
            
            return base.SaveChanges();
        }

        #endregion


        #region DataContext

        private static BKSEntities _dataContext;
        private static readonly object lockObj = new object();
        public static BKSEntities DataContext
        {
            get
            {
                lock (lockObj)
                {
                    if (_dataContext == null)
                        _dataContext = new BKSEntities();
                }

                return _dataContext;
            }

        }

        #endregion

        #region Configuration


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //WillCascadeOnDelete=> false : Sadece Referansı Siler, true : iliskili kaydisiler.

            //Anahtar: One To One
            modelBuilder.Entity<Anahtar>().HasOptional(p => p.Personel).WithOptionalDependent(d => d.Anahtar).WillCascadeOnDelete(true);
            modelBuilder.Entity<Olay>().HasMany(p => p.AnahtarBilgisi).WithOptional(d => d.Olay).WillCascadeOnDelete(true);

            //OkumaBilgisi
            modelBuilder.Entity<OkumaBilgisi>().HasOptional(p => p.Kalem).WithMany(p => p.OkumaBilgisi).WillCascadeOnDelete(false);
            modelBuilder.Entity<OkumaBilgisi>().HasOptional(p => p.Nokta).WithMany(p => p.OkumaBilgisi).WillCascadeOnDelete(false);
            modelBuilder.Entity<OkumaBilgisi>().HasOptional(p => p.Personel).WithMany(p => p.OkumaBilgisi).WillCascadeOnDelete(true);
            modelBuilder.Entity<OkumaBilgisi>().HasOptional(p => p.Olay).WithMany(p => p.OkumaBilgisi).WillCascadeOnDelete(false);
            modelBuilder.Entity<OkumaBilgisi>().HasOptional(p => p.OperasyonNokta).WithMany(p => p.OkumaBilgisi).WillCascadeOnDelete(false);


            //Devriye
            modelBuilder.Entity<Devriye>().HasOptional(p => p.Personel).WithMany(x => x.Devriye).WillCascadeOnDelete(false);

            // DevriyeNokta
            modelBuilder.Entity<DevriyeNokta>().HasRequired(p => p.Devriye).WithMany(p => p.DevriyeNokta).WillCascadeOnDelete(true);
            modelBuilder.Entity<DevriyeNokta>().HasRequired(p => p.Nokta).WithMany(p => p.DevriyeNokta).WillCascadeOnDelete(true);

            //Operasyon
            modelBuilder.Entity<Operasyon>().HasOptional(p => p.Personel).WithMany(x => x.Operasyon).WillCascadeOnDelete(false);
            modelBuilder.Entity<Operasyon>().HasOptional(p => p.Devriye).WithMany(x => x.Operasyon).WillCascadeOnDelete(true);

            //OperayonNokta
            modelBuilder.Entity<OperasyonNokta>().HasRequired(p => p.Operasyon).WithMany(x => x.OperasyonNokta).WillCascadeOnDelete(true);
            modelBuilder.Entity<OperasyonNokta>().HasOptional(p => p.Nokta).WithMany(x => x.OperasyonNokta).WillCascadeOnDelete(false);
            modelBuilder.Entity<OperasyonNokta>().HasOptional(p => p.Kalem).WithMany(x => x.OperasyonNokta).WillCascadeOnDelete(false);
            modelBuilder.Entity<OperasyonNokta>().HasOptional(p => p.Personel).WithMany(x => x.OperasyonNokta).WillCascadeOnDelete(false);
            modelBuilder.Entity<OperasyonNokta>().HasOptional(p => p.Olay).WithMany(x => x.OperasyonNokta).WillCascadeOnDelete(false);
            


            //Nobet
            modelBuilder.Entity<Nobet>().HasRequired(p => p.Personel).WithMany(x => x.Nobet).WillCascadeOnDelete(true);

            //if (!File.Exists("BKSData.sdf"))
            //Database.SetInitializer(new BKSDatabaseInitializer());
            

            base.OnModelCreating(modelBuilder);
        }



        #endregion

       
    }
}
