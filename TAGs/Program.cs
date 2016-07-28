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
			int contador = 0;
			string[] cadena;
			int i = 0;
			System.IO.StreamReader archivo = new System.IO.StreamReader("tag.txt");
			while((linea = archivo.ReadLine()) != null)
			{
				contador++;
			}

			cadena = new string[contador];
			System.IO.StreamReader file = new System.IO.StreamReader("tag.txt");
			while ((linea = file.ReadLine()) != null)
			{
				cadena[i] = String.Copy(linea);
				i++;
			}

			for (i = 0; i < contador; i++)
			{
				Console.WriteLine(cadena[i] + " 1");
			}

			archivo.Close();
			file.Close();
			Console.ReadKey(true);
		}
	}
}
