using TMPP.Models;

namespace TMPP.Creational.Builder;

public static  class BuilderUsing
{
    public static void Run()
    {
        Capsule customCapsule = new CapsuleBuilder()
            .SetName("Vitamin C")
            .SetManufacturer("HealthCorp")
            .SetQuantity(500)
            .Build();

        Console.WriteLine(customCapsule);

        var builder2 = new CapsuleBuilder();

        var capsule1 = builder2
            .SetName("Omega-3")
            .SetManufacturer("NutraPharma")
            .SetQuantity(450)
            .Build();
        Console.WriteLine(capsule1);

        var capsule2 = builder2
            .SetName("Multivitamin")
            .SetManufacturer("WellnessLab")
            .SetQuantity(600)
            .Build();
        Console.WriteLine(capsule2);

        var partialCapsule = new CapsuleBuilder()
            .SetName("Calcium")
            .Build();
        Console.WriteLine(partialCapsule);

        ICapsuleBuilder interfaceBuilder = new CapsuleBuilder();
        var capsule3 = interfaceBuilder
            .SetManufacturer("GenericMeds")
            .SetQuantity(300)
            .Build();
        Console.WriteLine(capsule3);
    }
}
