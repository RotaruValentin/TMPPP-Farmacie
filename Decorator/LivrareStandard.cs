namespace TMPP.Structural.Decorator;

// ConcreteComponent - serviciul de livrare de baza (standard)
public class LivrareStandard : IServiciuLivrare
{
    private readonly string _numeMedicament;

    public LivrareStandard(string numeMedicament)
    {
        _numeMedicament = numeMedicament;
    }

    public string GetDescriere()
    {
        return $"Livrare standard pentru '{_numeMedicament}'";
    }

    public decimal GetCost()
    {
        return 10.00m; // cost de baza 10 RON
    }
}
