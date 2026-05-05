namespace TMPP.Behavioral.Iterator;

// Elementul colectiei - un medicament cu proprietati complete
public class MedicamentItem
{
    public string Nume { get; set; }
    public string Categorie { get; set; } // "Analgezic", "Antibiotic", "Vitamina", "Antiviral"
    public decimal Pret { get; set; }
    public bool NecesitaReteta { get; set; }
    public int StocDisponibil { get; set; }

    public MedicamentItem(string nume, string categorie, decimal pret, bool necesitaReteta, int stocDisponibil)
    {
        Nume = nume;
        Categorie = categorie;
        Pret = pret;
        NecesitaReteta = necesitaReteta;
        StocDisponibil = stocDisponibil;
    }

    public override string ToString()
    {
        string reteta = NecesitaReteta ? "Cu reteta" : "Fara reteta";
        return $"{Nume} [{Categorie}] - {Pret:F2} RON ({reteta}, stoc: {StocDisponibil})";
    }
}
