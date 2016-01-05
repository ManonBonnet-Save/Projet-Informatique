using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projet_informatique
{
    class Program
    {
        public static void multi_tap (string message)
		{
		}

		public static void t9 (string message)
		{
		}

		public static void messageErreur()
		{
			Console.WriteLine ("Votre saisie est incorrecte");
		}
		
        static void Main(string[] args)
        {

            string[][] Clavier = new string[14][]; // Création du tableau de tableau
                    Clavier[1] = new string[]{".",",", "-", "?", "!", "", ":", "(", ")", "/", "1"};
                    Clavier[2] = new string[]{"a", "b", "c", "à", "ä", "ç", "2"};
                    Clavier[3] = new string[]{"d", "e", "f", "è", "é", "3"};
                    Clavier[4] = new string[]{"g", "h", "i", "4"};
                    Clavier[5] = new string[]{"j", "k", "l", "5"};
                    Clavier[6] = new string[]{"m", "n", "o","ñ", "ö",  "6"};
                    Clavier[7] = new string[]{"p", "q", "r", "s", "7"};
                    Clavier[8] = new string[]{"t", "u", "v", "ù", "ü", "8"};
                    Clavier[9] = new string[]{"w", "x", "y", "z", "9"};
                    Clavier[10] = new string[]{"0"};
                    Clavier[11] = new string[]{" "};
                    Clavier[12] = new string[]{"1"};
                    Clavier[13] = new string[]{"1"};

            
            


            /*int i = 0;
            while (i<=4)
            {
                Console.Write(Caractères[i]);
                if (i == 4)
                    i = 0;
            }*/
            
            
            string sms;
			//Console.WriteLine("Veuillez entrer un mode de saisie intuitive: (multi_tap ou t9)");
			string message="";

			bool saisieCorrecte = false;
			while (!saisieCorrecte) {
				Console.WriteLine ("Veuillez entrer un mode de saisie intuitive: (multi_tap ou t9)");
				message = Console.ReadLine ();
				if (message != "multi_tap" && message != "t9")
					messageErreur ();
				
				else
					saisieCorrecte = true;
			}
			
			Console.WriteLine ("Veuillez entrer un message à convertir:");
			sms = Console.ReadLine ();

			if (message == "multi_tap")
			multi_tap (sms);
			if (message == "t9")
				t9 (sms);
        }// Fin du Main
    }
}
