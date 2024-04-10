using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5T24_BrahyAdrien_Uno
{
    public struct methodeAffichage
    {
        public void OptAffichage(ref string[,] matrAff)
        {
            Console.Clear();
            for (int i = 0; i < matrAff.GetLength(1); i ++)
            {
                for (int j = 0; j < matrAff.GetLength(0); j += 2)
                {
                    if (matrAff[j + 1, i] == null || matrAff[j + 1, i] == "" || matrAff[j + 1, i] == " ")
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        // couleur background
                        if (char.ToString(matrAff[j + 1, i][0]) == "r")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                        }
                        else if (char.ToString(matrAff[j + 1, i][0]) == "g")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                        else if (char.ToString(matrAff[j + 1, i][0]) == "b")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                        else if (char.ToString(matrAff[j + 1, i][0]) == "y")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                        }
                    }

                        // couleur texte
                    if (matrAff[j + 1, i] == null || matrAff[j + 1, i] == "" || matrAff[j + 1, i] == " ")
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        } 
                    else {

                        if (char.ToString(matrAff[j + 1, i][1]) == "w")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (char.ToString(matrAff[j + 1, i][1]) == "b")
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    


                    Console.Write(matrAff[j, i]);
                    Console.ResetColor();
                }
            Console.Write('\n');
            }
        }
        public void BordureAffichage(ref string[,] matrAff)
        {
            matrAff[0, 0] = "@";
            for (int i = 2; i < matrAff.GetLength(0) - 2; i += 2)
            {
                matrAff[i, 0] = "-";
            }
            matrAff[248, 0] = "@";


            for (int l = 1; l < matrAff.GetLength(1) - 1; l++)
            {
                matrAff[0, l] = "|";
                for (int j = 2; j < matrAff.GetLength(0) - 2; j += 2)
                {
                    matrAff[j, l] = " ";
                }
                matrAff[248, l] = "|";
            }


            matrAff[0, 39] = "@";
            for (int k = 2; k < matrAff.GetLength(0) - 2; k += 2)
            {
                matrAff[k, 39] = "-";
            }
            matrAff[248, 39] = "@";
        }
        public void AskQuestion(string question, string choixQuestions , string[,] matrAff)
        {
            
            BordureAffichage(ref matrAff);

            for (int i = 74; i < 175; i+= 2)
            {
                matrAff[i, 15] = "-";
                for (int j = 16;j < 25; j ++)
                {
                    matrAff[74, j] = "|";
                    matrAff[174, j] = "|";
                }
                matrAff[i, 25] = "-";
            }
            matrAff[74, 15] = "@";
            matrAff[174, 15] = "@";
            matrAff[74, 25] = "@";
            matrAff[174, 25] = "@";
            int k = 0;
            for (int i = 78; i < 172 ; i+=2)
            {
                matrAff[i, 17] = char.ToString(question[k]);
                if (k < question.Length-1)
                {
                    k++;
                } else
                {
                    k = 0;
                    question = " ";
                } 
            }

            matrAff[110, 21] = char.ToString(choixQuestions[0]);
            matrAff[112, 21] = char.ToString(choixQuestions[1]);
            matrAff[114, 21] = char.ToString(choixQuestions[2]);

            matrAff[130, 21] = char.ToString(choixQuestions[3]);
            matrAff[132, 21] = char.ToString(choixQuestions[4]);
            matrAff[134, 21] = char.ToString(choixQuestions[5]);

            matrAff[158, 24] = "[";
            matrAff[160, 24] = "E";
            matrAff[162, 24] = "n";
            matrAff[164, 24] = "t";
            matrAff[166, 24] = "e";
            matrAff[168, 24] = "r";
            matrAff[170, 24] = "]";

            OptAffichage(ref matrAff);
        }
        public void Regles(string[,] matrAff)
        {
            BordureAffichage(ref matrAff);

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

            int k = 0;
            for (int j = 3; j < 20;  j++)
            {
                for (int i = 12; i < 172; i += 2)
                {
                    matrAff[i, j] = char.ToString(regleTXT[j-3][k]);
                    if (k < regleTXT[j-3].Length - 1)
                    {
                        k++;
                    }
                    else
                    {
                        k = 0;
                        regleTXT[j - 3] = " ";
                    }
                }
            }
            matrAff[232, 38] = "[";
            matrAff[234, 38] = "E";
            matrAff[236, 38] = "n";
            matrAff[238, 38] = "t";
            matrAff[240, 38] = "e";
            matrAff[242, 38] = "r";
            matrAff[244, 38] = "]";
            OptAffichage(ref matrAff);
        }
    }
}