using System.Security.Principal;
using System.Text;
using System.Xml;
using System;
using System.Threading.Tasks;
using static Test6._0.MethodeAffichage;

namespace Test6._0
{
    // Déclaration de la classe principale du programme
    internal class Program
    {
        // Variables statiques pour le contrôle du programme
        static bool Dev = false; // Indicateur de mode développeur
        static bool passer = false; // Indicateur pour le passage de certaines boucles
        static uint select = 0; // Sélection dans le menu
        static int RefreshTime = 50; // Temps de rafraîchissement de l'écran en millisecondes
        static string[,] Matr = null; // Matrice pour l'affichage

        // Méthode principale asynchrone
        static async Task Main(string[] args)
        {
            // Définir le titre de la console
            Console.Title = "- Universal Uno -";

            // Instanciation des classes de méthode
            MethodeAffichage Affichage = new MethodeAffichage(); // Pour les affichages
            methodeProject Uno = new methodeProject(); // Pour la logique du jeu

            // Création et démarrage des threads pour les entrées et l'affichage
            Thread inputThread = new Thread(SwitchLoop);
            inputThread.Start();
            Thread EcranThread = new Thread(Ecran);
            EcranThread.Start();

            // Boucle principale du jeu
            while (true)
            {
                // Variables pour la gestion du menu et du jeu
                string Questions = "Bienvenue !";
                string Choix = "Lancer!Règles?Quitter";
                bool OkPasOk = true;
                uint nbrJoueurs = 2;
                uint tourJoueur = 0;
                int max;

                // Variables des cartes du jeux
                int[] carteCentrale = new int[2];
                int[,] cartes;

                // Pause initiale
                Thread.Sleep(100);

                // Boucle pour le menu principal
                while (OkPasOk)
                {
                    Affichage.menuPrincipal(Matr, Dev);
                    if (passer == true)
                    {
                        passer = false;
                        OkPasOk = false;
                    }
                }
                Affichage.ResetColor(Matr);
                OkPasOk = true;

                // Boucle pour les options du menu principal
                while (OkPasOk)
                {
                    if (Console.WindowWidth > 79 || Console.WindowHeight > 24)
                    {
                        Affichage.Questions(Matr, Questions, Choix, select);
                    }

                    if (passer == true)
                    {
                        passer = false;
                        OkPasOk = false;
                        if (select == 2)
                        {
                            Environment.Exit(0);
                        }
                    }
                }
                OkPasOk = true;

                // Affichage des règles si sélectionné
                if (select == 1)
                {
                    while (OkPasOk)
                    {
                        Affichage.Regles(Matr, Dev);
                        if (passer == true)
                        {
                            OkPasOk = false;
                            passer = false;
                        }
                    }
                    OkPasOk = true;
                    select = 0;
                }

                // Demander le nombre de joueurs
                Questions = "Combien de joueurs?";
                Choix = "   2      3      4   ";
                while (OkPasOk)
                {
                    if (Console.WindowWidth > 79 || Console.WindowHeight > 24)
                    {
                        Affichage.Questions(Matr, Questions, Choix, select);
                        if (passer == true)
                        {
                            passer = false;
                            OkPasOk = false;
                            nbrJoueurs = select + 2;
                        }
                    }
                }
                OkPasOk = true;

                // Affichage des instructions de jeu
                while (OkPasOk)
                {
                    Affichage.commentJouer(Matr);
                    if (passer == true)
                    {
                        OkPasOk = false;
                        passer = false;
                    }
                }

                // Distribution des cartes initiales
                max = 9;
                carteCentrale[0] = Uno.distribuerCartes(max);
                carteCentrale[1] = 0;
                while (carteCentrale[1] == 0)
                {
                    max = 3;
                    carteCentrale[1] = Uno.distribuerCartes(max);
                }

                // Initialisation des cartes des joueurs
                cartes = new int[26, nbrJoueurs * 2];
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < nbrJoueurs * 2; j++)
                    {
                        cartes[i, j] = 99;
                    }
                }
                Uno.jeuxDistrib(nbrJoueurs, cartes, carteCentrale);

                // Création et démarrage du thread de jeu
                Thread gameThread = new Thread(() => jeux(Matr, cartes, tourJoueur, carteCentrale, nbrJoueurs));
                gameThread.Start();

                // Boucle d'affichage continue du jeu
                while (true)
                {
                    Affichage.jeux(Matr, cartes, carteCentrale); // Mettre à jour l'affichage
                }
            }
        }

        // Méthode de gestion du jeu
        static void jeux(string[,] Matr, int[,] cartes, uint tourJoueur, int[] carteCentrale, uint nbrJoueurs)
        {
            methodeProject Uno = new methodeProject(); // Instanciation de la structure

            int gagner = 0; // Indicateur de fin de partie
            while (gagner == 0)
            {
                tourJoueur = 0;
                Uno.jouerUtilisateur(Matr, cartes, tourJoueur, carteCentrale); // Tour du joueur utilisateur
                int loc = 0;
                while (loc < cartes.GetLength(0) - 1 && cartes[loc, tourJoueur] != 99)
                {
                    loc++;
                }
                if (loc == 0)
                {
                    gagner = 1; // Joueur utilisateur gagne
                    break;
                }
                for (int i = 0; i < nbrJoueurs - 1; i++)
                {
                    tourJoueur += 2;
                    Thread.Sleep(1500);
                    Uno.jouerBots(Matr, cartes, tourJoueur, carteCentrale, nbrJoueurs); // Tour des bots
                    while (loc < cartes.GetLength(0) - 1 && cartes[loc, tourJoueur] != 99)
                    {
                        loc++;
                    }
                    if (loc == 0)
                    {
                        gagner = 2; // Un des bots gagne
                        break;
                    }
                }
            }

            // Affichage du résultat de la partie
            bool OkPasOk = true;
            MethodeAffichage Affichage = new MethodeAffichage(); // Instanciation de la structure
            if (gagner == 1)
            {
                while (OkPasOk)
                {
                    Affichage.gagner(Matr); // Affichage de la victoire
                    if (passer == true)
                    {
                        OkPasOk = false;
                        passer = false;
                    }
                }
            }
            else
            {
                while (OkPasOk)
                {
                    Affichage.perdu(Matr); // Affichage de la défaite
                    if (passer == true)
                    {
                        OkPasOk = false;
                        passer = false;
                    }
                }
            }
        }

        // Méthode de gestion de l'affichage continu
        static void Ecran()
        {
            MethodeAffichage Affichage = new MethodeAffichage(); // Instanciation de la structure

            IPSCounter ipsCounter = new IPSCounter();
            ipsCounter.Start();

            Matr = new string[Console.WindowWidth * 2, Console.WindowHeight];
            int width = Console.WindowWidth * 2;
            int height = Console.WindowHeight;

            bool OnceInTwoWhile = true;

            Console.Clear();
            Console.CursorVisible = false;

            Affichage.Bordures(Matr);

            while (true)
            {
                ipsCounter.Update();
                Affichage.Debug(Matr, ipsCounter, Dev, RefreshTime, OnceInTwoWhile); // Affichage des informations de débogage
                Affichage.Afficher(Matr, RefreshTime); // Rafraîchissement de l'affichage

                if (width != Console.WindowWidth * 2 || height != Console.WindowHeight)
                {
                    if (Console.WindowWidth > 79 || Console.WindowHeight > 24)
                    {
                        width = Console.WindowWidth * 2;
                        height = Console.WindowHeight;
                        Matr = new string[Console.WindowWidth * 2, Console.WindowHeight];
                        Affichage.Bordures(Matr); // Redessiner les bordures en cas de changement de taille
                    }
                }
            }
        }

        // Méthode de gestion des entrées utilisateur
        static void SwitchLoop()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.F8:
                        Dev = !Dev; // Basculer le mode développeur
                        break;
                    case ConsoleKey.UpArrow:
                        if (Dev)
                        {
                            if (RefreshTime < 100)
                            {
                                RefreshTime += 1; // Augmenter le temps de rafraîchissement en mode développeur
                            }
                        }
                        else
                        {
                            select = (select > 0) ? select - 1 : 2; // Changer la sélection dans le menu
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Dev)
                        {
                            if (RefreshTime > 0)
                            {
                                RefreshTime -= 1; // Diminuer le temps de rafraîchissement en mode développeur
                            }
                        }
                        else
                        {
                            select = (select < 2) ? select + 1 : 0; // Changer la sélection dans le menu
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (!Dev)
                        {
                            passer = true; // Valider la sélection dans le menu
                        }
                        break;
                }
            }
        }
    }

}