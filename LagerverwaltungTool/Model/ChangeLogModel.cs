namespace LagerverwaltungTool.Model
{
    public class ChangeLogModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public UserModel? User { get; set; }

        public string Tabelle { get; set; } = string.Empty;
        public int EintragId { get; set; }
        public string Aktion { get; set; } = string.Empty;   //  "Erstellt", "Geändert", "Gelöscht"
        public string? Details { get; set; }
        public DateTime Zeitpunkt { get; set; } = DateTime.Now;
    }
}