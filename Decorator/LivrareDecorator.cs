namespace TMPP.Structural.Decorator;

// Base Decorator - clasa abstracta care implementeaza IServiciuLivrare si tine o referinta
// catre componenta decorata. Toate decoratoarele concrete mostenesc aceasta clasa.
public abstract class LivrareDecorator : IServiciuLivrare
{
    protected readonly IServiciuLivrare _serviciuDecorat;

    protected LivrareDecorator(IServiciuLivrare serviciuDecorat)
    {
        _serviciuDecorat = serviciuDecorat;
    }

    public virtual string GetDescriere()
    {
        return _serviciuDecorat.GetDescriere();
    }

    public virtual decimal GetCost()
    {
        return _serviciuDecorat.GetCost();
    }
}
