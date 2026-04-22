using System;

namespace TMPP.Structural.Adapter;

public static class AdapterUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Adapter Pattern ---");

        // Sistemul extern curent are o interfață incompatibilă (Returnează String, nu BaseMedicine)
        var externalApi = new ExternalApiSupplier();

        // Folosim Adaptorul pentru a face sistemul extern să se comporte ca un IMedicineProvider
        IMedicineProvider provider = new ExternalMedicineAdapter(externalApi);

        // Apelul clientului care acum folosește interfața cunoscută (IMedicineProvider)
        var medicine = provider.ProvideMedicine("Ibuprofen");

        Console.WriteLine($"Medicament obtinut : {medicine}");
    }
}
