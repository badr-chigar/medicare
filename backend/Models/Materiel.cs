namespace MediCare.Models;

public class Materiel
{
    public int Id { get; set; }
    public string Nom { get; set; } = "";
    public int Stock { get; set; }
    public int Seuil { get; set; }
    public string Unite { get; set; } = "u";
}
