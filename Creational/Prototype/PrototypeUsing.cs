using TMPP.Models;

namespace TMPP.Creational.Prototype;

public static class PrototypeUsing
{
    public static void Run()
    {
        var capsule = new Capsule
        {
            Name = "Capsule1",
            Manufacturer = "HealthPlus",
            Quantity = 100
        };


        Console.WriteLine(capsule);
        var medicineCopy = capsule.Clone();
        Console.WriteLine(medicineCopy);


        var tablet = new Tablet
        {
            Name = "Tablet1",
            Manufacturer = "PharmaCorp",
            Dosage = 500
        };

        Console.WriteLine(tablet);
        var tabletCopy = tablet.Clone();
        Console.WriteLine(tabletCopy);

        IPrototype[] prototypes = [capsule, tablet];
        var clones = prototypes.Select(p => p.Clone());
    }
}
