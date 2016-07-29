using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAGs
{
	class Program
	{
		static void Main(string[] args)
		{
			string linea;
			int contador = 0, i = 0, j = 0;
			string[] token, vector, auxiliar;
			System.IO.StreamReader archivo = new System.IO.StreamReader("tag.txt");
			while((linea = archivo.ReadLine()) != null)
			{
				contador++;
			}

			vector = new string[contador];
			auxiliar = new string[contador];
			System.IO.StreamReader file = new System.IO.StreamReader("tag.txt");
			while ((linea = file.ReadLine()) != null)
			{
				token = linea.Split('#');
				auxiliar[i] = String.Copy(token[i]);
				vector[j] = auxiliar[i];
				j++;
			}

			for (i = 0; i < j; i++)
			{
				Console.WriteLine(vector[i]);
			}

			archivo.Close();
			file.Close();
			Console.ReadKey(true);
		}
	}
}
