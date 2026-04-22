namespace TMPP.Structural.Decorator;

// ConcreteDecorator 1 - adauga ambalaj cadou la livrare
public class AmbalajCadouDecorator : LivrareDecorator
{
    public AmbalajCadouDecorator(IServiciuLivrare serviciuDecorat) : base(serviciuDecorat) { }

    public override string GetDescriere()
    {
        return _serviciuDecorat.GetDescriere() + " + Ambalaj Cadou";
    }

    public override decimal GetCost()
    {
        return _serviciuDecorat.GetCost() + 5.00m; // +5 RON pentru ambalaj cadou
    }
}

// ConcreteDecorator 2 - adauga livrare expresa (mai rapida)
public class LivrareExpresaDecorator : LivrareDecorator
{
    public LivrareExpresaDecorator(IServiciuLivrare serviciuDecorat) : base(serviciuDecorat) { }

    public override string GetDescriere()
    {
        return _serviciuDecorat.GetDescriere() + " + Livrare Expresa (2h)";
    }

    public override decimal GetCost()
    {
        return _serviciuDecorat.GetCost() + 15.00m; // +15 RON pentru livrare expresa
    }
}

// ConcreteDecorator 3 - adauga asigurare de transport (medicamente fragile / scumpe)
public class AsigurareTransportDecorator : LivrareDecorator
{
    public AsigurareTransportDecorator(IServiciuLivrare serviciuDecorat) : base(serviciuDecorat) { }

    public override string GetDescriere()
    {
        return _serviciuDecorat.GetDescriere() + " + Asigurare Transport";
    }

    public override decimal GetCost()
    {
        return _serviciuDecorat.GetCost() + 8.50m; // +8.50 RON pentru asigurare
    }
}

// ConcreteDecorator 4 - adauga transport la temperatura controlata (medicamente sensibile)
public class TemperaturaControlataDecorator : LivrareDecorator
{
    public TemperaturaControlataDecorator(IServiciuLivrare serviciuDecorat) : base(serviciuDecorat) { }

    public override string GetDescriere()
    {
        return _serviciuDecorat.GetDescriere() + " + Temperatura Controlata (2-8°C)";
    }

    public override decimal GetCost()
    {
        return _serviciuDecorat.GetCost() + 20.00m; // +20 RON pentru transport la temperatura controlata
    }
}
