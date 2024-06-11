using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Test6._0
{
    public struct methodeProject
    {
        /// <summary>
        /// fonction pour que le/les bot(s) joue.
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        /// <param name="cartes"> les cartes des joueurs </param>
        /// <param name="tourJoueur"> savoir a quelle joueur c'est </param>
        /// <param name="carteCentrale"> la carte du centre </param>
        /// <param name="nbrJoueurs"> le nombre de joueurs </param>
        public void jouerBots(string[,] Matr, int[,] cartes, uint tourJoueur, int[] carteCentrale, uint nbrJoueurs)
        {

            bool passeTour = false;

            if (carteCentrale[1] > 10)
            {
                passeTour = true;
            }

            if (passeTour == false)
            {
                int statvide = 0;
                bool reussiJouer = false;
                int loc = 0;
                while (loc < cartes.GetLength(0) && cartes[loc, tourJoueur] != 99)
                {
                    loc++;
                }

                for (int i = 0; i < loc; i++)
                {
                    if (0 != cartes[i, tourJoueur + 1])
                    {
                        if (carteCentrale[0] == cartes[i, tourJoueur])
                        {
                            carteCentrale[0] = cartes[i, tourJoueur];
                            carteCentrale[1] = cartes[i, tourJoueur + 1];
                            ReRangerCartes(cartes, i, tourJoueur);
                            reussiJouer = true;
                            break;
                        }
                        else if (carteCentrale[1] == cartes[i, tourJoueur + 1])
                        {
                            carteCentrale[0] = cartes[i, tourJoueur];
                            carteCentrale[1] = cartes[i, tourJoueur + 1];
                            ReRangerCartes(cartes, i, tourJoueur);
                            reussiJouer = true;
                            break;
                        }
                        else if (cartes[i, tourJoueur + 1] == 0)
                        {
                            carteCentrale[0] = cartes[i, tourJoueur];
                            carteCentrale[1] = 1;
                            ReRangerCartes(cartes, i, tourJoueur);
                            reussiJouer = true;
                            break;
                        }
                    }
                }
                if(reussiJouer == false)
                {
                    for (int h = 0; cartes[h, tourJoueur] != 99; h++)
                    {
                        statvide = h;
                    }
                    int max = 12;
                    cartes[statvide + 1, tourJoueur] = distribuerCartes(max);
                    max = 4;
                    cartes[statvide + 1, tourJoueur + 1] = distribuerCartes(max);
                }
            } else
            {
                passeTour = false;
                carteCentrale[0] = 0;
            }
        }
        /// <summary>
        /// Fonction de jeux de l'utilisateur
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        /// <param name="cartes"> les cartes des joueurs </param>
        /// <param name="tourJoueur"> savoir a quelle joueur c'est </param>
        /// <param name="carteCentrale"> la carte du centre </param>
        public void jouerUtilisateur(string[,] Matr, int[,] cartes, uint tourJoueur, int[] carteCentrale)
        {
            if (VerifPasseTour(carteCentrale) == false ){
                carteCentrale = DemanderCarte(cartes, carteCentrale, tourJoueur, Matr);
            } else
            {
                carteCentrale[1] = 0;
            }

        }
        /// <summary>
        /// fonction de demande la carte a l'utilisateur
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        /// <param name="cartes"> les cartes des joueurs </param>
        /// <param name="tourJoueur"> savoir a quelle joueur c'est </param>
        /// <param name="carteCentrale"> la carte du centre </param>
        /// <returns> retourne la carte au centre </returns>
        public int[] DemanderCarte(int[,] cartes, int[] carteCentrale, uint tourJoueur, string[,] Matr)
        {
            int statvide = 0;
            int carteJouer;
            bool jouerOK = false;

            while (jouerOK == false || statvide == 0)
            {
                carteJouer = ConvertirCle();
                jouerOK = VerifCarte(cartes, carteJouer, carteCentrale, jouerOK, statvide, tourJoueur);
                if (jouerOK == true)
                {
                    carteCentrale[0] = cartes[carteJouer, tourJoueur];
                    carteCentrale[1] = cartes[carteJouer, tourJoueur+1];
                    ReRangerCartes(cartes, carteJouer, tourJoueur);
                    if (carteCentrale[1] == 0)
                    {
                        bool boucleOuNon = true;
                        carteJouer = 0;
                        MethodeAffichage Affichage = new MethodeAffichage();
                        Thread gameColorThread = new Thread(() => Affichage.ChangementCouleur(Matr, boucleOuNon));
                        gameColorThread.Start();

                        while (carteJouer > 4 || carteJouer < 1 )
                        {
                            carteJouer = ConvertirCle() +1;
                        }
                        carteCentrale[1] = carteJouer;
                        boucleOuNon = false;
                        gameColorThread.Join();
                    }
                    break;
                }
                else
                {
                    break;
                }
            }

            return carteCentrale;
        }
        /// <summary>
        /// Fonction ou l'on range les cartes du joueurs/ bots
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        /// <param name="cartes"> les cartes des joueurs </param>
        /// <param name="tourJoueur"> savoir a quelle joueur c'est </param>
        public void ReRangerCartes(int[,] cartes, int carteJouer, uint tourJoueur)
        {
            for (int i = carteJouer; i < cartes.GetLength(0) - 1; i++)
            {
                cartes[i, tourJoueur] = cartes[i + 1, tourJoueur];
                cartes[i, tourJoueur+1] = cartes[i + 1, tourJoueur+1];
            }
            cartes[cartes.GetLength(0) - 1, tourJoueur] = 99;
            cartes[cartes.GetLength(0) - 1, tourJoueur+1] = 99;
        }
        /// <summary>
        /// fonction pour voir si le joueur a bien mis une carte valable
        /// </summary>
        /// <param name="Matr"> la matrice affichage </param>
        /// <param name="cartes"> les cartes des joueurs </param>
        /// <param name="tourJoueur"> savoir a quelle joueur c'est </param>
        /// <param name="carteCentrale"> la carte du centre </param>
        /// <param name="jouerOK"> Voir si le joueur peut placer la carte </param>
        /// <param name="statvide"> voir cmb de carte il a </param>
        /// <returns> si la carte est bonne ou pas</returns>
        public bool VerifCarte(int[,] cartes, int carteJouer, int[] carteCentrale, bool jouerOK, int statvide, uint tourJoueur)
        {
            if (carteJouer == 99)
            {
                for (int i = 0; cartes[i, tourJoueur] != 99; i++)
                {
                    statvide = i;
                }
                int max = 12;
                cartes[statvide+1, tourJoueur] = distribuerCartes(max);
                max = 4;
                cartes[statvide+1, tourJoueur+1] = distribuerCartes(max);
            } else
            {
                if (cartes[carteJouer, tourJoueur] != 99)
                {
                    if (carteCentrale[0] == cartes[carteJouer, tourJoueur])
                    {
                        jouerOK = true;
                    }
                    else if (carteCentrale[1] == cartes[carteJouer, tourJoueur + 1])
                    {
                        jouerOK = true;
                    }
                    else if (cartes[carteJouer, tourJoueur + 1] == 0)
                    {
                        jouerOK = true;
                    }
                }
            }
            return jouerOK;
        }
        /// <summary>
        /// regarde si le joueur doit passer son tour
        /// </summary>
        /// <param name="carteCentrale"> la carte du centre </param>
        /// <returns> si le joueur passe son tour ou non </returns>
        public bool VerifPasseTour(int[] carteCentrale)
        {
            bool passeTour = false;

            if (carteCentrale[0] > 10)
            {
                passeTour = true;
            }

            return passeTour;
        }
        /// <summary>
        /// distribue les cartes
        /// </summary>
        /// <param name="cartes"> les cartes des joueurs </param>
        /// <param name="tourJoueur"> savoir a quelle joueur c'est </param>
        /// <param name="carteCentrale"> la carte du centre </param>
        public void jeuxDistrib(uint nbrJoueurs, int[,] cartes, int[] carteCentrale)
        {
            int max = 0;
            for (int j = 0; j < cartes.GetLength(1)-1; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    max = 12;
                    cartes[i, j] = distribuerCartes(max);                    
                }
            }
            for (int j = 0; j < cartes.GetLength(1)-1; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    max = 4;
                    cartes[i, j + 1] = distribuerCartes(max);
                }
            }
        }
        /// <summary>
        /// génère un nombre aléatoire
        /// </summary>
        /// <param name="max"> nbr max de la carte </param>
        /// <returns> nbr aléatoir </returns>
        public int distribuerCartes(int max)
        {
            Random alea = new Random();

            // Tirage avec une probabilité réduite pour 0
            if (alea.Next(0, 30) == 0)
            {
                return 0; // 10% de chance de tirer 0
            }
            else
            {
                return alea.Next(1, max + 1); // 90% de chance de tirer entre 1 et max
            }
        }
        /// <summary>
        /// converti vôtre entrez en lettre (abcde...) en chiffres (12345...)
        /// </summary>
        /// <returns> retourne le nbr de la carte jouer pour désigner le jeux</returns>
        public int ConvertirCle()
        {
            bool carteOk = false;
            int carteJouer = 0;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            while (carteOk == false)
            {
                ConsoleKey toucheToucher = Console.ReadKey(true).Key;
                if (toucheToucher == ConsoleKey.Z)
                {
                    carteJouer = 99;
                    break;
                }
                else
                {
                    for (int i = 0; i != 26; i++)
                    {
                        if (toucheToucher == (ConsoleKey)alphabet[i])
                        {
                            carteJouer = i;
                            carteOk = true;
                            break;
                        }
                        else
                        {
                            carteOk = false;
                        }
                    }
                }
            }
            return carteJouer;
        }
    }
}
