using System;
using System.Collections.Generic;
using TMPP.Models;

namespace TMPP.Creational.AbstractFactory;

public static class AbstractFactoryUsing
{
    public static void Run()
    {
        List<BaseMedicine> medicines = [];
        IMedicineFactory medicineFactory = new TabletFactory();
        BaseMedicine tablet = medicineFactory.CreateMedicine("My Tablet");
        Console.WriteLine($"Created a {tablet.Manufacturer} medicine named {tablet.Name}.");
        medicines.Add(tablet);

        medicineFactory = new SyrupFactory();
        BaseMedicine syrup = medicineFactory.CreateMedicine("My Syrup");
        Console.WriteLine($"Created a {syrup.Manufacturer} medicine named {syrup.Name}.");
        medicines.Add(syrup);

        medicineFactory = new CapsuleFactory();
        BaseMedicine capsule = medicineFactory.CreateMedicine("My Capsule");
        Console.WriteLine($"Created a {capsule.Manufacturer} medicine named {capsule.Name}.");
        medicines.Add(capsule);

        foreach (var medicine in medicines)
        {
            Console.WriteLine($"Medicine: {medicine}");
        }
    }
}
