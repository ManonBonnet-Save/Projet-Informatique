﻿using System;
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

		/*public class EnumClavier
		{
			string[] touche1 = new string[] {".",",","-", "?", "!", "@", ":", "(", ")", "/", "1"};
			string[] touche2 = new string[] {"a", "b", "c", "à", "ä", "ç", "2"};
			string [] touche3 = new string[]{"d", "e", "f", "è", "é", "3"};
			string[] touche4 = new string[]{"g", "h", "i", "4"};
			string[] touche5 = new string[]{"j", "k", "l", "5"};
			string[] touche6 = new string[]{"m", "n", "o","ñ", "ö",  "6"};
			string[] touche7 = new string[]{"p", "q", "r", "s", "7"};
			string[] touche8 = new string[]{"t", "u", "v", "ù", "ü", "8"};
			string[] touche9 = new string[] {"w", "x", "y", "z", "9"};
			string[] touche0  = new string[]{"0"};
			string[] space = new string[]{" "};
			string[] diese = new string[]{"1"};
			string[] etoile = new string[]{"1"};*/

		static void Main(string[] args)
		{

			/*string[][] Clavier = new string[14][]; // Création du tableau de tableau
			/*Clavier[1] = new string[]{".",",", "-", "?", "!", "", ":", "(", ")", "/", "1"};
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
			Clavier[13] = new string[]{"1"};*/

			string[] touche1 = new string[] {".",",","-", "?", "!", "@", ":", "(", ")", "/", "1"};
			string[] touche2 = new string[] {"a", "b", "c", "à", "ä", "ç", "2"};
			string [] touche3 = new string[]{"d", "e", "f", "è", "é", "3"};
			string[] touche4 = new string[]{"g", "h", "i", "4"};
			string[] touche5 = new string[]{"j", "k", "l", "5"};
			string[] touche6 = new string[]{"m", "n", "o","ñ", "ö",  "6"};
			string[] touche7 = new string[]{"p", "q", "r", "s", "7"};
			string[] touche8 = new string[]{"t", "u", "v", "ù", "ü", "8"};
			string[] touche9 = new string[] {"w", "x", "y", "z", "9"};
			string[] touche0  = new string[]{"0"};
			string[] space = new string[]{" "};
			string[] diese = new string[]{"1"};
			string[] etoile = new string[]{"1"};
			string[][] Clavier =
			{touche1,touche2,touche3,touche4,touche5,touche6,touche7,touche8,touche9,touche0,space, diese, etoile};




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
			while (!saisieCorrecte)
			{
				Console.WriteLine ("Veuillez entrer un mode de saisie intuitive: (multi_tap ou t9)");
				message = Console.ReadLine ();
				if (message != "multi_tap" && message != "t9")
					messageErreur ();

				else
					saisieCorrecte = true;
			}

			Console.WriteLine ("Veuillez entrer un message à convertir:");
			sms = Console.ReadLine ();
			int LongueurSms = sms.Length;

			string[] SmsTab = new string[LongueurSms];

			int j =0;

			string[] retranscrit = new string[LongueurSms];

			for (int i = 0; i < SmsTab.Length; i++) 
			{
				string Car = sms.Substring (i, 1);
				SmsTab [i] = Car;
			}

			Console.WriteLine ("%%%%");

			for (int t = 0; t < SmsTab.Length; t++) {
				for (int n = 0; n < SmsTab.Length - 1; n++) {
					if (SmsTab [n] == SmsTab [n + 1]) {
						j++;
					}
				}

				for (int n = 0; n < SmsTab.Length; n++) {
					if (SmsTab [n] == "0") {
						retranscrit [n] = touche0 [j];
					}
					if (SmsTab [n] == "1") {
						retranscrit [n] = touche1 [j];
					}
					if (SmsTab [n] == "2") {
						retranscrit [n] = touche2 [j];
					}
					if (SmsTab [n] == "3") {
						retranscrit [n] = touche3 [j];
					}
					if (SmsTab [n] == "4") {
						retranscrit [n] = touche4 [j];
					}
					if (SmsTab [n] == "5") {
						retranscrit [n] = touche5 [j];
					}
					if (SmsTab [n] == "6") {
						retranscrit [n] = touche6 [j];
					}
					if (SmsTab [n] == "7") {
						retranscrit [n] = touche7 [j];
					}
					if (SmsTab [n] == "8") {
						retranscrit [n] = touche8 [j];
					}
					if (SmsTab [n] == "9") {
						retranscrit [n] = touche9 [j];
					}
					if (SmsTab [n] == "*") {
						retranscrit [n] = etoile [j];
					}
					if (SmsTab [n] == "#") {
						retranscrit [n] = diese [j];
					}
					if (SmsTab [n] == " ") {
						retranscrit [n] = space [j];
					}
				}
				j = 0;
				Console.Write (retranscrit [t]);
			}
			// Recherche bon caractère


			//string lettre= Clavier.touche3[j];

			//Comparaison entre le tableau d'entrée et le double tableau
			int r = 0;
			int l = 0;
			while (l < Clavier.Length)
			{
				if (SmsTab[r] == touche1[l])
				{

				}
			}
			/*if (message == "multi_tap")
				multi_tap (sms);
			if (message == "t9")
				t9 (sms);*/
		}// Fin du Main
	}
}
