using System.Collections;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using ConsoleApp2;
namespace Taryan
{
    internal class Program
    {
        enum Colors { 
            Gray,
            Black,
            White
        }
        static int n;
        static Colors[]? highs;
        static MyVector<MyVector<int>>? Graph;
        static bool Acycle = false;
        static string answer = "";
        static void Main(string[] args)
        {




            Console.WriteLine("Введите количество вершин");
            n = Convert.ToInt32(Console.ReadLine());
            
            highs = new Colors[n];
            
            Graph = new MyVector<MyVector<int>>(n);
            for (int i = 0; i < n; i++) {
                Graph.Add(new MyVector<int>());
                highs[i] = Colors.White;
            }


            for (int i = 0; i < n; i++) {
                Console.WriteLine($"Введите смежные вершины для {i}");
                foreach (string str in Console.ReadLine().Split(" ")) {
                    if (str == "")
                        continue;
                    Graph[i].Add(Convert.ToInt32(str));
                
                
                }
            }
            DFS(3);
            if (Acycle)
                Console.WriteLine("Обнаружен цикл, топологическая сортировка невозможна.");
            else
                Console.WriteLine(answer);

            //List<List<int>> Graph = new List<List<int>>();
            void DFS(int v)
            {
                if (highs[v] == Colors.Black)
                    return;
                if (highs[v] == Colors.Gray)
                {
                    Acycle = true;
                    return;
                }
                highs[v] = Colors.Gray;
                for (int i = 0; i < Graph[v].Size(); i++)
                    DFS(Graph[v][i]);
                    
                answer = " " + v.ToString() + answer;
                highs[v] = Colors.Black;
            }
        }



        
    }
}