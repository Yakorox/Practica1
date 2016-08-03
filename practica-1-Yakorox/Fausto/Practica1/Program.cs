using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
*
*Jesus Alejandro Varela Castro
*C.I. 23.098.367
*/
namespace Practica1
{
    public class Tablero
    {
        int posXJ;
        int posYJ;
        int tamX;
        int tamY;
        public int contPosV;
        public int posiblesMov;
        public char[][] tabla;
        public int[] x;
        public int[] y;


        public Tablero(int x, int y, int tx, int ty)
        {
            posXJ = x;
            posYJ = y;
            tamX = tx;
            tamY = ty;
            posiblesMov = 0;
            contPosV = 0;
            tabla = new char[ty][];

            for (int i = 0; i < ty; i++)
                tabla[i] = new char[tx];
        }
        public int getPosXJ()
        {
            return posXJ;
        }
        public int getPosYJ()
        {
            return posYJ;
        }
        public void setPosXJ(int x)
        {
            posXJ = x;
        }
        public void setPosYJ(int y)
        {
            posYJ = y;
        }
        public int getTamX()
        {
            return tamX;
        }
        public void setTamX(int x)
        {
            tamX = x;
        }
        public int getTamY()
        {
            return tamY;
        }
        public void setTamY(int y)
        {
            tamY = y;
        }

        public void cargarMatriz()
        {
            StreamReader file = new StreamReader("Fausto.txt");
            string linea = "";
            int k = 0;

            if (linea != null)
            {

                while (linea != null)
                {
                    linea = file.ReadLine();
                    if (linea != null)
                        for (int i = 0; i < linea.Length; i++)
                        {
                            tabla[k][i] = linea[i];
                            if (linea[i] == '.')
                                posiblesMov++;
                            if (linea[i] == '*')
                            {
                                setPosXJ(i);
                                setPosYJ(k);
                            }
                        }
                    k++;
                }

            }

            x = new int[posiblesMov + 1];
            y = new int[posiblesMov + 1];
            x[0] = y[0] = 0;
        }

        public void imprimirTablero()
        {
            for (int i = 0; i < tamY; i++)
            {
                for (int j = 0; j < tamX; j++)
                {
                    if (tabla[i][j] == '-')
                        Console.Write('.');
                    else
                        Console.Write(tabla[i][j]);

                }
                Console.WriteLine();
            }

        }


        public int jugar()
        {
            int enc = 0;
            int enc1 = 0;
            Console.Clear();
            Console.WriteLine("PJX: " + posXJ + " PJY: " + posYJ);
            imprimirTablero();
            Console.Read();
            if (enc1 == 0)
            {
                if (posYJ + 1 < tamY && (tabla[posYJ + 1][posXJ] == '.' || tabla[posYJ + 1][posXJ] == 'o'))
                {
                    if (tabla[posYJ + 1][posXJ] == 'o')
                        enc = 1;

                    tabla[posYJ + 1][posXJ] = '*';
                    tabla[posYJ][posXJ] = '-';
                    posYJ = posYJ + 1;
                    x[contPosV] = posXJ;
                    y[contPosV] = posYJ;

                    contPosV++;
                    enc1 = 1;


                }
            }
            if (enc1 == 0)
            {
                if (posYJ - 1 >= 0 && (tabla[posYJ - 1][posXJ] == '.' || tabla[posYJ - 1][posXJ] == 'o'))
                {
                    if (tabla[posYJ - 1][posXJ] == 'o')
                        enc = 1;

                    tabla[posYJ - 1][posXJ] = '*';
                    tabla[posYJ][posXJ] = '-';
                    posYJ = posYJ - 1;
                    x[contPosV] = posXJ;
                    y[contPosV] = posYJ;

                    contPosV++;
                    enc1 = 1;
                }
            }
            if (enc1 == 0)
            {
                if (posXJ + 1 < tamX && (tabla[posYJ][posXJ + 1] == '.' || tabla[posYJ][posXJ + 1] == 'o'))
                {
                    if (tabla[posYJ][posXJ + 1] == 'o')
                        enc = 1;

                    tabla[posYJ][posXJ + 1] = '*';
                    tabla[posYJ][posXJ] = '-';
                    posXJ = posXJ + 1;
                    x[contPosV] = posXJ;
                    y[contPosV] = posYJ;

                    contPosV++;
                    enc1 = 1;
                }
            }
            if (enc1 == 0)
            {
                if (posXJ - 1 >= 0 && (tabla[posYJ][posXJ - 1] == '.' || tabla[posYJ][posXJ - 1] == 'o'))
                {
                    if (tabla[posYJ][posXJ - 1] == 'o')
                        enc = 1;

                    tabla[posYJ][posXJ - 1] = '*';
                    tabla[posYJ][posXJ] = '-';
                    posXJ = posXJ - 1;
                    x[contPosV] = posXJ;
                    y[contPosV] = posYJ;
                    enc1 = 1;
                    contPosV++;
                }
            }




            if (enc == 0)
                jugar();

            return enc;
        }

    }





    class Program
    {
        static void Main(string[] args)
        {
            Tablero ta;
            string p = "";
            int contX=0;
            int contY=0;
          


            StreamReader file = new StreamReader("Fausto.txt");
            p = file.ReadLine();
            while (p != null)
            {
                
                if (contY == 1)
                    contX = p.Length;

                
                p = file.ReadLine();
                if(p!=null)
                    contY++;
            }
           
            ta = new Tablero(0,0,contX,contY);
            ta.cargarMatriz();

            ta.jugar();

            Console.WriteLine("Cantidad de Movimientos: " + ta.contPosV);
            Console.WriteLine("X:   Y: ");
            for (int i = 0; i < ta.contPosV; i++)
                Console.WriteLine(ta.x[i]+"   "+ta.y[i]);

                Console.Read();
                Console.Read();
        }

      


    }


}
