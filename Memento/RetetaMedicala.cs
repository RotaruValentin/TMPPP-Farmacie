namespace TMPP.Behavioral.Memento;

// Originator - Reteta medicala care isi poate salva si restaura starea.
// Este singurul care stie sa creeze un Memento si sa se restaureze dintr-unul.
public class RetetaMedicala
{
    public string NumePacient { get; set; }
    public string NumeDoctor { get; set; }
    public List<string> Medicamente { get; private set; } = new();
    public string Diagnostic { get; set; }

    public RetetaMedicala(string numePacient, string numeDoctor, string diagnostic)
    {
        NumePacient = numePacient;
        NumeDoctor = numeDoctor;
        Diagnostic = diagnostic;
    }

    public void AdaugaMedicament(string medicament)
    {
        Medicamente.Add(medicament);
        Console.WriteLine($"    [Reteta] Adaugat: '{medicament}'");
    }

    public void StergeMedicament(string medicament)
    {
        if (Medicamente.Remove(medicament))
            Console.WriteLine($"    [Reteta] Sters: '{medicament}'");
        else
            Console.WriteLine($"    [Reteta] '{medicament}' nu exista pe reteta.");
    }

    public void SchimbaDiagnostic(string diagnosticNou)
    {
        Console.WriteLine($"    [Reteta] Diagnostic schimbat: '{Diagnostic}' -> '{diagnosticNou}'");
        Diagnostic = diagnosticNou;
    }

    // Creeaza un Memento cu starea curenta
    public RetetaMemento SalveazaStare()
    {
        Console.WriteLine($"    [Reteta] Stare salvata in Memento.");
        return new RetetaMemento(NumePacient, NumeDoctor, Medicamente, Diagnostic);
    }

    // Restaureaza starea din Memento
    public void RestaureazaStare(RetetaMemento memento)
    {
        NumePacient = memento.NumePacient;
        NumeDoctor = memento.NumeDoctor;
        Medicamente = new List<string>(memento.Medicamente);
        Diagnostic = memento.Diagnostic;
        Console.WriteLine($"    [Reteta] Stare restaurata din Memento ({memento.DataSalvare:HH:mm:ss}).");
    }

    public void Afiseaza()
    {
        Console.WriteLine($"    [Reteta] --- Reteta curenta ---");
        Console.WriteLine($"    [Reteta]   Pacient: {NumePacient}");
        Console.WriteLine($"    [Reteta]   Doctor: {NumeDoctor}");
        Console.WriteLine($"    [Reteta]   Diagnostic: {Diagnostic}");
        Console.WriteLine($"    [Reteta]   Medicamente ({Medicamente.Count}):");
        foreach (var med in Medicamente)
        {
            Console.WriteLine($"    [Reteta]     - {med}");
        }
    }
}
