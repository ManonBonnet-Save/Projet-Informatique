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

        public static void refreshFrame(string additionalText)
        {
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
            Console.WriteLine("|        (space)         |");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ ");

            Console.WriteLine("Tapez sur le clavier numérique ou 'q' pour quitter.");
            Console.WriteLine("En classique, le 's' sert à passer à la lettre suivante d'un même bloc.");
            Console.WriteLine("En T9, le 's' sert à naviguer dans les propositions de mots.");

            Console.WriteLine("");
            Console.WriteLine(additionalText);
        }

        //Classical keyboard loop function
        public static void inputLoop()
        {
            string[] lettre = new string[] { " ", "PQRS1", "TUVùü2", "WXYZ3", "GHI4", "JKL5", "MNOñö6", ".,-?!@:()/7", "ABCàäç8", "DEFèé9" };
            int count = 0;
            int previous = -1;
            string result = "";
            while (true)
            {
                //Rewrite everything to refresh
                refreshFrame(result + "|");


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
                //if (cki.KeyChar != lettre[v])
                //{
                //    messageErreur();
                //}


                //If this point is reached, the text will change
                int v = ToInt(cki.KeyChar);
                if (previous == v) //Change the last letter
                {
                    count++;
                    if (count == lettre[v].Length) count = -1;
                    else
                        result = ReplaceAt(result, result.Length - 1, lettre[v][count]);
                }
                else //New letter is add
                {
                    count = 0;
                    result += lettre[v][count];
                }

                //Used to erase a letter
                if (cki.KeyChar == 'e')
                {
                    //result = result - lettre[v][count];
                }

                //Need to know what is the last input
                previous = v;
            }
        }

        //Essential function
        public static bool isReachableWord(string word, string input, int idx)
        {
            if (word.Length < idx + 1) return false;
            for (int i = 0; i < input.Length; i++)
            {
                if (word[idx] == input[i]) return true;
            }
            return false;
        }

        //T9 loop function
        public static void T9()
        {
            string[] letters = new string[] { " ", "PQRS", "TUV", "WXYZ", "GHI", "JKL", "MNO", ".,-?!@:()/", "ABC", "DEF" };
            string result = "";
            List<string> dico = getDictionary("../../dicoFR.txt");
            List<string> selection = dico;
            int idx = 0;
            List<string> possibleWords = new List<string>();
            string buffer = "";
            int userChoiceIdx = 0;

            while (true)
            {
                //Rewrite everything to refresh
                string alternativesDisplay = "";
                if (idx == 0)
                {
                    result = "";
                }
                else if (possibleWords.Count > 0)
                {
                    result = possibleWords[userChoiceIdx];
                    if (possibleWords.Count > 1)
                    {
                        for (int i = 0; i < possibleWords.Count; i++)
                        {
                            if (i == userChoiceIdx)
                                alternativesDisplay += "\n." + possibleWords[i];
                            else
                                alternativesDisplay += "\n" + possibleWords[i];
                        }
                    }
                }
                else if (selection.Count > 0)
                {
                    result = selection[0];
                }
                refreshFrame(buffer + result + "|" + alternativesDisplay);

                //Most important thing !!!
                ConsoleKeyInfo cki = Console.ReadKey();

                //If the user press q, close the console
                if (cki.KeyChar == 'q') break;

                if (cki.KeyChar == 's')
                {
                    userChoiceIdx = (userChoiceIdx + 1) % possibleWords.Count;
                    continue;
                }
                else
                {
                    userChoiceIdx = 0;
                }

                int v = ToInt(cki.KeyChar);

                if (v == 0)
                {
                    buffer = buffer + result + " ";
                    result = "";
                    idx = 0;
                    selection = dico;
                    continue;
                }

                List<string> reachableWords = new List<string>();
                possibleWords = new List<string>();

                for (int i = 0; i < selection.Count; i++)
                {
                    if (isReachableWord(selection[i], letters[v], idx))
                    {
                        reachableWords.Add(selection[i]);
                        if (selection[i].Length == idx + 1)
                        {
                            possibleWords.Add(selection[i]);
                        }
                    }
                }
                selection = reachableWords;
                idx++;
            }
        }

        public static List<string> getDictionary(string filename)
        {
            List<string> dico = new List<string>();
            try
            {
                Console.WriteLine("\nOuverture du fichier : " + filename);

                // Création d'une instance de StreamReader pour permettre la lecture de notre fichier 
                System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                StreamReader monStreamReader = new StreamReader(filename, encoding);

                int nbMots = 0;

                Console.Write("Lecture du dictionnaire, veuillez patienter...");

                string mot = monStreamReader.ReadLine();

                // Lecture de tous les mots du dictionnaire (un par lignes) 
                while (mot != null)
                {
                    nbMots++;
                    dico.Add(mot);

                    mot = monStreamReader.ReadLine();
                }
                // Fermeture du StreamReader (attention très important) 
                monStreamReader.Close();


                Console.WriteLine("\n{0} mots lus dans le fichier {1}", nbMots, filename);

            }
            catch (Exception ex)
            {
                // Code exécuté en cas d'exception 
                Console.Write("Une erreur est survenue au cours de la lecture :");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(dico.Count);
            return dico;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Quel clavier voulez vous ? (Classic/T9) (C/t)");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.KeyChar == 't')
            {
                T9();
            }
            else
            {
                inputLoop();
            }
        }
    }
}
// Gestion d'une saisie de lettre avec le message d'erreur