using System;

namespace Fausto
{
	class Program
	{
		static void Main(string[] args)
		{
			string linea, caracter;
			int fila = 0, columna = 0, posxFausto = 0, posyFausto = 0, posxSalida = 0, posySalida = 0;
			char[,] mapa;
			int[] vectorX, vectorY;
			int contador = 0;
			System.IO.StreamReader archivo = new System.IO.StreamReader("fausto.txt");
			while ((linea = archivo.ReadLine()) != null)
			{
				if(columna == 0)
				{
					columna = linea.Length;
				}
				fila++;
			}

			mapa = new char[fila, columna];
			vectorX = new int[fila * columna];
			vectorY = new int[fila * columna];
			System.IO.StreamReader file = new System.IO.StreamReader("fausto.txt");
			for(int i = 0; i < fila; i++)
			{
				caracter = file.ReadLine();
				for(int j = 0; j < columna; j++)
				{
					mapa[i, j] = caracter[j];
				}
			}

			for (int i = 0; i < fila; i++)
			{
				for (int j = 0; j < columna; j++)
				{
					if(mapa[i, j] == '*')
					{
						posxFausto = i;
						posyFausto = j;
					}
					if(mapa[i, j] == 'o')
					{
						posxSalida = i;
						posySalida = j;
					}
				}
			}

			vectorX[contador] = posxFausto;
			vectorY[contador] = posyFausto;
			while(mapa[posxFausto, posyFausto] != mapa[posxSalida, posySalida])
			{
				contador++;
				movimientoVertical(ref mapa, ref posxFausto, ref posyFausto);
				movimientoHorizontal(ref mapa, ref posxFausto, ref posyFausto);
				vectorX[contador] = posxFausto;
				vectorY[contador] = posyFausto;
			}

			Console.WriteLine(contador);
			for(int i = 0; i < contador; i++)
			{
				Console.WriteLine(vectorX[i] + " " + vectorY[i]);
			}

			archivo.Close();
			file.Close();
			Console.WriteLine("Presione una tecla para continuar...");
			Console.ReadKey(true);
		}

		static int movimientoVertical(ref char[,] mapaAuxiliar, ref int xFausto, ref int yFausto)
		{
			if (mapaAuxiliar[xFausto, yFausto + 1] == '.' || mapaAuxiliar[xFausto, yFausto + 1] == 'o')
			{
				yFausto++;
				mapaAuxiliar[xFausto, yFausto - 1] = '0';
			}
			else
			{
				if (mapaAuxiliar[xFausto, yFausto - 1] == '.' || mapaAuxiliar[xFausto, yFausto - 1] == 'o')
				{
					yFausto--;
					mapaAuxiliar[xFausto, yFausto + 1] = '0';
				}
			}
			return 0;
		}

		static int movimientoHorizontal(ref char[,] mapaAuxiliar, ref int xFausto, ref int yFausto)
		{
			if (mapaAuxiliar[xFausto + 1, yFausto] == '.' || mapaAuxiliar[xFausto + 1, yFausto] == 'o')
			{
				xFausto++;
				mapaAuxiliar[xFausto - 1, yFausto] = '0';
			}
			else
			{
				if (mapaAuxiliar[xFausto - 1, yFausto] == '.' || mapaAuxiliar[xFausto - 1, yFausto] == 'o')
				{
					xFausto--;
					mapaAuxiliar[xFausto + 1, yFausto] = '0';
				}
			}
			return 0;
		}
	}
}