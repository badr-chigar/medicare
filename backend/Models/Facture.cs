namespace MediCare.Models;

public class Facture
{
    public int Id { get; set; }
    public string Reference { get; set; } = "";
    public string PatientNom { get; set; } = "";
    public decimal Montant { get; set; }
    public bool Payee { get; set; }
    public DateTime DateEmission { get; set; } = DateTime.UtcNow;
}
