using MediCare.Data;
using MediCare.Dtos;
using MediCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Controllers;

[ApiController]
[Route("api/materiel")]
public class StockController : ControllerBase
{
    private readonly MediCareContext _db;
    public StockController(MediCareContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> All() => Ok(await _db.Materiels.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Materiel m)
    {
        _db.Materiels.Add(m);
        await _db.SaveChangesAsync();
        return Ok(m);
    }

    // Décrémente le stock lors de l'utilisation de matériel
    [HttpPost("{id}/utiliser")]
    public async Task<IActionResult> Utiliser(int id, UtiliserMaterielDto dto)
    {
        var m = await _db.Materiels.FindAsync(id);
        if (m is null) return NotFound();
        if (m.Stock < dto.Quantite) return BadRequest(new { error = "Stock insuffisant" });
        m.Stock -= dto.Quantite;
        await _db.SaveChangesAsync();
        return Ok(m);
    }

    [HttpPost("{id}/reappro")]
    public async Task<IActionResult> Reappro(int id, UtiliserMaterielDto dto)
    {
        var m = await _db.Materiels.FindAsync(id);
        if (m is null) return NotFound();
        m.Stock += dto.Quantite;
        await _db.SaveChangesAsync();
        return Ok(m);
    }
}
