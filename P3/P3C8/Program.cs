// See https://aka.ms/new-console-template for more information


namespace P3C8;

public class CompteClient
{
    public string NomClient;
    public int NumeroCompteClient;
    public double SoldeCompteCourant;
    public double SoldeCompteEpargne;

    //Constructeur
    public CompteClient(string nomClient, int numeroCompteClient, double soldeCompteCourant, double soldeCompteEpargne)
    {
        NomClient = nomClient;
        NumeroCompteClient = numeroCompteClient;
        SoldeCompteCourant = soldeCompteCourant;
        SoldeCompteEpargne = soldeCompteEpargne;
    }
}

public class Program
{
    // création d'un client
    static CompteClient durand = new CompteClient("Durand", 123456, 0.50, 0);
    
    //creation d'une liste de log session
    static IList<string> log = new List<string>();
    public static void Main()
    {
        Accueil();
        AffichageMenu();
        
    }
    
    
//Méthodes du programme
    static void AffichageMenu() //génére l'affichage du menu de l'application
    {
        Console.WriteLine("[I] Voir les informations sur le titulaire du compte");
        Console.WriteLine("[CS] Compte courant - Consulter le solde");
        Console.WriteLine("[CD] Compte courant - Déposer des fonds");
        Console.WriteLine("[CR] Compte courant - Retirer des fonds");
        Console.WriteLine("[ES] Compte épargne - Consulter le solde");
        Console.WriteLine("[ED] Compte épargne - Déposer des fonds");
        Console.WriteLine("[ER] Compte épargne - Retirer des fonds");
        Console.WriteLine("[X] Quitter");

        switch (Console.ReadLine())
        {
            case "I": // l'utilisateur demande à voir les infos du compte
                Console.WriteLine("Le nom du titulaire du compte est "+ durand.NomClient);
                Console.WriteLine("Le numéro de compte associé à ce client est " + durand.NumeroCompteClient); 
                break;
            
            case "CS": // l'utilisateur demande à consulter le solde du compte courant
                Console.WriteLine("Le solde du compte courant est de "+ durand.SoldeCompteCourant + " euros");
                break;
            
            case "CD":  // l'utilisateur demande à déposer des fonds
                Console.WriteLine("Veuillez saisir le montant du crédit à effectuer");
                string creditCourant = Console.ReadLine();
                Console.WriteLine("Vous allez effectuer un credit de " + creditCourant + " euros.");
                Console.WriteLine("Taper \"Entree\" pour valider ou n'importe quelle touche pour annuler");
                
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    durand.SoldeCompteCourant += Convert.ToDouble(creditCourant);
                    log.Add("compte courant credit " + creditCourant + " euros" );
                    Console.WriteLine("Le credit de " + creditCourant + " euros à bien été effectué");
                }
                else
                {
                    Console.WriteLine("Opération Annulée !");
                }
                break;
            
            case "CR": //l'utilisateur demande à retirer des fonds
                Console.WriteLine("Veuillez saisir le montant du débit à effectuer");
                string debitCourant = Console.ReadLine();
                Console.WriteLine("Vous allez effectuer un débit de " + debitCourant + " euros.");
                Console.WriteLine("Taper \"Entree\" pour valider ou n'importe quelle touche pour annuler");
                
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    durand.SoldeCompteCourant -= Convert.ToDouble(debitCourant);
                    log.Add("compte courant debit " + debitCourant + " euros" );
                    Console.WriteLine("Le débit de " + debitCourant + " euros à bien été effectué");
                }
                else
                {
                    Console.WriteLine("Opération Annulée !");
                }
                break;
            
            case "ES": // l'utilisateur demande à consulter le solde du compte epargne
                Console.WriteLine("Le solde du compte épargne est de "+ durand.SoldeCompteEpargne + " euros");
                break;
            
            case "ED":  // l'utilisateur demande à déposer des fonds
                Console.WriteLine("Veuillez saisir le montant du crédit à effectuer");
                string creditEpargne = Console.ReadLine();
                Console.WriteLine("Vous allez effectuer un credit de " + creditEpargne + " euros.");
                Console.WriteLine("Taper \"Entree\" pour valider ou n'importe quelle touche pour annuler");
                
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    durand.SoldeCompteEpargne += Convert.ToDouble(creditEpargne);
                    log.Add("compte épargne credit " + creditEpargne + " euros" );
                    Console.WriteLine("Le credit de " + creditEpargne + " euros à bien été effectué");
                }
                else
                {
                    Console.WriteLine("Opération Annulée !");
                }
                break;
            
            case "ER": //l'utilisateur demande à retirer des fonds
                Console.WriteLine("Veuillez saisir le montant du débit à effectuer");
                string debitEpargne = Console.ReadLine();
                Console.WriteLine("Vous allez effectuer un débit de " + debitEpargne + " euros.");
                Console.WriteLine("Taper \"Entree\" pour valider ou n'importe quelle touche pour annuler");
                
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    durand.SoldeCompteEpargne -= Convert.ToDouble(debitEpargne);
                    log.Add("compte épargne débit " + debitEpargne + " euros" );
                    Console.WriteLine("Le débit de " + debitEpargne + " euros à bien été effectué");
                }
                else
                {
                    Console.WriteLine("Opération Annulée !");
                }
                break;
            
            case "X":
                EcrireLog();
                Environment.Exit(0);
                break;
                
                
            default :
                Console.WriteLine("La saisie n'est pas valide !");
                Console.WriteLine("Veuillez recommencer");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter){}
                break;
            }
        Accueil();
        AffichageMenu();
        
    }

    static void Accueil()
    {
        Console.WriteLine("Appuyer sur Entrée pour afficher le menu");
        while (Console.ReadKey(true).Key != ConsoleKey.Enter){}
    }

  static void EcrireLog()
    {
        string buffer = String.Empty;
        try
        {
            foreach (var element in log)
            {
                buffer += element;
                buffer += Environment.NewLine;
            }
            File.WriteAllText("log.txt", buffer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}