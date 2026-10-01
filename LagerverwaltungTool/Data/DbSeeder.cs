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
        }
    }
}