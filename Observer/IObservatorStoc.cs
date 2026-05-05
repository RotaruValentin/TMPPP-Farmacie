namespace TMPP.Behavioral.Observer;

// Observer - interfata pentru toti observatorii care doresc sa fie notificati
// cand stocul unui medicament se modifica
public interface IObservatorStoc
{
    string Nume { get; }
    void Actualizeaza(string numeMedicament, int stocVechi, int stocNou, string tipEveniment);
}
