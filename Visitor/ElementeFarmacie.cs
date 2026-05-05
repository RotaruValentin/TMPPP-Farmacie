namespace TMPP.Behavioral.Visitor;

// Informatii despre un medicament stocat intr-un element al farmaciei
public class MedicamentStocat
{
    public string Nume { get; set; }
    public decimal PretAchizitie { get; set; }
    public decimal PretVanzare { get; set; }
    public int Cantitate { get; set; }
    public DateTime DataExpirare { get; set; }

    public MedicamentStocat(string nume, decimal pretAchizitie, decimal pretVanzare, int cantitate, DateTime dataExpirare)
    {
        Nume = nume;
        PretAchizitie = pretAchizitie;
        PretVanzare = pretVanzare;
        Cantitate = cantitate;
        DataExpirare = dataExpirare;
    }

    public bool EsteExpirat() => DateTime.Now > DataExpirare;
    public bool ExpiraInCurand() => !EsteExpirat() && (DataExpirare - DateTime.Now).TotalDays <= 90;
}

// ConcreteElement 1 - Raft de medicamente OTC (fara reteta)
public class RaftMedicamente : IElementFarmacie
{
    public string NumeElement => $"Raft Medicamente OTC - {NumeRaft}";
    public string NumeRaft { get; }
    public List<MedicamentStocat> Medicamente { get; } = new();

    public RaftMedicamente(string numeRaft)
    {
        NumeRaft = numeRaft;
    }

    public void AdaugaMedicament(MedicamentStocat med)
    {
        Medicamente.Add(med);
    }

    public void Accepta(IVizitatorFarmacie vizitator)
    {
        vizitator.Viziteaza(this);
    }
}

// ConcreteElement 2 - Frigider pentru medicamente termosensibile
public class FrigiderMedicamente : IElementFarmacie
{
    public string NumeElement => $"Frigider Medicamente - {NumeFrigider}";
    public string NumeFrigider { get; }
    public decimal TemperaturaActuala { get; set; } // in grade Celsius
    public decimal TemperaturaMinima { get; } = 2.0m;
    public decimal TemperaturaMaxima { get; } = 8.0m;
    public List<MedicamentStocat> Medicamente { get; } = new();

    public FrigiderMedicamente(string numeFrigider, decimal temperaturaActuala)
    {
        NumeFrigider = numeFrigider;
        TemperaturaActuala = temperaturaActuala;
    }

    public void AdaugaMedicament(MedicamentStocat med)
    {
        Medicamente.Add(med);
    }

    public bool TemperaturaConforma() =>
        TemperaturaActuala >= TemperaturaMinima && TemperaturaActuala <= TemperaturaMaxima;

    public void Accepta(IVizitatorFarmacie vizitator)
    {
        vizitator.Viziteaza(this);
    }
}

// ConcreteElement 3 - Seif pentru stupefiante si medicamente controlate
public class SeifStudefiante : IElementFarmacie
{
    public string NumeElement => "Seif Stupefiante";
    public string NivelSecuritate { get; } // "Standard", "Ridicat", "Maxim"
    public string FarmacistResponsabil { get; }
    public DateTime UltimaVerificare { get; set; }
    public List<MedicamentStocat> Medicamente { get; } = new();

    public SeifStudefiante(string nivelSecuritate, string farmacistResponsabil, DateTime ultimaVerificare)
    {
        NivelSecuritate = nivelSecuritate;
        FarmacistResponsabil = farmacistResponsabil;
        UltimaVerificare = ultimaVerificare;
    }

    public void AdaugaMedicament(MedicamentStocat med)
    {
        Medicamente.Add(med);
    }

    public void Accepta(IVizitatorFarmacie vizitator)
    {
        vizitator.Viziteaza(this);
    }
}
