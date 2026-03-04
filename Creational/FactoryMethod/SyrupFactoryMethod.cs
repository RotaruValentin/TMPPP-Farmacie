using TMPP.Models;

namespace TMPP.Creational.FactoryMethod;

public class SyrupFactoryMethod : BaseMedicineFactoryMethod
{
    protected override BaseMedicine CreateMedicine(string medicineName)
    {
        return new Syrup
        {
            Name = medicineName,
            Manufacturer = "MedicoLab",
            RequiresPrescription = true
        };
    }
}
