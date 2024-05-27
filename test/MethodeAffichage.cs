using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using static Test.MethodeAffichage;
using System.Runtime.Loader;
using System.Transactions;
using System.Threading.Tasks.Dataflow;

namespace Test
{
    public struct MethodeAffichage
    {
        public void Bordures(string[,] Matr)
        {
            for (int i = 2; i < Matr.GetLength(0) - 2; i += 2)
            {
                for (int j = 1; j < Matr.GetLength(1) - 1; j++)
                {
                    Matr[i, j] = " ";
                }
            }
            for (int i = 0; i < Matr.GetLength(0); i += 2)
            {
                Matr[i, 0] = "─";
                Matr[i, Matr.GetLength(1) - 1] = "─";
            }
            for (int j = 0; j < Matr.GetLength(1); j++)
            {
                Matr[0, j] = "│";
                Matr[Matr.GetLength(0) - 2, j] = "│";
            }
            Matr[0, 0] = "┌";
            Matr[0, Matr.GetLength(1) - 1] = "└";
            Matr[Matr.GetLength(0) - 2, 0] = "┐";
            Matr[Matr.GetLength(0) - 2, Matr.GetLength(1) - 1] = "┘";
        }
        public class IPSCounter
        {
            private Stopwatch stopwatch = new Stopwatch();
            private int frameCount = 0;
            private int ips = 0;

            public int IPS
            {
                get { return ips; }
            }

            public void Start()
            {
                stopwatch.Start();
            }

            public void Update()
            {
                frameCount++;

                if (stopwatch.ElapsedMilliseconds >= 1000)
                {
                    ips = frameCount;
                    frameCount = 0;
                    stopwatch.Restart();
                }
            }
        }
        public void Debug(string[,] Matr, IPSCounter ipsCounter, bool Dev, int RefreshTime)
        {
            
            bool local = true;
            if (Dev)
            {
                // Affichage de la ligne de séparation
                for (int i = 0; i < Matr.GetLength(0); i += 2)
                {
                    Matr[i, 2] = "─";
                }
                Matr[0, 2] = "├";
                Matr[Matr.GetLength(0) - 2, 2] = "┤";

                // Affichage FPS
                Matr[4, 1] = "f";
                Matr[6, 1] = "p";
                Matr[8, 1] = "s";
                Matr[10, 1] = ":";

                if (ipsCounter.IPS < 20)
                {
                    Matr[13, 1] = "r";
                    if (ipsCounter.IPS > 9)
                    {
                        Matr[15, 1] = "r";
                    }
                    else
                    {
                        Matr[15, 1] = null;
                    }
                    if (ipsCounter.IPS > 99)
                    {
                        Matr[17, 1] = "r";
                    }
                    else
                    {
                        Matr[17, 1] = null;
                    }
                }
                else if (ipsCounter.IPS >= 20)
                {
                    Matr[13, 1] = "g";
                    Matr[15, 1] = "g";
                    if (ipsCounter.IPS > 99)
                    {
                        Matr[17, 1] = "g";
                    }
                    else
                    {
                        Matr[17, 1] = null;
                    }
                }

                Matr[12, 1] = ipsCounter.IPS.ToString(); ;

                if (ipsCounter.IPS > 9)
                {
                    Matr[14, 1] = null;
                }
                else
                {
                    Matr[14, 1] = " ";
                }

                if (ipsCounter.IPS > 99)
                {
                    Matr[16, 1] = null;
                }
                else
                {
                    Matr[16, 1] = " ";
                }

                if (ipsCounter.IPS > 999)
                {
                    Matr[18, 1] = null;
                }
                else
                {
                    Matr[18, 1] = " ";
                }

                // Affichage donné taille écran
                string debug = "Screen.Width:";

                for (int i = 0; i < debug.Length; i++)
                {
                    Matr[20 + i * 2, 1] = debug[i].ToString();
                }
                Matr[46, 1] = Console.WindowWidth.ToString();
                Matr[48, 1] = null;
                if (Console.WindowWidth > 99)
                {
                    Matr[50, 1] = null;
                }
                else
                {
                    Matr[50, 1] = " ";
                }

                debug = "Screen.Height:";

                for (int i = 0; i < debug.Length; i++)
                {
                    Matr[56 + i * 2, 1] = debug[i].ToString();
                }
                Matr[84, 1] = Console.WindowHeight.ToString();
                Matr[86, 1] = null;
                if (Console.WindowHeight > 99)
                {
                    Matr[88, 1] = null;
                }
                else
                {
                    Matr[90, 1] = " ";
                }

                debug = "Refresh.Rate:";

                for (int i = 0; i < debug.Length; i++)
                {
                    Matr[92 + i * 2, 1] = debug[i].ToString();
                }
                Matr[118, 1] = RefreshTime.ToString();
                if (RefreshTime > 9)
                {
                    Matr[120, 1] = null;
                }
                else
                {
                    Matr[120, 1] = " ";
                }
                if (RefreshTime > 99)
                {
                    Matr[122, 1] = null;
                }
                else
                {
                    Matr[122, 1] = " ";
                }

                local = true;
            }
            else
            {
                if (local)
                {
                    Matr[13, 1] = null;
                    Matr[15, 1] = null;
                    Matr[17, 1] = null;
                    Bordures(Matr);
                    local = false;
                }
            }
        }
        public void Afficher(string[,] Matr, int RefreshTime)
        {
            Console.CursorVisible = false;

            if (Console.WindowWidth > 80 && Console.WindowHeight > 24)
            {
                StringBuilder sb = new StringBuilder();
                ConsoleColor previousColor = Console.ForegroundColor;

                for (int j = 0; j < Matr.GetLength(1); j++)
                {
                    for (int i = 0; i < Matr.GetLength(0); i += 2)
                    {
                        string strToPrint = Matr[i, j];
                        ConsoleColor colorToPrint = GetColor(Matr, i, j);

                        if (colorToPrint != previousColor)
                        {
                            Console.Write(sb.ToString());
                            sb.Clear();
                            Console.BackgroundColor = colorToPrint;
                            previousColor = colorToPrint;
                        }
                        sb.Append(strToPrint);
                    }
                    sb.AppendLine();
                }

                Console.Write(sb.ToString());
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(RefreshTime);
            }
            else
            {
                Console.WriteLine("\n La taille n'est pas valide, vueillez agrandire la fenètre.");
            }
        }
        static ConsoleColor GetColor(string[,] matrix, int row, int col)
        {
            int nextRow = row + 1;
            if (nextRow < matrix.GetLength(0) && matrix[nextRow, col] == "r")
            {
                return ConsoleColor.Red;
            }
            else if (nextRow < matrix.GetLength(0) && matrix[nextRow, col] == "y")
            {
                return ConsoleColor.DarkYellow;
            }
            else if (nextRow < matrix.GetLength(0) && matrix[nextRow, col] == "g")
            {
                return ConsoleColor.DarkGreen;
            }
            else if (nextRow < matrix.GetLength(0) && matrix[nextRow, col] == "b")
            {
                return ConsoleColor.DarkBlue;
            }
            else
            {
                return ConsoleColor.Black;
            }
        }
        public void Questions(string[,] Matr, string Questions, string Choix, uint select)
        {
            if ((Matr.GetLength(0)/2) % 2 != 0)
            {
                for (int i = (Matr.GetLength(0) / 2) - 21; i < (Matr.GetLength(0) / 2) + 21; i += 2)
                {
                    Matr[i, (Matr.GetLength(1) / 2) + 8] = "─";
                    Matr[i, (Matr.GetLength(1) / 2) - 8] = "─";
                }
                for (int j = (Matr.GetLength(1) / 2) - 7; j < (Matr.GetLength(1)) / 2 + 8; j++)
                {
                    Matr[(Matr.GetLength(0) / 2) + 21, j] = "│";
                    Matr[(Matr.GetLength(0) / 2) - 23, j] = "│";
                }
                Matr[(Matr.GetLength(0) / 2) + 21, (Matr.GetLength(1) / 2) + 8] = "┘";
                Matr[(Matr.GetLength(0) / 2) - 23, (Matr.GetLength(1) / 2) + 8] = "└";
                Matr[(Matr.GetLength(0) / 2) + 21, (Matr.GetLength(1) / 2) - 8] = "┐";
                Matr[(Matr.GetLength(0) / 2) - 23, (Matr.GetLength(1) / 2) - 8] = "┌";

                for (int i = 0; i < Questions.Length; i++)
                {
                    Matr[((Matr.GetLength(0) / 2) - Questions.Length) + i * 2, (Matr.GetLength(1) / 2) - 7] = Questions[i].ToString();
                }

                for (int i = 0; i < Choix.Length / 3; i++)
                {
                    Matr[(((Matr.GetLength(0) / 2) - Choix.Length / 3) + i * 2), (Matr.GetLength(1) / 2) - 3] = Choix[i].ToString();
                }
                for (int i = Choix.Length / 3; i < Choix.Length / 1.5; i++)
                {
                    Matr[(((Matr.GetLength(0) / 2) - Choix.Length) + i * 2), (Matr.GetLength(1) / 2) + 1] = Choix[i].ToString();
                }
                for (int i = (Choix.Length * 2) / 3; i < Choix.Length; i++)
                {
                    Matr[(((Matr.GetLength(0) / 2) - (Choix.Length * 5) / 3) + i * 2), (Matr.GetLength(1) / 2) + 5] = Choix[i].ToString();
                }
            }
            else
            {
                for (int i = (Matr.GetLength(0) / 2) - 20; i < (Matr.GetLength(0) / 2) + 22; i += 2)
                {
                    Matr[i, (Matr.GetLength(1) / 2) + 8] = "─";
                    Matr[i, (Matr.GetLength(1) / 2) - 8] = "─";
                }
                for (int j = (Matr.GetLength(1) / 2) - 7; j < (Matr.GetLength(1)) / 2 + 8; j++)
                {
                    Matr[(Matr.GetLength(0) / 2) + 22, j] = "│";
                    Matr[(Matr.GetLength(0) / 2) - 22, j] = "│";
                }
                Matr[(Matr.GetLength(0) / 2) + 22, (Matr.GetLength(1) / 2) + 8] = "┘";
                Matr[(Matr.GetLength(0) / 2) - 22, (Matr.GetLength(1) / 2) + 8] = "└";
                Matr[(Matr.GetLength(0) / 2) + 22, (Matr.GetLength(1) / 2) - 8] = "┐";
                Matr[(Matr.GetLength(0) / 2) - 22, (Matr.GetLength(1) / 2) - 8] = "┌";

                for (int i = 0; i < Questions.Length; i++)
                {
                    Matr[(((Matr.GetLength(0) / 2) - Questions.Length) + i * 2)+1, (Matr.GetLength(1) / 2) - 7] = Questions[i].ToString();
                }

                for (int i = 0; i < Choix.Length / 3 ; i++)
                {
                    Matr[(((Matr.GetLength(0) / 2) - Choix.Length / 3) + i * 2) + 1, (Matr.GetLength(1) / 2) - 3] = Choix[i].ToString();
                }
                for (int i = Choix.Length / 3; i < Choix.Length / 1.5; i++)
                {
                    Matr[(((Matr.GetLength(0) / 2) - Choix.Length) + i * 2) + 1, (Matr.GetLength(1) / 2) + 1] = Choix[i].ToString();
                }
                for (int i = (Choix.Length*2)/3; i < Choix.Length; i++)
                {
                    Matr[(((Matr.GetLength(0) / 2) - (Choix.Length*5)/3) + i * 2) + 1, (Matr.GetLength(1) / 2) + 5] = Choix[i].ToString();
                }

                if(select == 0)
                {
                    Matr[(Matr.GetLength(0) / 2) - 10, (Matr.GetLength(1) / 2) - 3] = ">";
                    Matr[(Matr.GetLength(0) / 2) + 10, (Matr.GetLength(1) / 2) - 3] = "<";
                }else if (select == 1)
                {
                    Matr[(Matr.GetLength(0) / 2) - 10, (Matr.GetLength(1) / 2) + 1] = ">";
                    Matr[(Matr.GetLength(0) / 2) + 10, (Matr.GetLength(1) / 2) + 1] = "<";
                }else if (select == 2)
                {
                    Matr[(Matr.GetLength(0) / 2) - 10, (Matr.GetLength(1) / 2) + 5] = ">";
                    Matr[(Matr.GetLength(0) / 2) + 10, (Matr.GetLength(1) / 2) + 5] = "<";
                }
            }
        }
        public void Regles(string[,] Matr, bool Dev)
        {
            string[] regleTXT = new string[17];
            regleTXT[0] = "Le UNO est très simple. Vous devez juste :";
            regleTXT[1] = " ";
            regleTXT[2] = "Vous pouvez uniquement jouer si la carte est :";
            regleTXT[3] = " - De même couleur que celle au milieu.";
            regleTXT[4] = " - De même nombre que celle au milieu.";
            regleTXT[5] = " - De même couleur et nombre que celle au milieu.";
            regleTXT[6] = " - Ou juste de couleur noire (en jeu elle sera blanche).";
            regleTXT[7] = " ";
            regleTXT[8] = "Si vous ne pouvez pas la jouer, piochez une carte.";
            regleTXT[9] = " ";
            regleTXT[10] = "Cartes spéciales :";
            regleTXT[11] = " - La carte '+2' fait prendre deux cartes et passe le tour du joueur suivant.";
            regleTXT[12] = " - La carte '+4' fait prendre quatre cartes et passe le tour du joueur suivant.";
            regleTXT[13] = "   Grâce à elle, vous pouvez également changer la couleur du jeu.";
            regleTXT[14] = " - La carte 'passe ton tour' fait passer le tour du joueur suivant";
            regleTXT[15] = " - La carte 'changer de sens' fait changer le sens du jeu.";
            regleTXT[16] = " - La carte 'changer de couleur' vous fait changer la couleur du jeu.";

            if (Dev == false)
            {
                for (int j = 0; j < regleTXT.Length; j++)
                {
                    for (int k = 0; k < regleTXT[j].Length; k++)
                    {
                        Matr[(k + 2) * 2, j + 1] = char.ToString(regleTXT[j][k]);
                    }
                }
            }
            if (Dev == true)
            {
                for (int j = 0; j < regleTXT.Length; j++)
                {
                    for (int k = 0; k < regleTXT[j].Length; k++)
                    {
                        Matr[(k + 2) * 2, j + 3] = char.ToString(regleTXT[j][k]);
                    }
                }
            }

            

            Matr[Matr.GetLength(0) - 18, Matr.GetLength(1) - 2] = "[";
            Matr[Matr.GetLength(0) - 16, Matr.GetLength(1) - 2] = "E";
            Matr[Matr.GetLength(0) - 14, Matr.GetLength(1) - 2] = "n";
            Matr[Matr.GetLength(0) - 12, Matr.GetLength(1) - 2] = "t";
            Matr[Matr.GetLength(0) - 10, Matr.GetLength(1) - 2] = "e";
            Matr[Matr.GetLength(0) - 8, Matr.GetLength(1) - 2] = "r";
            Matr[Matr.GetLength(0) - 6, Matr.GetLength(1) - 2] = "]";
        }
    }
}