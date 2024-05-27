using System.Security.Principal;
using System.Text;
using System.Xml;
using System;
using System.Threading.Tasks;
using static Test.MethodeAffichage;

namespace Test
{
    internal class Program
    {
        static bool Dev = false;
        static bool passer = false;
        static uint select = 0;
        static int RefreshTime = 1;
        static string[,] Matr = null;
        static async Task Main(string[] args)
        {
            Console.Title = "- Universal Uno -";
            MethodeAffichage Affichage = new MethodeAffichage(); // instanciation de la structure

            Thread inputThread = new Thread(SwitchLoop);
            inputThread.Start();
            Thread EcranThread = new Thread(Ecran);
            EcranThread.Start();

            string Questions = "ERROR";
            string Choix = "ERROR";

            bool OkPasOk = true;

            Thread.Sleep(1000);
            while (OkPasOk)
            {
                if (Console.WindowWidth > 79 || Console.WindowHeight > 24)
                {
                    Questions = "Bienvenue !";
                    Choix = "Lancer!Regles?Quitter";
                    Affichage.Questions(Matr, Questions, Choix, select);
                }
                if (passer == true) { 
                    passer = false;
                    OkPasOk = false;
                    if (select == 2)
                    {
                        Environment.Exit(0);
                    }
                }
            }
            OkPasOk = true;
            if (select == 0)
            {
                while (OkPasOk)
                {
                    Console.WriteLine("HI");
                    //Affichage.Jeux();
                }
            } else if (select == 1)
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
        }
        static void Ecran()
        {
            MethodeAffichage Affichage = new MethodeAffichage(); // instanciation de la structure

            IPSCounter ipsCounter = new IPSCounter();
            ipsCounter.Start();

            Matr = new string[Console.WindowWidth * 2, Console.WindowHeight];
            int width = Console.WindowWidth * 2;
            int height = Console.WindowHeight;

            Console.Clear();
            Console.CursorVisible = false;

            Affichage.Bordures(Matr);

            while (true)
            {
                ipsCounter.Update();

                Affichage.Debug(Matr, ipsCounter, Dev, RefreshTime);

                Affichage.Afficher(Matr, RefreshTime);

                if (width != Console.WindowWidth * 2 || height != Console.WindowHeight)
                {
                    if (Console.WindowWidth > 79 || Console.WindowHeight > 24)
                    {
                        Matr = new string[Console.WindowWidth * 2, Console.WindowHeight];
                        Affichage.Bordures(Matr);
                    }
                }
            }
        }
        static void SwitchLoop()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.F8:
                        if (Dev == true)
                        {
                            Dev = false;
                        } else if (Dev == false)
                        {
                            Dev = true;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (RefreshTime < 100 && Dev == true)
                        {
                            RefreshTime += 1;
                        }
                        if (Dev == false) {
                            if (select > 0)
                            {
                                select--;
                            }
                            else
                            {
                                select = 2;
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (RefreshTime > 0 && Dev == true)
                        {
                            RefreshTime -= 1;
                        }
                        if (Dev == false) {
                            if (select < 2)
                            {
                                select++;
                            }
                            else
                            {
                                select = 0;
                            }
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (Dev == false) {
                            if (passer == false)
                            {
                                passer = true;
                            }
                        }
                        break;
                }
            }
        }
    }
}