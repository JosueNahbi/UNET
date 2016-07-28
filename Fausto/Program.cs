using System;

namespace Fausto
{
	class Program
	{
		static void Main(string[] args)
		{
			string linea,caracter;
			int fila = 0, columna = 0, posxFausto = 0, posyFausto = 0, posxSalida = 0, posySalida = 0;
			char[,] mapa;
			int[] vectorX;
			int[] vectorY;
			int contador = 0, x = 0;
			System.IO.StreamReader archivo = new System.IO.StreamReader("fausto.txt");
			while ((linea = archivo.ReadLine()) != null)
			{
				if(columna == 0)
				{
					columna = linea.Length;
				}
				fila++;
			}

			mapa = new char[fila,columna];
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

			vectorX[x] = posxFausto;
			vectorY[x] = posyFausto;
			x++;
			while(mapa[posxFausto, posyFausto] != mapa[posxSalida, posySalida])
			{
				if (mapa[posxFausto + 1, posyFausto] == '.' || mapa[posxFausto + 1, posyFausto] == 'o')
				{
					posxFausto++;
					mapa[posxFausto - 1, posyFausto] = '0';
					vectorX[x] = posxFausto;
					vectorY[x] = posyFausto;
					x++;
				}
				else
				{
					if (mapa[posxFausto - 1, posyFausto] == '.' || mapa[posxFausto - 1, posyFausto] == 'o')
					{
						posxFausto--;
						mapa[posxFausto + 1, posyFausto] = '0';
						vectorX[x] = posxFausto;
						vectorY[x] = posyFausto;
						x++;
					}
					else
					{
						if (mapa[posxFausto, posyFausto + 1] == '.' || mapa[posxFausto, posyFausto + 1] == 'o')
						{
							posyFausto++;
							mapa[posxFausto, posyFausto - 1] = '0';
							vectorX[x] = posxFausto;
							vectorY[x] = posyFausto;
							x++;
						}
						else
						{
							if (mapa[posxFausto, posyFausto - 1] == '.' || mapa[posxFausto, posyFausto - 1] == 'o')
							{
								posyFausto--;
								mapa[posxFausto, posyFausto + 1] = '0';
								vectorX[x] = posxFausto;
								vectorY[x] = posyFausto;
								x++;
							}
						}
					}
				}
				contador++;
			}

			Console.WriteLine(contador);
			for(int i = 0; i < x; i++)
			{
				Console.WriteLine(vectorX[i] + " " + vectorY[i]);
			}

			archivo.Close();
			file.Close();
			Console.WriteLine("Presione una tecla para continuar...");
			Console.ReadKey(true);
		}
	}
}