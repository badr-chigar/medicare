namespace MediCare.Models;

public class Chambre
{
    public int Id { get; set; }
    public string Numero { get; set; } = "";
    public string Service { get; set; } = "";   // Cardiologie, Chirurgie, ...
    public string Statut { get; set; } = "LIBRE"; // LIBRE | OCCUPEE

    public int? PatientId { get; set; }
    public Patient? Patient { get; set; }
}
