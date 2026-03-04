using TMPP.Models;

namespace TMPP.Creational.AbstractFactory;

public class SyrupFactory : IMedicineFactory
{
    public BaseMedicine CreateMedicine(string medicineName)
    {
        return new Syrup
        {
            Name = medicineName,
            Manufacturer = "MedicoLab",
            RequiresPrescription = true
        };
    }
}
