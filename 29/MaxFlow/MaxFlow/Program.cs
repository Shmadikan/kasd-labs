using ConsoleApp2;
namespace MaxFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество вершин");
            int n = Convert.ToInt32(Console.ReadLine());
            MyVector<MyVector<Tuple<int, int>>> Graph = new MyVector<MyVector<Tuple<int, int>>>();
            

        
            for (int i = 0; i < n; i++)
            {
                Graph.Add(new MyVector<Tuple<int, int>>());
                
            }


            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите смежные вершины для {i} и вес");
                
                foreach (string str in Console.ReadLine().Split(" "))
                {
                    if (str == "")
                        continue;
                    string[] Numbers = str.Split(",");
                    int num1 = Convert.ToInt32(Numbers[0]);
                    int num2 = Convert.ToInt32(Numbers[1]);
                    Graph[i].Add(new Tuple<int, int>(num1, num2));
                    

                }
                
            }
        }
    }
}