using LagerverwaltungTool.Model;
using Microsoft.AspNetCore.Identity;

namespace LagerverwaltungTool.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            // Check: is Tabelle Empthy = true, then add default data
            if (!db.Kategorien.Any())
            {
                db.Kategorien.AddRange(
                    new KategorieModel { Name = "Einplatinencomputer & Mikrocontroller" },
                    new KategorieModel { Name = "Notebooks & Tablets" },
                    new KategorieModel { Name = "Smartphones" },
                    new KategorieModel { Name = "Bildschirme & Peripherie" },
                    new KategorieModel { Name = "IoT-Geräte" },
                    new KategorieModel { Name = "Zubehör" },
                    new KategorieModel { Name = "Verbrauchsmaterial" }
                 );
            }

            if (!db.Users.Any())
            {
                var hasher = new PasswordHasher<UserModel>();

                var anna = new UserModel { Benutzername = "Anna Müller", Email = "anna.müller@psi.ch", Rolle = UserRolle.Admin };
                var lars = new UserModel { Benutzername = "Lars Lernende", Email = "lars.lernende@psi.ch", Rolle = UserRolle.Lernende };
                var peter = new UserModel { Benutzername = "Peter Hans", Email = "peter.hans@psi.ch", Rolle = UserRolle.Gast };

                anna.PasswortHash = hasher.HashPassword(anna, "PasswordAnna");
                lars.PasswortHash = hasher.HashPassword(lars, "PasswordLars");
                peter.PasswortHash = hasher.HashPassword(peter, "PasswordPeter");

                db.Users.AddRange(anna, lars, peter);
            }
            db.SaveChanges();

            // Are Users and Kategorien seeded? If yes, then seed Artikel
            // Test Data for Artikel, only if no Artikel exist 
            if (!db.Artikel.Any())
            {
                var notebooks = db.Kategorien.First(k => k.Name == "Notebooks & Tablets");
                var einplatinen = db.Kategorien.First(k => k.Name == "Einplatinencomputer & Mikrocontroller");
                var zubehoer = db.Kategorien.First(k => k.Name == "Zubehör");
                var lars = db.Users.First(u => u.Rolle == UserRolle.Lernende);

                db.Artikel.AddRange(
                    new ArtikelModel
                    {
                        Bezeichnung = "Dell Latitude 5440",
                        Hostname = "lt-lern-01",
                        IPAdresse = "192.168.10.21",
                        IstStatisch = true,
                        MACAdresse = "00:1A:2B:3C:4D:5E",
                        Netz = NetzwerkTyp.LAN,
                        Ort = "OBBA",
                        Kategorie = notebooks,
                        Besitzer = lars
                    },
                    new ArtikelModel
                    {
                        Bezeichnung = "Raspberry Pi 4",
                        Hostname = "rpi-lern-01",
                        IPAdresse = "192.168.10.22",
                        IstStatisch = false,
                        MACAdresse = "DC:A6:32:11:22:33",
                        Netz = NetzwerkTyp.WLAN,
                        Ort = "OBBA",
                        Kategorie = einplatinen,
                        Status = ArtikelStatus.Beschaedigt,
                    },
                    new ArtikelModel
                    {
                        Bezeichnung = "USB-C Netzteil 65W",
                        Ort = "WBBA",
                        Kategorie = zubehoer
                    }
                );

                db.SaveChanges();
            }
        }
    }
}