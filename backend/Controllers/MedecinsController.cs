using MediCare.Data;
using MediCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Controllers;

[ApiController]
[Route("api/medecins")]
public class MedecinsController : ControllerBase
{
    private readonly MediCareContext _db;
    public MedecinsController(MediCareContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> All() => Ok(await _db.Medecins.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Medecin m)
    {
        _db.Medecins.Add(m);
        await _db.SaveChangesAsync();
        return Ok(m);
    }
}
