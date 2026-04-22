namespace TMPP.Structural.Flyweight;

// Flyweight - obiectul partajat care contine datele intrinseci ale unui medicament.
// Aceste date NU se schimba de la o prescriptie la alta si pot fi reutilizate.
public class MedicamentSpec
{
    // Date intrinseci (partajate intre toate prescriptiile cu acelasi medicament)
    public string Nume { get; }
    public string SubstantaActiva { get; }
    public string Categorie { get; }
    public string EfecteSecundare { get; }

    public MedicamentSpec(string nume, string substantaActiva, string categorie, string efecteSecundare)
    {
        Nume = nume;
        SubstantaActiva = substantaActiva;
        Categorie = categorie;
        EfecteSecundare = efecteSecundare;
    }

    public void AfiseazaSpecificatii()
    {
        Console.WriteLine($"    [Spec] {Nume} | Substanta: {SubstantaActiva} | Categorie: {Categorie} | Efecte: {EfecteSecundare}");
    }
}
