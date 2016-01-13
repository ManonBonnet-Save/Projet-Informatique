using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace projet_informatique
{
	class MainClass
	{
		public static void messageErreur()
		{
			Console.WriteLine ("Votre saisie est incorrecte");
		}

		public static void Main (string[] args)
		{
			string[] lettre = new string[]{" ",".,-?!@:()/1","ABCàäç2", "DEFèé3", "GHI4", "JKL5", "MNOñö6", "PQRS7", "TUVùü8", "WXYZ9" };
			string message="";

			/*bool saisieCorrecte = false;
			while (!saisieCorrecte)
			{
				Console.WriteLine ("Veuillez entrer un mode de saisie intuitive: (multi_tap ou t9)");
				message = Console.ReadLine ();
				if (message != "multi_tap" && message != "t9")
					messageErreur ();

				else
					saisieCorrecte = true;
			}*/
			Console.WriteLine ("Veuillez entrer un message à convertir:");
			string motCode = Console.ReadLine();
			int cptlettre = 0;
			string motDecode = "";


			int longueur = motCode.Length;
			for (int i = 0; i < motCode.Length; i++) {
				if (longueur == 1)
					motDecode = motDecode + lettre [int.Parse (motCode [i].ToString ())] [cptlettre];
				else if (i == motCode.Length-1) {
					if (motCode [i] != motCode [i - 1]) {
						motDecode = motDecode + lettre [int.Parse (motCode [i].ToString ())] [cptlettre];
					} else {
						motDecode = motDecode + lettre [int.Parse (motCode [i].ToString ())] [cptlettre];
					}

				} else {

					if (motCode [i] == motCode [i + 1]) {
						cptlettre++;
					} else if (motCode [i] == '*') {

					} 
					else{
						motDecode = motDecode + lettre [int.Parse (motCode [i].ToString ())] [cptlettre];
						cptlettre = 0;
					}
				}
			}
			Console.WriteLine (motDecode);
		}
	}
}
// Comment comparer au dictionnaire pour détecter les mots existants
// Gestion d'une saisie de lettre avec le message d'erreur