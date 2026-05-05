namespace TMPP.Behavioral.Strategy;

// Strategy - interfata comuna pentru toate strategiile de calcul al pretului
// Permite schimbarea algoritmului de pret la runtime fara a modifica codul clientului
public interface IStrategieCalculPret
{
    string NumeStrategie { get; }
    decimal CalculeazaPret(string numeMedicament, decimal pretBaza, int cantitate);
}
