using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System;
namespace IZOMORF
{
    internal class Program
    {
        class CustomCompare : Comparer<List<int>>
        {
            public override int Compare(List<int>? x, List<int>? y)
            {
                int n = Math.Min(x.Count, y.Count);
                for (int i = 0; i < n; i++) {
                    if (x[i] > y[i])
                        return 1;
                    else if (x[i] < y[i])
                        return -1;
                }
                return 0;
            }
        }


        static void Main(string[] args)
        {
            int[][] Multiply(int[][] Matrix, int[][] SecondMatrix) {
                int n = SecondMatrix.Length;
                int index1 = 0; int index2 = 0;
                int[][] NewMatrix = new int[n][];
                for (int i = 0; i < n; i++)
                    NewMatrix[i] = new int[n];
                int sum;
                for (int s = 0; s < n; s++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        sum = 0;
                        for (int i = 0; i < n; i++)
                        {
                            sum += Matrix[s][i] * SecondMatrix[i][j];

                        }
                        NewMatrix[index1][index2] = sum;
                        index2++;
                    }
                    index2 = 0; index1++;
                }
                return NewMatrix;

            }
            

            void Print(int[][] Matr) {
                for (int i = 0; i < Matr.Length; i++)
                {
                    for (int j = 0; j < Matr.Length; j++)
                        Console.Write(Matr[i][j] + " ");
                    Console.WriteLine();
                }
            
            }

            int n = Convert.ToInt32(Console.ReadLine());
            int[][] GraphMatrix = new int[n][];
            int[][] SecondGraph = new int[n][];
            for (int i = 0; i < n; i++)
            {
                SecondGraph[i] = new int[n];
                GraphMatrix[i] = new int[n];
            }
            Console.WriteLine("Введите матрицу смежности для первого графа");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine($"{i}:{j}");
                    GraphMatrix[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            Console.WriteLine("Введите матрицу смежности для второго графа");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine($"{i}:{j}");
                    SecondGraph[i][j] = Convert.ToInt32(Console.ReadLine());
                }





            Print(GraphMatrix);
            Console.WriteLine();
            int[][] Copy = new int[n][];
            int[][] SecondCopy = new int[n][];
            for (int i = 0; i < n; i++)
            {
                Copy[i] = new int[n];
                SecondCopy[i] = new int[n];
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Copy[i][j] = GraphMatrix[i][j];
                    SecondCopy[i][j] = SecondGraph[i][j];
                }


            

            List<List<int>> UniqueVer1 = new List<List<int>>(n);
            List<List<int>> UniqueVer2 = new List<List<int>>(n);
            for (int i = 0; i < n; i++) { 
                UniqueVer1.Add(new List<int>(n));
                UniqueVer2.Add(new List<int>(n));
            }
            for (int k = 0; k < n; k++)
            {
                Copy = Multiply(GraphMatrix, Copy);
                SecondCopy = Multiply(SecondGraph, SecondCopy);
                Print(Copy);
                Console.WriteLine();
                Print(SecondCopy);
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        UniqueVer1[i].Add(Copy[i][j]);
                        UniqueVer2[i].Add(SecondCopy[i][j]);

                    }
                    UniqueVer1[i].Sort();
                    UniqueVer2[i].Sort();
                }
                
            }

            var CompObj = new CustomCompare();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n - 1; j++) {
                    if (CompObj.Compare(UniqueVer1[j], UniqueVer1[j + 1]) > 0) {
                        var tmp = UniqueVer1[j];
                        UniqueVer1[j] = UniqueVer1[j + 1];
                        UniqueVer1[j + 1] = tmp;
                    }
                    if (CompObj.Compare(UniqueVer2[j], UniqueVer2[j + 1]) > 0)
                    {
                        var tmp = UniqueVer2[j];
                        UniqueVer2[j] = UniqueVer2[j + 1];
                        UniqueVer2[j + 1] = tmp;
                    }

                }
            for (int i = 0; i < n; i++)
                if (CompObj.Compare(UniqueVer1[i], UniqueVer2[i]) != 0) {
                    Console.WriteLine("Графы неизоморфны");
                    return;
                }
            Console.WriteLine("Изоморфны");




            
        }
    }
}