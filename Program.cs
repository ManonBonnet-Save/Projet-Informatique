using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projet_informatique
{
    class Program
    {
        static void Main(string[] args)
        {

            string[][] Clavier = new string[13][];
            for (int i = 0; i < Clavier.Length; i++)
            {
                Clavier[i] = new string[4];

            }



            int i = 0;
            while (i<=4)
            {
                Console.Write(Caractères[i]);
                if (i == 4)
                    i = 0;
            }

        }
    }
}
