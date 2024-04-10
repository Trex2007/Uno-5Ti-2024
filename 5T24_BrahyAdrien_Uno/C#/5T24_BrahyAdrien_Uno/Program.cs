using System.Threading.Tasks.Dataflow;

namespace _5T24_BrahyAdrien_Uno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            methodeAffichage outilAffichage = new methodeAffichage(); // isntanciation de la structure
            methodeProject outilProject = new methodeProject(); // isntanciation de la structure
            string[,] matrAff = new string[250, 40];
            string question = "error";
            string choixQuestions = "OuiNon";
            uint nbrJoueur = 0;
            uint select = 3;
            uint player = 1;
            bool playerOk = false;

            Console.Title = "- Universal Uno -";
            Console.CursorVisible = false;
            if (Console.WindowHeight < 41 || Console.WindowWidth < 125)
            {
                Console.SetWindowSize(125, 41);
            }

            while (playerOk == false)
            {
                if (select != 0)
                {
                    question = "Voulez-vous connaitre les règles ?";
                    outilAffichage.AskQuestion(question, choixQuestions, matrAff);
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.RightArrow:
                            matrAff[111, 21] = "";
                            matrAff[113, 21] = "";
                            matrAff[115, 21] = "";
                            matrAff[131, 21] = "rw";
                            matrAff[133, 21] = "rw";
                            matrAff[135, 21] = "rw";
                            Console.CursorVisible = false;
                            select = 2;
                            break;
                        case ConsoleKey.LeftArrow:
                            matrAff[111, 21] = "gb";
                            matrAff[113, 21] = "gb";
                            matrAff[115, 21] = "gb";
                            matrAff[131, 21] = "";
                            matrAff[133, 21] = "";
                            matrAff[135, 21] = "";
                            Console.CursorVisible = false;
                            select = 1;
                            break;
                        case ConsoleKey.Enter:
                            matrAff[111, 21] = "";
                            matrAff[113, 21] = "";
                            matrAff[115, 21] = "";
                            matrAff[131, 21] = "";
                            matrAff[133, 21] = "";
                            matrAff[135, 21] = "";
                            if (select == 1)
                            {
                                outilAffichage.Regles(matrAff);
                                select = 0;

                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.Enter:
                                        break;
                                }
                                break;
                            }
                            else if (select == 2)
                            {
                                select = 0;
                            }
                            break;
                    }
                }
                else if (player != 0)
                {
                    question = "Combien De joueurs voulez-vous ?";
                    choixQuestions = " 2  3 ";
                    outilAffichage.AskQuestion(question, choixQuestions, matrAff);

                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.RightArrow:
                            matrAff[111, 21] = "";
                            matrAff[113, 21] = "";
                            matrAff[115, 21] = "";
                            matrAff[131, 21] = "bw";
                            matrAff[133, 21] = "bw";
                            matrAff[135, 21] = "bw";
                            Console.CursorVisible = false;
                            player = 2;
                            break;
                        case ConsoleKey.LeftArrow:
                            matrAff[111, 21] = "bw";
                            matrAff[113, 21] = "bw";
                            matrAff[115, 21] = "bw";
                            matrAff[131, 21] = "";
                            matrAff[133, 21] = "";
                            matrAff[135, 21] = "";
                            Console.CursorVisible = false;
                            player = 3;
                            break;
                        case ConsoleKey.Enter:
                            matrAff[111, 21] = "";
                            matrAff[113, 21] = "";
                            matrAff[115, 21] = "";
                            matrAff[131, 21] = "";
                            matrAff[133, 21] = "";
                            matrAff[135, 21] = "";
                            playerOk = true;
                            break;
                    }
                }
            }
            // suite du programme
            int t = 0;
            for (int i = 0; i < 100; i++)
            {
                string test = outilProject.distribuerCartes();
                Console.WriteLine(test);
                if (char.ToString(test[0]) == "n")
                {
                    t++;
                }
            }
            Console.WriteLine(t);
            
        }
    }
}