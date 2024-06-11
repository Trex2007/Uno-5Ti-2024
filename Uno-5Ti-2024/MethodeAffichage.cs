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
using static Test6._0.MethodeAffichage;
using System.Runtime.Loader;
using System.Transactions;
using System.Threading.Tasks.Dataflow;

namespace Test6._0
{
    public struct MethodeAffichage
    {
        /// <summary>
        /// Scene de victoire
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        public void gagner(string[,] Matr)
        {
            if (Console.WindowWidth > 100 && Console.WindowHeight > 24)
            {
                string[] Titre = new string[6];
                Titre[0] = " ██████╗  █████╗  ██████╗ ███╗  ██╗███████╗  ██╗";
                Titre[1] = "██╔════╝ ██╔══██╗██╔════╝ ████╗ ██║██╔════╝  ██║";
                Titre[2] = "██║  ██╗ ███████║██║  ██╗ ██╔██╗██║█████╗    ██║";
                Titre[3] = "██║  ╚██╗██╔══██║██║  ╚██╗██║╚████║██╔══╝    ╚═╝";
                Titre[4] = "╚██████╔╝██║  ██║╚██████╔╝██║ ╚███║███████╗  ██╗";
                Titre[5] = " ╚═════╝ ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚══╝╚══════╝  ╚═╝";


                for (int i = 0; i < Titre.Length; i++)
                {
                    for (int j = 0; j < Titre[i].Length * 2; j += 2)
                    {
                        int row = ((Matr.GetLength(0) / 2) - (Titre[i].Length)) + j;
                        int col = ((Matr.GetLength(1) / 2) - 10) + i;

                        if (row >= 0 && row < Matr.GetLength(0) && col >= 0 && col < Matr.GetLength(1))
                        {
                            if ((Matr.GetLength(0) / 2) % 2 != 0)
                            {
                                Matr[row + 1, col] = Titre[i][j / 2].ToString();
                            }
                            else
                            {
                                Matr[row, col] = Titre[i][j / 2].ToString();
                            }
                        }
                    }
                }

                Titre[0] = "       y       y        y    y    y       y    y";
                Titre[1] = "  yyyyyy   yyy  y  yyyyyy     y   y  yyyyyy    y";
                Titre[2] = "  y    y        y  y    y   y  y  y     y      y";
                Titre[3] = "  y  y  y  yyy  y  y  y  y  yy    y  yyyy    yyy";
                Titre[4] = "y      yy  y    yy      yy  y y   y       y    y";
                Titre[5] = " yyyyyyy yyy  yyy yyyyyyy yyy  yyyyyyyyyyyy  yyy";

                for (int i = 0; i < Titre.Length; i++)
                {
                    for (int j = 1; j < Titre[i].Length * 2; j += 2)
                    {
                        int row = ((Matr.GetLength(0) / 2) - (Titre[i].Length)) + j;
                        int col = ((Matr.GetLength(1) / 2) - 10) + i;

                        if (row >= 0 && row < Matr.GetLength(0) && col >= 0 && col < Matr.GetLength(1))
                        {
                            if ((Matr.GetLength(0) / 2) % 2 != 0)
                            {
                                Matr[row + 1, col] = Titre[i][j / 2].ToString();
                            }
                            else
                            {
                                Matr[row, col] = Titre[i][j / 2].ToString();
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Scene de perdant
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        public void perdu(string[,] Matr)
        {
            if (Console.WindowWidth > 100 && Console.WindowHeight > 24)
            {
                string[] Titre = new string[6];
                Titre[0] = "██████╗ ███████╗██████╗ ██████╗ ██╗   ██╗         ";
                Titre[1] = "██╔══██╗██╔════╝██╔══██╗██╔══██╗██║   ██║         ";
                Titre[2] = "██████╔╝█████╗  ██████╔╝██║  ██║██║   ██║         ";
                Titre[3] = "██╔═══╝ ██╔══╝  ██╔══██╗██║  ██║██║   ██║         ";
                Titre[4] = "██║     ███████╗██║  ██║██████╔╝╚██████╔╝██╗██╗██╗";
                Titre[5] = "╚═╝     ╚══════╝╚═╝  ╚═╝╚═════╝  ╚═════╝ ╚═╝╚═╝╚═╝";


                for (int i = 0; i < Titre.Length; i++)
                {
                    for (int j = 0; j < Titre[i].Length * 2; j += 2)
                    {
                        int row = ((Matr.GetLength(0) / 2) - (Titre[i].Length)) + j;
                        int col = ((Matr.GetLength(1) / 2) - 10) + i;

                        if (row >= 0 && row < Matr.GetLength(0) && col >= 0 && col < Matr.GetLength(1))
                        {
                            if ((Matr.GetLength(0) / 2) % 2 != 0)
                            {
                                Matr[row + 1, col] = Titre[i][j / 2].ToString();
                            }
                            else
                            {
                                Matr[row, col] = Titre[i][j / 2].ToString();
                            }
                        }
                    }
                }

                Titre[0] = "      r        r      r       r   r     r         ";
                Titre[1] = "  rrr  r  rrrrrr  rrr  r  rrr  r  r     r         ";
                Titre[2] = "      rr     r        rr  r    r  r     r         ";
                Titre[3] = "  rrrrr   rrrr    rrr  r  r    r  r     r         ";
                Titre[4] = "  r            r  r    r      rrr      rr  r  r  r";
                Titre[5] = "rrr     rrrrrrrrrrr  rrrrrrrrrr  rrrrrrr rrrrrrrrr";

                for (int i = 0; i < Titre.Length; i++)
                {
                    for (int j = 1; j < Titre[i].Length * 2; j += 2)
                    {
                        int row = ((Matr.GetLength(0) / 2) - (Titre[i].Length)) + j;
                        int col = ((Matr.GetLength(1) / 2) - 10) + i;

                        if (row >= 0 && row < Matr.GetLength(0) && col >= 0 && col < Matr.GetLength(1))
                        {
                            if ((Matr.GetLength(0) / 2) % 2 != 0)
                            {
                                Matr[row + 1, col] = Titre[i][j / 2].ToString();
                            }
                            else
                            {
                                Matr[row, col] = Titre[i][j / 2].ToString();
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// question de chanement de couleur
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        /// <param name="boucleOuNon"> pour voir si il s'affiche ou non </param>
        public void ChangementCouleur(string[,] Matr, bool boucleOuNon)
        {
            string Choixs1 = "Rouge   Vert   Bleu   Jaune";
            string Choixs2 = " [A]    [B]    [C]     [D] ";
            while (boucleOuNon)
            {
                if ((Matr.GetLength(0) / 2) % 2 != 0)
                {
                    for (int i = 0; i < Choixs1.Length; i++)
                    {
                        Matr[((Matr.GetLength(0) / 2) - Choixs1.Length) + i * 2, (Matr.GetLength(1) / 2) + 5] = Choixs1[i].ToString();
                        Matr[((Matr.GetLength(0) / 2) - Choixs1.Length) + i * 2, (Matr.GetLength(1) / 2) + 6] = Choixs2[i].ToString();
                    }
                }
                else
                {
                    for (int i = 0; i < Choixs1.Length; i++)
                    {
                        Matr[(((Matr.GetLength(0) / 2) - Choixs1.Length) + i * 2)+1, (Matr.GetLength(1) / 2) + 5] = Choixs1[i].ToString();
                        Matr[(((Matr.GetLength(0) / 2) - Choixs1.Length) + i * 2)+1, (Matr.GetLength(1) / 2) + 6] = Choixs2[i].ToString();
                    }
                }
            }
        }
        /// <summary>
        /// réinitialiser les couleurs de l'écran
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        public void ResetColor(string[,] Matr)
        {
            for (int i = 1; i < Matr.GetLength(1) - 1; i++)
            {
                for (int j = 1; j < Matr.GetLength(0); j += 2)
                {
                    Matr[j, i] = "";
                }
            }
        }
        /// <summary>
        /// Bordures de l'écran
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
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
        /// <summary>
        /// Menu principale quand on arrive en jeux
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        /// <param name="Dev"> le débug </param>
        public void menuPrincipal(string[,] Matr, bool Dev)
        {
            if (Console.WindowWidth > 100 && Console.WindowHeight > 24)
            {
                string[] Titre = new string[6];
                Titre[0] = "██╗   ██╗███╗  ██╗██╗██╗   ██╗███████╗██████╗  ██████╗ █████╗ ██╗       ██╗   ██╗███╗  ██╗ █████╗ ";
                Titre[1] = "██║   ██║████╗ ██║██║██║   ██║██╔════╝██╔══██╗██╔════╝██╔══██╗██║       ██║   ██║████╗ ██║██╔══██╗";
                Titre[2] = "██║   ██║██╔██╗██║██║╚██╗ ██╔╝█████╗  ██████╔╝╚█████╗ ███████║██║       ██║   ██║██╔██╗██║██║  ██║";
                Titre[3] = "██║   ██║██║╚████║██║ ╚████╔╝ ██╔══╝  ██╔══██╗ ╚═══██╗██╔══██║██║       ██║   ██║██║╚████║██║  ██║";
                Titre[4] = "╚██████╔╝██║ ╚███║██║  ╚██╔╝  ███████╗██║  ██║██████╔╝██║  ██║███████╗  ╚██████╔╝██║ ╚███║╚█████╔╝";
                Titre[5] = " ╚═════╝ ╚═╝  ╚══╝╚═╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝╚══════╝   ╚═════╝ ╚═╝  ╚══╝ ╚════╝ ";


                for (int i = 0; i < Titre.Length; i++)
                {
                    for (int j = 0; j < Titre[i].Length * 2; j += 2)
                    {
                        int row = ((Matr.GetLength(0) / 2) - (Titre[i].Length)) + j;
                        int col = ((Matr.GetLength(1) / 2) - 10) + i;

                        if (row >= 0 && row < Matr.GetLength(0) && col >= 0 && col < Matr.GetLength(1))
                        {
                            if ((Matr.GetLength(0) / 2) % 2 != 0)
                            {
                                Matr[row + 1, col] = Titre[i][j / 2].ToString();
                            }
                            else
                            {
                                Matr[row, col] = Titre[i][j / 2].ToString();
                            }
                        }
                    }
                }

                Titre[0] = "  r     r   v    v  y  b     b       r      v        y      b   r         v     v   y    y      b ";
                Titre[1] = "  r     r    v   v  y  b     b  rrrrrr  vvv  v  yyyyyy  bbb  b  r         v     v    y   y  bbb  b";
                Titre[2] = "  r     r  v  v  v  yb  b   bb     r        vvy     y        b  r         v     v  y  y  y  b    b";
                Titre[3] = "  r     r  vv    v  y b    bb   rrrr    vvv  v yyyy  y  bbb  b  r         v     v  yy    y  b    b";
                Titre[4] = "r      rr  v v   v  y  b  bb         r  v    v      yy  b    b       r  v      vv  y y   yb     bb";
                Titre[5] = " rrrrrrr vvv  vvvvyyy   bbb   rrrrrrrrvvv  vvvyyyyyyy bbb  bbbrrrrrrrr   vvvvvvv yyy  yyyy bbbbbb ";

                for (int i = 0; i < Titre.Length; i++)
                {
                    for (int j = 1; j < Titre[i].Length * 2; j += 2)
                    {
                        int row = ((Matr.GetLength(0) / 2) - (Titre[i].Length)) + j;
                        int col = ((Matr.GetLength(1) / 2) - 10) + i;

                        if (row >= 0 && row < Matr.GetLength(0) && col >= 0 && col < Matr.GetLength(1))
                        {
                            if ((Matr.GetLength(0) / 2) % 2 != 0)
                            {
                                Matr[row + 1, col] = Titre[i][j / 2].ToString();
                            }
                            else
                            {
                                Matr[row, col] = Titre[i][j / 2].ToString();
                            }
                        }
                    }
                }
            }
            if (Console.WindowWidth > 81 && Console.WindowHeight > 24)
            {
                string entrerPhrase = "Pressez [ENTER] pour rentrer dans le jeux.";

                for (int j = 0; j < entrerPhrase.Length * 2; j += 2)
                {
                    if ((Matr.GetLength(0) / 2) % 2 != 0)
                    {
                        Matr[(((Matr.GetLength(0) / 2) - (entrerPhrase.Length)) + j) + 1, (Matr.GetLength(1) / 2) + 5] = entrerPhrase[j / 2].ToString();
                    }
                    else
                    {
                        Matr[((Matr.GetLength(0) / 2) - (entrerPhrase.Length)) + j, (Matr.GetLength(1) / 2) + 5] = entrerPhrase[j / 2].ToString();
                    }
                }
            }
        }
        /// <summary>
        /// Variable pour compter les fps
        /// </summary>
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
        /// <summary>
        /// débug pour voir des infos d'aide au dev
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        /// <param name="Dev"> le débug </param>
        /// <param name="ipsCounter"> nombre d'fps/secondes </param>
        /// <param name="RefreshTime"> taux de rafraichissement </param>
        /// <param name="OnceInTwoWhile"> qui ne s'affiche que une fois </param>
        public void Debug(string[,] Matr, IPSCounter ipsCounter, bool Dev, int RefreshTime, bool OnceInTwoWhile)
        {
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
                        Matr[15, 1] = "";
                    }
                    if (ipsCounter.IPS > 99)
                    {
                        Matr[17, 1] = "r";
                    }
                    else
                    {
                        Matr[17, 1] = "";
                    }
                }
                else if (ipsCounter.IPS >= 20)
                {
                    Matr[13, 1] = "v";
                    Matr[15, 1] = "v";
                    if (ipsCounter.IPS > 99)
                    {
                        Matr[17, 1] = "v";
                    }
                    else
                    {
                        Matr[17, 1] = "";
                    }
                }

                Matr[12, 1] = ipsCounter.IPS.ToString(); ;

                if (ipsCounter.IPS > 9)
                {
                    Matr[14, 1] = "";
                }
                else
                {
                    Matr[14, 1] = " ";
                }

                if (ipsCounter.IPS > 99)
                {
                    Matr[16, 1] = "";
                }
                else
                {
                    Matr[16, 1] = " ";
                }

                if (ipsCounter.IPS > 999)
                {
                    Matr[18, 1] = "";
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
                Matr[48, 1] = "";
                if (Console.WindowWidth > 99)
                {
                    Matr[50, 1] = "";
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
                Matr[86, 1] = "";
                if (Console.WindowHeight > 99)
                {
                    Matr[88, 1] = "";
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
                    Matr[120, 1] = "";
                }
                else
                {
                    Matr[120, 1] = " ";
                }
                if (RefreshTime > 99)
                {
                    Matr[122, 1] = "";
                }
                else
                {
                    Matr[122, 1] = " ";
                }

                OnceInTwoWhile = true;
            }
            else
            {
                if (OnceInTwoWhile)
                {
                    Matr[13, 1] = "";
                    Matr[15, 1] = "";
                    Matr[17, 1] = "";
                    Bordures(Matr);
                    OnceInTwoWhile = false;
                }
            }
        }
        /// <summary>
        /// afficher toute la matrice d'affichage aves les couleurs
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        /// <param name="RefreshTime"> taux de rafraichissement </param>
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
                            Console.ForegroundColor = colorToPrint;
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
                Console.WriteLine("\n La taille n'est pas valide, veuillez agrandir la fenètre.");
            }
        }
        /// <summary>
        /// choix des couleurs
        /// </summary>
        /// <param name="matrix"> matrice d'affichage (pour question pratique elle ne s'apellera pas Matr)</param>
        /// <param name="row"> longueur </param>
        /// <param name="col"> largeur </param>
        /// <returns> la couleur </returns>
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
            else if (nextRow < matrix.GetLength(0) && matrix[nextRow, col] == "v")
            {
                return ConsoleColor.DarkGreen;
            }
            else if (nextRow < matrix.GetLength(0) && matrix[nextRow, col] == "b")
            {
                return ConsoleColor.DarkBlue;
            }
            else
            {
                return ConsoleColor.White;
            }
        }
        /// <summary>
        /// question de jeux pour facilité la suite de jeux
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        /// <param name="Questions"> question a posé </param>
        /// <param name="Choix"> choix de la question posé </param>
        /// <param name="select"> savoir ou il en est pour mettre les fleches et lui afficher </param>
        public void Questions(string[,] Matr, string Questions, string Choix, uint select)
        {
            if ((Matr.GetLength(0) / 2) % 2 != 0)
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
                if (select == 0)
                {
                    Matr[(Matr.GetLength(0) / 2) - 11, (Matr.GetLength(1) / 2) - 3] = ">";
                    Matr[(Matr.GetLength(0) / 2) + 9, (Matr.GetLength(1) / 2) - 3] = "<";
                }
                else if (select == 1)
                {
                    Matr[(Matr.GetLength(0) / 2) - 11, (Matr.GetLength(1) / 2) + 1] = ">";
                    Matr[(Matr.GetLength(0) / 2) + 9, (Matr.GetLength(1) / 2) + 1] = "<";
                }
                else if (select == 2)
                {
                    Matr[(Matr.GetLength(0) / 2) - 11, (Matr.GetLength(1) / 2) + 5] = ">";
                    Matr[(Matr.GetLength(0) / 2) + 9, (Matr.GetLength(1) / 2) + 5] = "<";
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
                    Matr[(((Matr.GetLength(0) / 2) - Questions.Length) + i * 2) + 1, (Matr.GetLength(1) / 2) - 7] = Questions[i].ToString();
                }

                for (int i = 0; i < Choix.Length / 3; i++)
                {
                    Matr[(((Matr.GetLength(0) / 2) - Choix.Length / 3) + i * 2) + 1, (Matr.GetLength(1) / 2) - 3] = Choix[i].ToString();
                }
                for (int i = Choix.Length / 3; i < Choix.Length / 1.5; i++)
                {
                    Matr[(((Matr.GetLength(0) / 2) - Choix.Length) + i * 2) + 1, (Matr.GetLength(1) / 2) + 1] = Choix[i].ToString();
                }
                for (int i = (Choix.Length * 2) / 3; i < Choix.Length; i++)
                {
                    Matr[(((Matr.GetLength(0) / 2) - (Choix.Length * 5) / 3) + i * 2) + 1, (Matr.GetLength(1) / 2) + 5] = Choix[i].ToString();
                }

                if (select == 0)
                {
                    Matr[(Matr.GetLength(0) / 2) - 10, (Matr.GetLength(1) / 2) - 3] = ">";
                    Matr[(Matr.GetLength(0) / 2) + 10, (Matr.GetLength(1) / 2) - 3] = "<";
                }
                else if (select == 1)
                {
                    Matr[(Matr.GetLength(0) / 2) - 10, (Matr.GetLength(1) / 2) + 1] = ">";
                    Matr[(Matr.GetLength(0) / 2) + 10, (Matr.GetLength(1) / 2) + 1] = "<";
                }
                else if (select == 2)
                {
                    Matr[(Matr.GetLength(0) / 2) - 10, (Matr.GetLength(1) / 2) + 5] = ">";
                    Matr[(Matr.GetLength(0) / 2) + 10, (Matr.GetLength(1) / 2) + 5] = "<";
                }
            }
        }
        /// <summary>
        /// affichage des regles de jeux
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        /// <param name="Dev"> pour savoir quand le debug est allumer pour décaler le texte </param>
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
                Matr[52, 1] = " ";
                Matr[54, 1] = " ";
                for (int j = 0; j < regleTXT.Length; j++)
                {
                    for (int k = 0; k < regleTXT[j].Length; k++)
                    {
                        Matr[(k + 2) * 2, j + 3] = char.ToString(regleTXT[j][k]);
                        Matr[(k + 2) * 2, 1 + 3] = " ";
                        Matr[(k + 2) * 2, 7 + 3] = " ";
                        Matr[(k + 2) * 2, 9 + 3] = " ";
                    }
                    for (int k = 0; k < 20; k++)
                    {
                        Matr[(k + 43) * 2, 3] = " ";
                        Matr[(k + 41) * 2, 6] = " ";
                        Matr[(k + 40) * 2, 7] = " ";
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
        /// <summary>
        /// pareil que les regles mais pour des infos supplémentaires
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        public void commentJouer(string[,] Matr)
        {
            string[] regleTXT = new string[17];
            regleTXT[0] = "Cartes :";
            regleTXT[1] = " ";
            regleTXT[2] = "<-> : Changer de sens";
            regleTXT[3] = " X  : Passer le tour du joueur suivant";
            regleTXT[4] = "<*> : Changer de couleurs";
            regleTXT[5] = " ";
            regleTXT[6] = "La lettre en dessous de chaque carte est la lettre sur";
            regleTXT[7] = "laquelle vous devez appuyez 2x pour la poser";
            regleTXT[8] = " ";
            regleTXT[9] = "Lors de l'appui sur la touche [z] 2x vous";
            regleTXT[10] = "piocherez une carte";
            regleTXT[11] = " ";
            regleTXT[12] = " ";
            regleTXT[13] = " ";
            regleTXT[14] = " ";
            regleTXT[15] = " ";
            regleTXT[16] = " ";

            for (int j = 0; j < regleTXT.Length; j++)
            {
                for (int k = 0; k < regleTXT[j].Length; k++)
                {
                    Matr[(k + 2) * 2, j + 1] = char.ToString(regleTXT[j][k]);
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
        /// <summary>
        /// Affichage total du jeux
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        /// <param name="cartes"> cartes de tous les joueurs </param>
        /// <param name="carteCentrale"> carte central de jeux </param>
        public void jeux(string[,] Matr, int[,] cartes, int[] carteCentrale)
        {

            string[] shemaCarte = new string[6];

            if (carteCentrale[1] != 0)
            {
                if (carteCentrale[0] < 10)
                {
                    shemaCarte[3] = "    /    | " + carteCentrale[0] + " |    /";
                }
                else if (carteCentrale[0] == 10)
                {
                    shemaCarte[3] = "    /    |<->|    /";
                }
                else if (carteCentrale[0] == 11)
                {
                    shemaCarte[3] = "    /    | X |    /";
                }
                else if (carteCentrale[0] == 12)
                {
                    shemaCarte[3] = "    /    |+2 |    /";
                }
            }
            else
            {
                if (carteCentrale[0] < 11)
                {
                    shemaCarte[3] = "    /    |<*>|    /";
                }
                else
                {
                    shemaCarte[3] = "    /    |+4 |    /";
                }
            }


            shemaCarte[0] = "         ______________";
            shemaCarte[1] = "        /             /";
            shemaCarte[2] = "      /    / ¯\\     /";
            shemaCarte[4] = "  /     \\_ /    /";
            shemaCarte[5] = "/_____________/";


            for (int j = 0; j < shemaCarte.Length; j++)
            {
                for (int i = 0; i < shemaCarte[j].Length; i++)
                {
                    int x = ((Matr.GetLength(0)/4) - (shemaCarte[j].Length / 2) + i)*2;
                    int y = (Matr.GetLength(1) / 2) - (shemaCarte.Length / 2) + j;
                    if (x >= 0 && x < Matr.GetLength(0) && y >= 0 && y < Matr.GetLength(1))
                    {
                        Matr[x, y-1] = shemaCarte[j][i].ToString();
                    }
                }
            }
            string colorLtr = "w";
            if (carteCentrale[1] == 0)
            {
                colorLtr = "w";
            }
            else if (carteCentrale[1] == 1)
            {
                colorLtr = "r";
            } else if (carteCentrale[1] == 2)
            {
                colorLtr = "v";
            }
            else if (carteCentrale[1] == 3)
            {
                colorLtr = "b";
            }
            else if (carteCentrale[1] == 4)
            {
                colorLtr = "y";
            }
            for (int j = 0; j < shemaCarte.Length; j++)
            {
                for (int i = 0; i < shemaCarte[j].Length; i++)
                {
                    int x = ((Matr.GetLength(0) / 4) - (shemaCarte[j].Length / 2) + i) * 2;
                    int y = (Matr.GetLength(1) / 2) - (shemaCarte.Length / 2) + j;
                    if (x >= 0 && x < Matr.GetLength(0) && y >= 0 && y < Matr.GetLength(1))
                    {
                        Matr[x+1, y - 1] = colorLtr;
                    }
                }
            }




            int loc = 0;
            while (loc < cartes.GetLength(0) && cartes[loc, 0] != 99)
            {
                loc++;
            }

            if (loc == 1)
            {
                Matr[2, 1] = "U";
                Matr[4, 1] = "N";
                Matr[6, 1] = "O";
                Matr[8, 1] = "!";
            }

            shemaCarte = new string[5];
            int nbrcases = 0;
            int dernière = 0;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (Console.WindowWidth > 10+loc*4)
            {
                for (int i = 0; i < loc; i++)
                {
                    shemaCarte[0] = "@───";
                    if (cartes[i,1] != 0)
                    {
                        if (cartes[i, 0] < 10)
                        {
                            shemaCarte[1] = "│ " + cartes[i, 0] + " ";
                        }
                        else if (cartes[i, 0] == 10)
                        {
                            shemaCarte[1] = "│<->";
                        }
                        else if (cartes[i, 0] == 11)
                        {
                            shemaCarte[1] = "│ X ";
                        }
                        else if (cartes[i, 0] == 12)
                        {
                            shemaCarte[1] = "│+2 ";
                        }
                    } else 
                    {
                        if (cartes[i, 0] < 11)
                        {
                            shemaCarte[1] = "│<*>";
                        }
                        else
                        {
                            shemaCarte[1] = "│+4 ";
                        }
                    }
                    
                    shemaCarte[2] = "│   ";
                    shemaCarte[3] = "│[" + alphabet[i] + "]";
                    shemaCarte[4] = "┴───";

                    for (int j = 0; j < shemaCarte.Length; j++)
                    {
                        for (int h = 0; h < shemaCarte[j].Length; h++)
                        {
                            int x = ((Matr.GetLength(0) / 4) - (loc * 2)) + h + nbrcases;
                            int y = ((Matr.GetLength(1) - 5) + j);

                            Matr[x * 2, y] = shemaCarte[j][h].ToString();
                            if (cartes[i, 1] == 0)
                            {
                                Matr[(x * 2) + 1, y] = "w";
                                dernière = 0;
                            }
                            else if (cartes[i, 1] == 1)
                            {
                                Matr[(x * 2) + 1, y] = "r";
                                dernière = 1;
                            }
                            else if (cartes[i, 1] == 2)
                            {
                                Matr[(x * 2) + 1, y] = "v";
                                dernière = 2;
                            }
                            else if (cartes[i, 1] == 3)
                            {
                                Matr[(x * 2) + 1, y] = "b";
                                dernière = 3;
                            }
                            else
                            {
                                Matr[(x * 2) + 1, y] = "y";
                                dernière = 4;
                            }
                        }
                    }
                    nbrcases += 4;
                }
                shemaCarte[0] = "@";
                shemaCarte[1] = "│";
                shemaCarte[2] = "│";
                shemaCarte[3] = "│";
                int locCol = 0;
                for (int j = 0; j < shemaCarte.Length; j++)
                {
                    for (int h = 0; h < shemaCarte[j].Length; h++)
                    {
                        int x = ((Matr.GetLength(0) / 4) - (loc * 2)) + h + nbrcases;
                        int y = ((Matr.GetLength(1) - 5) + j);
                        Matr[x * 2, y] = shemaCarte[j][h].ToString();
                        if(locCol == 0)
                        {
                            if (dernière == 0)
                            {
                                Matr[(x * 2) + 1, y] = "w";
                            }
                            else if (dernière == 1)
                            {
                                Matr[(x * 2) + 1, y] = "r";
                            }
                            else if (dernière == 2)
                            {
                                Matr[(x * 2) + 1, y] = "v";
                            }
                            else if (dernière == 3)
                            {
                                Matr[(x * 2) + 1, y] = "b";
                            }
                            else
                            {
                                Matr[(x * 2) + 1, y] = "y";
                            }
                        }
                        locCol = 1;
                    }
                    locCol = 0;
                }
            } else
            {
                string texte = "Ecran trop petit pour afficher vôtre jeux.";
                for (int i = 0; i < texte.Length*2; i += 2)
                {
                    Matr[2+i, Matr.GetLength(1)-2] = texte[i/2].ToString();
                }
            }
            

            nbrcases = 0;

            for (int w = 1;w < cartes.GetLength(1) / 2; w++)
            {
                loc = 0;
                while (loc < cartes.GetLength(0) && cartes[loc, w+1] != 99)
                {
                    loc++;
                }
                shemaCarte = new string[5];

                if (loc < 10)
                {
                    shemaCarte[0] = "┬─────┬";
                    shemaCarte[1] = "│     │";
                    shemaCarte[2] = "│  " + loc + "  │";
                    shemaCarte[3] = "│     │";
                    shemaCarte[4] = "@─────@";
                }
                else
                {
                    shemaCarte[0] = "┬─────┬";
                    shemaCarte[1] = "│     │";
                    shemaCarte[2] = "│  " + loc + " │";
                    shemaCarte[3] = "│     │";
                    shemaCarte[4] = "@─────@";
                }

                int ecart = 0;
                if (cartes.GetLength(1) > 4)
                {
                    ecart = cartes.GetLength(1) * 2;
                }
                

                for (int j = 0; j < shemaCarte.Length; j++)
                {
                    for (int i = 0; i < shemaCarte[j].Length*2; i+=2)
                    {
                        int x = (((Matr.GetLength(0) / 2) + i) + nbrcases*20 - ecart);
                        int y = j;
                        if (x >= 0 && x < Matr.GetLength(0) && y >= 0 && y < Matr.GetLength(1))
                        {
                            if ((Matr.GetLength(0) / 2) % 2 != 0)
                            {
                                Matr[x - 1, y] = shemaCarte[j][i / 2].ToString();
                            } else
                            {
                                Matr[x, y] = shemaCarte[j][i / 2].ToString();
                            }
                        }
                    }
                }
                nbrcases++;
            }
        }
    }
}