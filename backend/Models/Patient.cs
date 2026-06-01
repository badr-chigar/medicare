namespace MediCare.Models;

public class Patient
{
    public int Id { get; set; }
    public string Nom { get; set; } = "";
    public int Age { get; set; }
    public string? Diagnostic { get; set; }
    public DateTime DateAdmission { get; set; } = DateTime.UtcNow;
}
