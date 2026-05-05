namespace TMPP.Behavioral.Mediator;

public static class MediatorUsing
{
    public static void Run()
    {
        Console.WriteLine("\n--- Mediator Pattern ---");
        Console.WriteLine("Scenariu: Coordonarea departamentelor farmaciei (Receptie, Depozit, Laborator, Casa de Marcat).\n");

        // Cream mediatorul (coordinatorul)
        var coordinator = new CoordinatorFarmacie();

        // Cream departamentele - fiecare cunoaste doar mediatorul
        var receptie = new Receptie(coordinator);
        var depozit = new DepozitMediatorColleague(coordinator);
        var laborator = new Laborator(coordinator);
        var casaDeMarcat = new CasaDeMarcat(coordinator);

        // Inregistram departamentele la coordinator
        coordinator.Receptie = receptie;
        coordinator.Depozit = depozit;
        coordinator.Laborator = laborator;
        coordinator.CasaDeMarcat = casaDeMarcat;

        Console.WriteLine("  [Setup] Departamente inregistrate: Receptie, Depozit, Laborator, Casa de Marcat\n");

        // 1. Reteta standard - flux normal: Receptie -> Depozit -> Casa de Marcat
        Console.WriteLine(">> 1. Reteta standard (Paracetamol) - flux: Receptie -> Depozit -> Casa de Marcat:");
        receptie.PrimesteReteta("Ion Popescu", "Paracetamol 500mg", necesitaPreparare: false);

        // 2. Reteta cu preparare de laborator: Receptie -> Laborator -> Depozit -> Casa de Marcat
        Console.WriteLine("\n>> 2. Reteta cu preparare (Sirop Tuse Custom) - flux: Receptie -> Laborator -> Depozit -> Casa:");
        receptie.PrimesteReteta("Maria Ionescu", "Sirop Tuse Custom", necesitaPreparare: true);

        // 3. Reteta standard dar cu stoc insuficient
        Console.WriteLine("\n>> 3. Reteta standard dar stoc insuficient (Sirop Tuse Custom din stoc):");
        receptie.PrimesteReteta("Vasile Gheorghe", "Sirop Tuse Custom", necesitaPreparare: false);
    }
}
