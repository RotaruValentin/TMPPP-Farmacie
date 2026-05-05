namespace TMPP.Behavioral.Memento;

// Memento - Obiect imutabil care stocheaza o copie a starii Retetei la un anumit moment.
// Doar Originator-ul (RetetaMedicala) stie cum sa creeze si sa restaureze din Memento.
public class RetetaMemento
{
    public string NumePacient { get; }
    public string NumeDoctor { get; }
    public List<string> Medicamente { get; }
    public string Diagnostic { get; }
    public DateTime DataSalvare { get; }

    public RetetaMemento(string numePacient, string numeDoctor, List<string> medicamente, string diagnostic)
    {
        NumePacient = numePacient;
        NumeDoctor = numeDoctor;
        Medicamente = new List<string>(medicamente); // copie defensiva
        Diagnostic = diagnostic;
        DataSalvare = DateTime.Now;
    }

    public override string ToString()
    {
        return $"[Memento {DataSalvare:HH:mm:ss}] Pacient: {NumePacient}, Doctor: {NumeDoctor}, " +
               $"Diagnostic: {Diagnostic}, Medicamente: [{string.Join(", ", Medicamente)}]";
    }
}
