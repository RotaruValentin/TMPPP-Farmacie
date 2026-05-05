namespace TMPP.Behavioral.Mediator;

// Mediator - interfata care defineste comunicarea intre departamentele farmaciei.
// Niciun departament nu comunica direct cu altul, totul trece prin mediator.
public interface IMediatorFarmacie
{
    void Notifica(DepartamentFarmacie expeditor, string eveniment, string detalii);
}

// Colleague abstract - baza comuna pentru toate departamentele farmaciei
// Fiecare departament cunoaste doar mediatorul, nu si celelalte departamente
public abstract class DepartamentFarmacie
{
    protected IMediatorFarmacie Mediator;
    public string NumeDepartament { get; protected set; }

    protected DepartamentFarmacie(IMediatorFarmacie mediator, string numeDepartament)
    {
        Mediator = mediator;
        NumeDepartament = numeDepartament;
    }
}
