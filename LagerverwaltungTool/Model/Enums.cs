namespace LagerverwaltungTool.Model
{
    public enum NetzwerkTyp { LAN, WLAN }

    public enum ArtikelStatus
    {
        Verfuegbar,
        Ausgeliehen,
        Beschaedigt,
        Archiviert,
        Reserviert
    }

    public enum AntragStatus
    {
        Ausstehend,
        Genehmigt,
        Abgelehnt,
        Storniert
    }

    public enum UserRolle { Lernende, Admin, Gast }
}