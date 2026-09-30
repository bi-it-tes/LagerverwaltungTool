using System.ComponentModel.DataAnnotations;



namespace LagerverwaltungTool.Model
{
    public class ArtikelModel
    {
        [Key]
        public int ART_ID { get; set; }
        public string Bezeichnung { get; set; } = string.Empty;
        public string? Hostname { get; set; }
        public string? IPAdresse { get; set; }
        public bool IstStatisch { get; set; }
        public string? MACAdresse { get; set; }
        public NetzwerkTyp? Netz { get; set; }
        public string? Ort { get; set; }

        public int? BesitzerId { get; set; }
        public UserModel? Besitzer { get; set; }

        public int KategorieId { get; set; }
        public KategorieModel Kategorie { get; set; } = null!;

        public ArtikelStatus Status { get; set; } = ArtikelStatus.Verfuegbar;
        public string? Notizen { get; set; }
        public DateTime Erfassungsdatum { get; set; } = DateTime.Now;

        public ICollection<AusleihArtikelModel> AusleihArtikel { get; set; } = new List<AusleihArtikelModel>();
    }
}