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
				Console.WriteLine("|           _           `|");
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
		public static void T9()
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
				Console.WriteLine("|           _           `|");
				Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ ");

				Console.WriteLine("Tapez sur le pavé numérique jusqu'à la mort ou 'q' pour quitter");
				Console.WriteLine("\n" + result);

				//Most important thing !!!
				ConsoleKeyInfo cki = Console.ReadKey();

				//If the user press q, close the console
				if (cki.KeyChar == 'q') break;


				//Uses to permit to letter on a same number
				/*if (cki.KeyChar == 's')
				{
					count = 0;
					previous = -1;
					continue;
				}*/

				//Todo ensure the entry is a number

				//If this point is reached, the text will change
				int v = ToInt(cki.KeyChar);
				foreach (char i in lettre[v])
				{
					if (i == mot [v])
					{
						Console.WriteLine (mot);
					}
				}

				/*if (previous == v) //Change the last letter
				{
					count++;
					result = ReplaceAt(result, result.Length - 1, lettre[v][count]);
				}
				else //New letter is add
				{
					count = 0;
					result += lettre[v][count];
				}*/

				//Need to know what is the last input
				previous = v;
			}
		}

		public static void ouvrirFichier(string fichier)
		{
			try
			{
				Console.WriteLine("\nOuverture du fichier : " + fichier);

				// Création d'une instance de StreamReader pour permettre la lecture de notre fichier 
				System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
				StreamReader monStreamReader = new StreamReader(fichier, encoding);

				int nbMots = 0;
				//int tailleMin = 100;
				//int tailleMax = 0;

				Console.Write("Lecture du dictionnaire, veuillez patienter...");

				string mot = monStreamReader.ReadLine();

				// Lecture de tous les mots du dictionnaire (un par lignes) 
				while (mot != null)
				{
					nbMots++;

					//if (mot.Length < tailleMin) tailleMin = mot.Length;
					//if (mot.Length > tailleMax) tailleMax = mot.Length;

					mot = monStreamReader.ReadLine();

				}
				// Fermeture du StreamReader (attention très important) 
				monStreamReader.Close();

				//Console.WriteLine("\n{0} mots lus dans le fichier {1}", nbMots, fichier);
				// Console.WriteLine("\nLe mot le plus court fait {0} lettre(s).", tailleMin);
				//Console.WriteLine("\nLe mot le plus  long fait {0} lettre(s).", tailleMax);

			}
			catch (Exception ex)
			{
				// Code exécuté en cas d'exception 
				Console.Write("Une erreur est survenue au cours de la lecture :");
				Console.WriteLine(ex.Message);
			}
		}

		public static void Main(string[] args)
		{

			inputLoop();
			ouvrirFichier("../../dicoFR.txt");

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