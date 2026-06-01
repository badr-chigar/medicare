using MediCare.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Controllers;

[ApiController]
[Route("api/stats")]
public class StatsController : ControllerBase
{
    private readonly MediCareContext _db;
    public StatsController(MediCareContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var totalChambres = await _db.Chambres.CountAsync();
        var occupees = await _db.Chambres.CountAsync(c => c.Statut == "OCCUPEE");
        var taux = totalChambres > 0 ? (int)Math.Round(occupees * 100.0 / totalChambres) : 0;
        var caImpaye = await _db.Factures.Where(f => !f.Payee).SumAsync(f => (decimal?)f.Montant) ?? 0;
        var caTotal = await _db.Factures.SumAsync(f => (decimal?)f.Montant) ?? 0;
        var ruptures = await _db.Materiels.CountAsync(m => m.Stock <= m.Seuil);

        return Ok(new
        {
            chambres = totalChambres,
            occupees,
            tauxOccupation = taux,
            patients = occupees,
            chiffreAffaires = caTotal,
            impaye = caImpaye,
            rupturesStock = ruptures,
            medecins = await _db.Medecins.CountAsync()
        });
    }
}
