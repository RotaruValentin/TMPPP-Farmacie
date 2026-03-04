using TMPP.Creational.AbstractFactory;

namespace TMPP.Creational.Singleton;

public static class SingletonUsing
{
    public static void Run()
    {
        var medicine = new CapsuleFactory().CreateMedicine("Capsule1");
        var pharmacy = Pharmacy.Instance;

        pharmacy.AddMedicine(medicine);
        Console.WriteLine(pharmacy.TotalMedicines);

        medicine = new SyrupFactory().CreateMedicine("Syrup1");
        pharmacy.AddMedicine(medicine);
        Console.WriteLine(pharmacy.TotalMedicines);

        var newOldPharmacy = Pharmacy.GetInstance();
        Console.WriteLine(newOldPharmacy.TotalMedicines);
    }
}
