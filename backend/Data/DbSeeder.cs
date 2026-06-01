using MediCare.Models;

namespace MediCare.Data;

public static class DbSeeder
{
    public static void Seed(MediCareContext db)
    {
        if (db.Chambres.Any()) return;

        var medecins = new[]
        {
            new Medecin { Nom = "Dr. Amine Bensaid", Specialite = "Cardiologie", Telephone = "0661-110011" },
            new Medecin { Nom = "Dr. Salma Cherkaoui", Specialite = "Chirurgie", Telephone = "0662-220022" },
            new Medecin { Nom = "Dr. Youssef Naciri", Specialite = "Pédiatrie", Telephone = "0663-330033" },
            new Medecin { Nom = "Dr. Hana Belkadi", Specialite = "Radiologie", Telephone = "0664-440044" },
        };
        db.Medecins.AddRange(medecins);

        var materiels = new[]
        {
            new Materiel { Nom = "Seringues", Stock = 1200, Seuil = 300, Unite = "u" },
            new Materiel { Nom = "Gants stériles", Stock = 80, Seuil = 100, Unite = "boîte" },
            new Materiel { Nom = "Compresses", Stock = 540, Seuil = 150, Unite = "u" },
            new Materiel { Nom = "Masques FFP2", Stock = 60, Seuil = 100, Unite = "u" },
            new Materiel { Nom = "Perfuseurs", Stock = 220, Seuil = 80, Unite = "u" },
        };
        db.Materiels.AddRange(materiels);

        var patients = new[]
        {
            new Patient { Nom = "Omar El Idrissi", Age = 58, Diagnostic = "Hypertension" },
            new Patient { Nom = "Fatima Zahra B.", Age = 34, Diagnostic = "Post-opératoire" },
            new Patient { Nom = "Yassine R.", Age = 7, Diagnostic = "Bronchiolite" },
        };
        db.Patients.AddRange(patients);
        db.SaveChanges();

        db.Chambres.AddRange(
            new Chambre { Numero = "C-101", Service = "Cardiologie", Statut = "OCCUPEE", PatientId = patients[0].Id },
            new Chambre { Numero = "C-102", Service = "Cardiologie", Statut = "LIBRE" },
            new Chambre { Numero = "CH-201", Service = "Chirurgie", Statut = "OCCUPEE", PatientId = patients[1].Id },
            new Chambre { Numero = "CH-202", Service = "Chirurgie", Statut = "LIBRE" },
            new Chambre { Numero = "PED-301", Service = "Pédiatrie", Statut = "OCCUPEE", PatientId = patients[2].Id },
            new Chambre { Numero = "PED-302", Service = "Pédiatrie", Statut = "LIBRE" }
        );

        db.Factures.AddRange(
            new Facture { Reference = "FAC-2026-001", PatientNom = "Omar El Idrissi", Montant = 4200m, Payee = false },
            new Facture { Reference = "FAC-2026-002", PatientNom = "Fatima Zahra B.", Montant = 8600m, Payee = true },
            new Facture { Reference = "FAC-2026-003", PatientNom = "Yassine R.", Montant = 1500m, Payee = false }
        );

        db.SaveChanges();
    }
}
