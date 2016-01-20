using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace projet_informatique
{
	class MainClass
	{
		public static void messageErreur()
		{
			Console.WriteLine("Votre saisie est incorrecte");
		}

		//Ugly as fuck but usual and efficient
		public static int ToInt(char c)
		{
			return (int)(c - '0');
		}

		//Ugly too but usefull to replace character in string
		public static string ReplaceAt(string input, int index, char newChar)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			char[] chars = input.ToCharArray();
			chars[index] = newChar;
			return new string(chars);
		}

		public static void inputLoop()
		{
			string[] lettre = new string[] { " ", "PQRS1", "TUVùü2", "WXYZ3", "GHI4", "JKL5", "MNOñö6", ".,-?!@:()/7", "ABCàäç8", "DEFèé9" };
			int count = 0;
			int previous = -1;
			string result = "";
			while (true)
			{
				//Rewrite everything to refresh
				Console.Clear();
				Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ ");
				Console.WriteLine("|   7   |   8   |    9   |");
				Console.WriteLine("|  .,   |  ABC  |   DEF  |");
				Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ ");
				Console.WriteLine("|   4   |   5   |    6   |");
				Console.WriteLine("|  GHI  |  JKL  |   MNO  |");
				Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ ");
				Console.WriteLine("|   1   |   2   |    3   |");
				Console.WriteLine("| PQRS  |  TUV  |   WXYZ |");
				Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ ");
				Console.WriteLine("|           0            |");
				Console.WriteLine("|           _            |");
				Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ ");

				Console.WriteLine("Tapez sur le pavé numérique jusqu'à la mort ou 'q' pour quitter");
				Console.WriteLine("\n" + result);

				//Most important thing !!!
				ConsoleKeyInfo cki = Console.ReadKey();

				//If the user press q, close the console
				if (cki.KeyChar == 'q') break;

				//Uses to permit to letter on a same number
				if (cki.KeyChar == 's')
				{
					count = 0;
					previous = -1;
					continue;
				}

				//Todo ensure the entry is a number

				//If this point is reached, the text will change
				int v = ToInt(cki.KeyChar);
				if (previous == v) //Change the last letter
				{
					count++;
					result = ReplaceAt(result, result.Length - 1, lettre[v][count]);
				}
				else //New letter is add
				{
					count = 0;
					result += lettre[v][count];
				}

				//Need to know what is the last input
				previous = v;
			}
		}
		public static void T9(string mot)
		{
			string[] lettre = new string[] { " ", "PQRS1", "TUVùü2", "WXYZ3", "GHI4", "JKL5", "MNOñö6", ".,-?!@:()/7", "ABCàäç8", "DEFèé9" };
			int count = 0;
			int previous = -1;
			string result = "";
			while (true)
			{
				//Rewrite everything to refresh
				Console.Clear();
				Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ ");
				Console.WriteLine("|   7   |   8   |    9   |");
				Console.WriteLine("|  .,   |  ABC  |   DEF  |");
				Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ ");
				Console.WriteLine("|   4   |   5   |    6   |");
				Console.WriteLine("|  GHI  |  JKL  |   MNO  |");
				Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ ");
				Console.WriteLine("|   1   |   2   |    3   |");
				Console.WriteLine("| PQRS  |  TUV  |   WXYZ |");
				Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ ");
				Console.WriteLine("|           0            |");
				Console.WriteLine("|           _            |");
				Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ ");

				Console.WriteLine("Tapez sur le pavé numérique jusqu'à la mort ou 'q' pour quitter");
				Console.WriteLine("\n" + result);

				//Most important thing !!!
				ConsoleKeyInfo cki = Console.ReadKey();

				//If the user press q, close the console
				if (cki.KeyChar == 'q') break;

				//Todo ensure the entry is a number
				string dico = ouvrirFichier("../../dicoFR.txt");
				int v = ToInt(cki.KeyChar);
				foreach (char i in lettre[v])
				{
					foreach (string j in dico)
					{
						if(i == j[count])
						{
							// add j to string NvDico
						}
					}
				}
				count++;
				//Dico.Add(count);
				//Need to know what is the last input
				previous = v;
			}
		}

		public static string ouvrirFichier(string fichier) 
		{ 
			string dico = "";
			try 
			{ 
				Console.WriteLine("\nOuverture du fichier : "+fichier) ;

				// Création d'une instance de StreamReader pour permettre la lecture de notre fichier 
				System.Text.Encoding   encoding = System.Text.Encoding.GetEncoding(  "iso-8859-1"  );
				StreamReader monStreamReader = new StreamReader(fichier,encoding); 
				int nbMots = 0 ;

				Console.Write("Lecture du dictionnaire, veuillez patienter...") ;

				string mot = monStreamReader.ReadLine(); 

				// Lecture de tous les mots du dictionnaire (un par lignes) 
				while (mot != null) 
				{	
					Console.WriteLine(mot);
					nbMots++ ;
					dico = dico + mot;
					mot = monStreamReader.ReadLine();

				} 
				// Fermeture du StreamReader (attention très important) 
				monStreamReader.Close(); 
				Console.WriteLine("Il y a {0} mots dans le dictionnaire",nbMots);
				//Console.WriteLine(dico);
			} 
			catch (Exception ex) 
			{ 
				// Code exécuté en cas d'exception 
				Console.Write("Une erreur est survenue au cours de la lecture :"); 
				Console.WriteLine(ex.Message); 
			} return dico;
		}



		public static void Main(string[] args)
		{

			//inputLoop();
			ouvrirFichier("../../dicoFR.txt");
			//T9 ();

			//string message = "";

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

			Console.ReadLine();
		}
	}
}
// Comment comparer au dictionnaire pour détecter les mots existants
// Gestion d'une saisie de lettre avec le message d'erreur