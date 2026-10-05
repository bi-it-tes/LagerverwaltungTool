using System.Security.Claims;
using LagerverwaltungTool.Model;
using Microsoft.AspNetCore.Components.Authorization;


namespace LagerverwaltungTool.Data
{
    public class ChangeLogService
    {
        private readonly AppDbContext _db;
        private readonly AuthenticationStateProvider _auth;

        public ChangeLogService(AppDbContext db, AuthenticationStateProvider auth)
        {
            _db = db;
            _auth = auth;
        }   

        public async Task LogAsync(string tabelle, int eintragId, string aktion, string? details = null)
        {
            var state = await _auth.GetAuthenticationStateAsync();
            var idText = state.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int? userId = int.TryParse(idText, out var id) ? id : null;

            _db.ChangeLogs.Add(new ChangeLogModel
            {
                UserId = userId,
                Tabelle = tabelle,
                EintragId = eintragId,
                Aktion = aktion,
                Details = details,
                Zeitpunkt = DateTime.Now
            });

            await _db.SaveChangesAsync();
        }
    }
}
