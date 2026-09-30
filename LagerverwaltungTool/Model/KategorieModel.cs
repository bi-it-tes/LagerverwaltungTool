namespace LagerverwaltungTool.Model
{
    public class KategorieModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<ArtikelModel> Artikel { get; set; } = new List<ArtikelModel>();
    }
}