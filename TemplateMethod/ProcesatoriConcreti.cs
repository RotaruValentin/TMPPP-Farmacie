namespace TMPP.Behavioral.TemplateMethod;

// ConcreteTemplate 1 - Procesare reteta standard (OTC - fara reteta)
// Flux simplu, fara verificari suplimentare
public class ProcesatorRetetaStandard : ProcesatorReteta
{
    public ProcesatorRetetaStandard() : base("Reteta Standard") { }

    protected override bool ValideazaReteta(string numePacient, string numeMedicament)
    {
        Console.WriteLine($"    Verificare identitate pacient: {numePacient} ✓");
        Console.WriteLine($"    Medicament OTC - nu necesita reteta ✓");
        return true;
    }

    protected override void PregatesteMedicamente(string numeMedicament, int cantitate)
    {
        Console.WriteLine($"    Selectare '{numeMedicament}' din raft: {cantitate} cutii ✓");
        Console.WriteLine($"    Verificare data expirare: valabil ✓");
    }

    protected override void AmbaleazaComanda(string numeMedicament, int cantitate)
    {
        Console.WriteLine($"    Ambalare in punga standard ✓");
        Console.WriteLine($"    Adaugare prospect si bon fiscal ✓");
    }

    protected override void ElibereazaComanda(string numePacient, string numeMedicament)
    {
        Console.WriteLine($"    Eliberare la ghiseu catre {numePacient} ✓");
    }
}

// ConcreteTemplate 2 - Procesare reteta compensata (cu card de sanatate)
// Adauga validare card sanatate si calcul compensare CNAS
public class ProcesatorRetetaCompensata : ProcesatorReteta
{
    private readonly decimal _procentCompensare;

    public ProcesatorRetetaCompensata(decimal procentCompensare = 0.50m)
        : base("Reteta Compensata")
    {
        _procentCompensare = procentCompensare;
    }

    protected override bool ValideazaReteta(string numePacient, string numeMedicament)
    {
        Console.WriteLine($"    Verificare identitate pacient: {numePacient} ✓");
        Console.WriteLine($"    Verificare reteta originala semnata de medic ✓");
        Console.WriteLine($"    Scanare card european de sanatate ✓");
        Console.WriteLine($"    Verificare eligibilitate CNAS - pacient asigurat ✓");
        Console.WriteLine($"    Verificare medicament in lista compensate CNAS ✓");
        return true;
    }

    protected override void PregatesteMedicamente(string numeMedicament, int cantitate)
    {
        Console.WriteLine($"    Selectare '{numeMedicament}' din sectiunea medicamente compensate ✓");
        Console.WriteLine($"    Verificare lot si serie: conforme ✓");
        decimal pretBaza = 35.00m;
        decimal compensare = pretBaza * _procentCompensare;
        Console.WriteLine($"    Calcul compensare CNAS: {_procentCompensare * 100}% din {pretBaza:F2} RON = {compensare:F2} RON");
        Console.WriteLine($"    Pret de plata pacient: {pretBaza - compensare:F2} RON");
    }

    protected override void AmbaleazaComanda(string numeMedicament, int cantitate)
    {
        Console.WriteLine($"    Ambalare in punga farmaceutica sigilata ✓");
        Console.WriteLine($"    Adaugare prospect, bon fiscal si copie reteta ✓");
        Console.WriteLine($"    Stampilare reteta originala (reteta utilizata) ✓");
    }

    protected override void AfiseazaAvertismente(string numeMedicament)
    {
        Console.WriteLine($"\n  [{TipProcesator}] AVERTISMENTE:");
        Console.WriteLine($"    ⚠ Reteta compensata este valabila 30 de zile de la emitere.");
        Console.WriteLine($"    ⚠ Medicamentul se administreaza conform prescriptiei medicale.");
    }

    protected override void ElibereazaComanda(string numePacient, string numeMedicament)
    {
        Console.WriteLine($"    Semnare de primire de catre pacient: {numePacient} ✓");
        Console.WriteLine($"    Arhivare reteta originala in evidenta farmaciei ✓");
        Console.WriteLine($"    Eliberare medicament compensat ✓");
    }
}

// ConcreteTemplate 3 - Procesare reteta stupefiante (medicamente controlate)
// Verificari stricte: identitate, registru special, limita cantitate
public class ProcesatorRetetaStupefiante : ProcesatorReteta
{
    public ProcesatorRetetaStupefiante() : base("Reteta Stupefiante") { }

    // Hook - stupefiante necesita INTOTDEAUNA verificare speciala
    protected override bool NecesitaVerificareSpeciala() => true;

    protected override bool ValideazaReteta(string numePacient, string numeMedicament)
    {
        Console.WriteLine($"    Verificare identitate pacient cu act de identitate: {numePacient} ✓");
        Console.WriteLine($"    Verificare reteta speciala cu regim deosebit ✓");
        Console.WriteLine($"    Verificare stampila si semnatura medic prescriptor ✓");
        Console.WriteLine($"    Verificare numar unic reteta in baza de date nationala ✓");
        Console.WriteLine($"    Reteta valida - emisa in ultimele 5 zile ✓");
        return true;
    }

    protected override void ExecutaVerificareSpeciala(string numePacient, string numeMedicament)
    {
        Console.WriteLine($"    ★ Verificare in Registrul National de Stupefiante...");
        Console.WriteLine($"    ★ Verificare pacient '{numePacient}' - nu exista alerte active ✓");
        Console.WriteLine($"    ★ Verificare cantitate prescrisa - in limita legala (max 10 zile tratament) ✓");
        Console.WriteLine($"    ★ Verificare farmacist responsabil - autorizatie valabila ✓");
    }

    protected override void PregatesteMedicamente(string numeMedicament, int cantitate)
    {
        Console.WriteLine($"    Acces seif stupefiante cu cod de securitate ✓");
        Console.WriteLine($"    Selectare '{numeMedicament}' - {cantitate} unitati ✓");
        Console.WriteLine($"    Inregistrare in registrul de stupefiante al farmaciei ✓");
        Console.WriteLine($"    Actualizare stoc seif: scadere {cantitate} unitati ✓");
    }

    protected override void AmbaleazaComanda(string numeMedicament, int cantitate)
    {
        Console.WriteLine($"    Ambalare in cutie sigilata cu eticheta de securitate ✓");
        Console.WriteLine($"    Adaugare prospect si instructiuni speciale ✓");
        Console.WriteLine($"    Lipire eticheta cu date pacient si posologie ✓");
    }

    protected override void AfiseazaAvertismente(string numeMedicament)
    {
        Console.WriteLine($"\n  [{TipProcesator}] AVERTISMENTE SPECIALE:");
        Console.WriteLine($"    ⚠ ATENTIE: Medicament cu regim special - stupefiant!");
        Console.WriteLine($"    ⚠ Nu se administreaza fara supravegherea medicului.");
        Console.WriteLine($"    ⚠ Pastrare in loc sigur, inaccesibil copiilor.");
        Console.WriteLine($"    ⚠ Returnarea ambalajelor goale la farmacie este obligatorie.");
    }

    protected override void ElibereazaComanda(string numePacient, string numeMedicament)
    {
        Console.WriteLine($"    Semnare registru de eliberare stupefiante ✓");
        Console.WriteLine($"    Copie act identitate pacient: {numePacient} - arhivata ✓");
        Console.WriteLine($"    Reteta originala retinuta si arhivata (obligatoriu 3 ani) ✓");
        Console.WriteLine($"    Raport automat catre autoritatea competenta ✓");
        Console.WriteLine($"    Eliberare medicament controlat ✓");
    }
}
