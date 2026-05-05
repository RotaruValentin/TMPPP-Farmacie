namespace TMPP.Behavioral.TemplateMethod;

// Template Method - Clasa abstracta care defineste scheletul algoritmului de procesare a unei retete.
// Subclasele suprascriu pasii specifici fara a modifica structura generala a algoritmului.
public abstract class ProcesatorReteta
{
    public string TipProcesator { get; protected set; }

    protected ProcesatorReteta(string tipProcesator)
    {
        TipProcesator = tipProcesator;
    }

    // Template Method - defineste ordinea pasilor (nu poate fi suprascris)
    public void ProceseazaReteta(string numePacient, string numeMedicament, int cantitate)
    {
        Console.WriteLine($"  [{TipProcesator}] ═══ Incepere procesare reteta ═══");
        Console.WriteLine($"  [{TipProcesator}] Pacient: {numePacient}, Medicament: {numeMedicament} x{cantitate}");

        // Pasul 1 - Validare (abstract - implementat diferit de fiecare subtip)
        Console.WriteLine($"\n  [{TipProcesator}] PASUL 1: Validare reteta");
        if (!ValideazaReteta(numePacient, numeMedicament))
        {
            Console.WriteLine($"  [{TipProcesator}] ✗ Procesare oprita - validare esuata!");
            return;
        }

        // Pasul 2 - Verificare speciala (hook - optional, default false)
        if (NecesitaVerificareSpeciala())
        {
            Console.WriteLine($"\n  [{TipProcesator}] PASUL 2a: Verificare speciala");
            ExecutaVerificareSpeciala(numePacient, numeMedicament);
        }

        // Pasul 3 - Pregatire medicamente (abstract)
        Console.WriteLine($"\n  [{TipProcesator}] PASUL 2: Pregatire medicamente");
        PregatesteMedicamente(numeMedicament, cantitate);

        // Pasul 4 - Ambalare (abstract)
        Console.WriteLine($"\n  [{TipProcesator}] PASUL 3: Ambalare comanda");
        AmbaleazaComanda(numeMedicament, cantitate);

        // Pasul 5 - Afisare avertismente (hook - optional)
        AfiseazaAvertismente(numeMedicament);

        // Pasul 6 - Eliberare (abstract)
        Console.WriteLine($"\n  [{TipProcesator}] PASUL 4: Eliberare comanda");
        ElibereazaComanda(numePacient, numeMedicament);

        Console.WriteLine($"  [{TipProcesator}] ═══ Procesare finalizata cu succes ═══");
    }

    // Pasi abstracti - TREBUIE implementati de fiecare subtip
    protected abstract bool ValideazaReteta(string numePacient, string numeMedicament);
    protected abstract void PregatesteMedicamente(string numeMedicament, int cantitate);
    protected abstract void AmbaleazaComanda(string numeMedicament, int cantitate);
    protected abstract void ElibereazaComanda(string numePacient, string numeMedicament);

    // Hook-uri - pot fi suprascrise optional
    protected virtual bool NecesitaVerificareSpeciala() => false;
    protected virtual void ExecutaVerificareSpeciala(string numePacient, string numeMedicament) { }
    protected virtual void AfiseazaAvertismente(string numeMedicament) { }
}
