using System.ComponentModel.DataAnnotations;


namespace LagerverwaltungTool.Model
{
    public class AusleihAntragModel
    {

        [Key]
        public int REQ_ID { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; } = null!;

        public string Begruendung { get; set; } = string.Empty;
        public AntragStatus Status { get; set; } = AntragStatus.Ausstehend;
        public string? Notizen { get; set; }
        public DateTime Erstellungsdatum { get; set; } = DateTime.Now;

        // Rückgabe (ANF-16)
        public DateTime? RueckgabeDatum { get; set; }
        public string? RueckgabeNotizen { get; set; }

        public ICollection<AusleihArtikelModel> Artikel { get; set; } = new List<AusleihArtikelModel>();
    }
}