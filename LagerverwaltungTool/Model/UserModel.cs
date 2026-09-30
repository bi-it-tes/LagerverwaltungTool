namespace LagerverwaltungTool.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Benutzername { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswortHash { get; set; } = string.Empty;
        public UserRolle Rolle { get; set; } = UserRolle.Gast;

        public ICollection<AusleihAntragModel> Antraege { get; set; } = new List<AusleihAntragModel>();
    }
}