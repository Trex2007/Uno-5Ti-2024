using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _5T24_BrahyAdrien_Uno
{
    public struct methodeProject
    {
        public string distribuerCartes()
        {
            string carte;

            Random alea = new Random();

            string[] alphabet = new string[] { "j", "b", "r", "v", "j", "b", "r", "v", "j", "b", "r", "v", "j", "b", "r", "v", "n", "n" };
            Random rand = new Random();
            carte = alphabet[rand.Next(0, 17)] + alea.Next(0, 12);
            return carte;
        }
    }
}