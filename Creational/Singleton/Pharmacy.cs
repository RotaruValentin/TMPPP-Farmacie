using TMPP.Models;

namespace TMPP.Creational.Singleton;

public class Pharmacy
{
    public List<BaseMedicine> Medicines { get; private set; } = [];
    public int TotalMedicines { get; private set; } = 0;

    private Pharmacy()
    {
    }

    public void AddMedicine(BaseMedicine medicine)
    {
        Medicines.Add(medicine);
        TotalMedicines++;
    }

    public static Pharmacy Instance { get; } = new();
    // OR
    public static Pharmacy GetInstance() => Instance;
}
