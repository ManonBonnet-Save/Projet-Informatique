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
            
            
            string sms;
			Console.WriteLine ("Veuillez entrer un mode de saisie intuitive: (multi_tap ou t9)");
			string message = Console.ReadLine ();

			bool saisieCorrecte = false;
			while (!saisieCorrecte) {
				messageErreur ();
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
