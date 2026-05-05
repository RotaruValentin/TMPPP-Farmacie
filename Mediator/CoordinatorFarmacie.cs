namespace TMPP.Behavioral.Mediator;

// ConcreteMediator - Coordonatorul farmaciei care gestioneaza comunicarea intre departamente.
// Primeste notificari de la un departament si decide ce departamente trebuie notificate in raspuns.
public class CoordinatorFarmacie : IMediatorFarmacie
{
    public Receptie Receptie { get; set; } = null!;
    public DepozitMediatorColleague Depozit { get; set; } = null!;
    public Laborator Laborator { get; set; } = null!;
    public CasaDeMarcat CasaDeMarcat { get; set; } = null!;

    public void Notifica(DepartamentFarmacie expeditor, string eveniment, string detalii)
    {
        Console.WriteLine($"  [Coordinator] Eveniment '{eveniment}' de la {expeditor.NumeDepartament}");

        switch (eveniment)
        {
            case "RetetaStandard":
            {
                // Receptia a primit o reteta standard -> verificam stoc -> pregatim -> plata
                string numeMedicament = detalii.Split('|')[1];
                Console.WriteLine($"  [Coordinator] Reteta standard - trimit la depozit pentru verificare si pregatire.");
                if (Depozit.VerificaStoc(numeMedicament))
                {
                    Depozit.PregatesteMedicament(numeMedicament);
                }
                else
                {
                    string numePacient = detalii.Split('|')[0];
                    Receptie.NotificaPacient($"Ne pare rau, '{numeMedicament}' nu este disponibil momentan.");
                }
                break;
            }

            case "RetetaCuPreparare":
            {
                // Receptia a primit o reteta ce necesita preparare -> laborator -> depozit -> plata
                string numeMedicament = detalii.Split('|')[1];
                Console.WriteLine($"  [Coordinator] Reteta cu preparare - trimit la laborator.");
                Laborator.PreparaCompozitie(numeMedicament);
                break;
            }

            case "PreparatFinalizat":
            {
                // Laboratorul a terminat prepararea -> trimitem la depozit -> casa de marcat
                Console.WriteLine($"  [Coordinator] Preparat finalizat - trimit la depozit pentru inregistrare.");
                Depozit.PrimesteDeLaLaborator(detalii);
                Depozit.PregatesteMedicament(detalii);
                break;
            }

            case "MedicamentPregatit":
            {
                // Depozitul a pregatit medicamentul -> trimitem la casa de marcat
                Console.WriteLine($"  [Coordinator] Medicament pregatit - trimit la casa de marcat pentru plata.");
                CasaDeMarcat.ProceseazaPlata(detalii);
                break;
            }

            case "StocInsuficient":
            {
                // Depozitul nu are stoc -> notificam receptia
                Console.WriteLine($"  [Coordinator] Stoc insuficient - notific receptia.");
                Receptie.NotificaPacient($"Medicamentul '{detalii}' nu este disponibil. Va rugam reveniti.");
                break;
            }

            case "PlataFinalizata":
            {
                // Plata a fost procesata -> notificam receptia sa elibereze medicamentul
                Console.WriteLine($"  [Coordinator] Plata finalizata - notific receptia pentru eliberare.");
                Receptie.NotificaPacient($"Medicamentul '{detalii}' a fost eliberat. Va multumim!");
                break;
            }
        }
    }
}
