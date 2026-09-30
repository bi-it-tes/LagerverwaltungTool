using System.ComponentModel.DataAnnotations.Schema;

namespace LagerverwaltungTool.Model
{
    public class AusleihArtikelModel
    {
        public int Id { get; set; }

        public int ART_ID { get; set; }
        [ForeignKey(nameof(ART_ID))]
        public ArtikelModel Artikel { get; set; } = null!;

        public int REQ_ID { get; set; }
        [ForeignKey(nameof(REQ_ID))]
        public AusleihAntragModel Antrag { get; set; } = null!;

        public int Anzahl { get; set; } = 1;
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
    }
}