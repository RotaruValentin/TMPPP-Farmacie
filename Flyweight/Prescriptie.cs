namespace TMPP.Structural.Flyweight;

// Context (date extrinseci) - fiecare prescriptie are date unice (pacient, cantitate, data expirare)
// dar partajeaza specificatia medicamentului (flyweight-ul) cu alte prescriptii.
public class Prescriptie
{
    // Referinta catre flyweight-ul partajat (datele intrinseci)
    private readonly MedicamentSpec _spec;

    // Date extrinseci (unice pentru fiecare prescriptie)
    public string NumePacient { get; }
    public int Cantitate { get; }
    public DateTime DataExpirare { get; }

    public Prescriptie(MedicamentSpec spec, string numePacient, int cantitate, DateTime dataExpirare)
    {
        _spec = spec;
        NumePacient = numePacient;
        Cantitate = cantitate;
        DataExpirare = dataExpirare;
    }

    public void Afiseaza()
    {
        Console.WriteLine($"  Prescriptie: Pacient={NumePacient}, Cantitate={Cantitate}, Expira={DataExpirare:dd.MM.yyyy}");
        _spec.AfiseazaSpecificatii();
    }
}
