namespace TMPP.Structural.Adapter;

// Aceasta este clasa incompatibilă (Adaptee).
// Să presupunem că este un API extern al unui furnizor care returnează datele sub formă de text delimitat.
public class ExternalApiSupplier
{
    public string GetMedicineData(string codeName)
    {
        // Returneaza datele sub forma: "Nume|Producator|Dozaj"
        return $"{codeName}|GlobalPharmaCorp|500";
    }
}
