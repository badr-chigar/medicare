using MediCare.Data;
using MediCare.Dtos;
using MediCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Controllers;

[ApiController]
[Route("api/chambres")]
public class ChambresController : ControllerBase
{
    private readonly MediCareContext _db;
    public ChambresController(MediCareContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> All() =>
        Ok(await _db.Chambres.Include(c => c.Patient).ToListAsync());

    // Admettre un patient dans une chambre libre
    [HttpPost("{id}/admettre")]
    public async Task<IActionResult> Admettre(int id, AffecterPatientDto dto)
    {
        var ch = await _db.Chambres.FindAsync(id);
        if (ch is null) return NotFound();
        if (ch.Statut == "OCCUPEE") return BadRequest(new { error = "Chambre déjà occupée" });

        var patient = new Patient { Nom = dto.PatientNom, Age = dto.Age, Diagnostic = dto.Diagnostic };
        _db.Patients.Add(patient);
        await _db.SaveChangesAsync();

        ch.PatientId = patient.Id;
        ch.Statut = "OCCUPEE";
        await _db.SaveChangesAsync();
        return Ok(ch);
    }

    // Libérer une chambre
    [HttpPost("{id}/liberer")]
    public async Task<IActionResult> Liberer(int id)
    {
        var ch = await _db.Chambres.FindAsync(id);
        if (ch is null) return NotFound();
        ch.PatientId = null;
        ch.Statut = "LIBRE";
        await _db.SaveChangesAsync();
        return Ok(ch);
    }
}
