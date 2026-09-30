using Microsoft.EntityFrameworkCore;
using LagerverwaltungTool.Model;

namespace LagerverwaltungTool.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ArtikelModel> Artikel { get; set; }
        public DbSet<KategorieModel> Kategorien { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AusleihAntragModel> AusleihAntraege { get; set; }
        public DbSet<AusleihArtikelModel> AusleihArtikel { get; set; }
        public DbSet<ChangeLogModel> ChangeLogs { get; set; }
    }
}