using BKS.DataModel.Model;
using BKS.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace BKS.DataModel
{
    public class BKSDatabaseConfiguration : DbMigrationsConfiguration<BKSEntities>
    {
        public BKSDatabaseConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(BKSEntities context)
        {
            #region Default Value



            //#region Personel

            //List<Personel> listPersonel = new List<Personel>() { 
            //            new Personel(){ Adi = "Kenan", Soyadi = "Kaplan", SicilNo="123", },
            //            new Personel(){ Adi = "Filiz", Soyadi = "Kaplan", SicilNo="124"},
            //            new Personel(){ Adi = "Zeynep", Soyadi = "Kaplan", SicilNo="125"},
            //    };

            //if (!context.Personel.Any())
            //{
            //    listPersonel.ForEach(p => context.Personel.Add(p));
            //}

            //#endregion

            //#region Kalem
            //if (!context.Kalem.Any())
            //{
            //    List<Kalem> listKalem = new List<Kalem>() { 
            //        new Kalem(){ Isim="Kalem I", SeriNo ="001" },
            //        };

            //    listKalem.ForEach(p => context.Kalem.Add(p));
            //}

            //#endregion

            //#region Anahtar
            //if (!context.Anahtar.Any())
            //{
            //    List<Anahtar> listAnahtar = new List<Anahtar>() { 
            //            new Anahtar(){ Aciklama="Anatahtar I", SeriNo ="001" , AnahtarTipi=AnahtarTipi.Personel , Personel = listPersonel.First() },
            //    };

            //    listAnahtar.ForEach(p => context.Anahtar.Add(p));
            //}
            //#endregion

            //#region Nokta
            //if (!context.Nokta.Any())
            //{
            //    new List<Nokta>() { 
            //            new Nokta(){ SeriNo="123", Isim="Nokta 1"},
            //            new Nokta(){ SeriNo="125", Isim="Nokta 2"},
            //            new Nokta(){ SeriNo="124", Isim="Nokta 3"},
            //    }.ForEach(p => context.Nokta.Add(p));
            //}
            //#endregion

            //#region Parameter

            ////new List<Parametre>() { 
            ////        new Parametre(){ ParametreGrubu=ParametreGrubu.AnahtarTipi.ToString(), ParametreAdi="Personel", ParametreKodu=1 },
            ////        new Parametre(){ ParametreGrubu=ParametreGrubu.AnahtarTipi.ToString(), ParametreAdi="Olay", ParametreKodu=2 },
            ////}.ForEach(p => context.Parametre.Add(p));

            //#endregion

            #endregion


            #region Olay Tanim

            if (!context.Olay.Any())
            {
                new List<Olay>() { 
                        new Olay(){ OlayKodu="OLY001", Aciklama="Genel Vukaat", IsSistem=true},
                        }.ForEach(p => context.Olay.Add(p));
            }

            #endregion

            #region User

            if (!context.Kullanici.Any())
            {
                Kullanici system = new Kullanici();
                system.KullaniciAdi = DataModel.Model.Kullanici.SystemUser;
                system.AdiSoyadi = "Sistem";
                system.IsGiris = false;

                context.Kullanici.Add(system);

                Kullanici admin = new Kullanici();
                admin.KullaniciAdi = DataModel.Model.Kullanici.AdminUser;
                admin.AdiSoyadi = "Sistem Yöneticisi";
                admin.Parola = CyrptoTool.CyrptoText("admin");
                admin.IsGiris = true;

                context.Kullanici.Add(admin);
            }

            #endregion

            context.SaveChanges();
        }

    }
}
