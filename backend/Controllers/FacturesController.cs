using MediCare.Data;
using MediCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Controllers;

[ApiController]
[Route("api/factures")]
public class FacturesController : ControllerBase
{
    private readonly MediCareContext _db;
    public FacturesController(MediCareContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> All() =>
        Ok(await _db.Factures.OrderByDescending(f => f.DateEmission).ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Facture f)
    {
        f.Reference = "FAC-" + DateTime.UtcNow.Year + "-" + Random.Shared.Next(100, 999);
        _db.Factures.Add(f);
        await _db.SaveChangesAsync();
        return Ok(f);
    }

    [HttpPost("{id}/payer")]
    public async Task<IActionResult> Payer(int id)
    {
        var f = await _db.Factures.FindAsync(id);
        if (f is null) return NotFound();
        f.Payee = true;
        await _db.SaveChangesAsync();
        return Ok(f);
    }
}
