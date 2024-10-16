using System;
using task_14;

namespace Task_15
{
    internal class Program
    {
        


        static void Main(string[] args)
        {
            int CountOfDigit(string First)
            {
                int count = 0;
                foreach (char c in First)
                {
                    if (Char.IsDigit(c))
                        count++;
                }
                return count;
            }





            string path = "input.txt";
            StreamReader reader = new StreamReader(path);
            MyArrayDeque<string> deque = new MyArrayDeque<string>();
            int n;
            n = Convert.ToInt32(Console.ReadLine());
            string? line = reader.ReadLine();
            deque.Add(line);
            try
            {
                while (line != null) {
                    line = reader.ReadLine();
                    if (line == null)
                        break;
                    int currentCount = CountOfDigit(line);
                    int firstCount  = CountOfDigit(deque.GetFirst());
                    if (currentCount > firstCount)
                        deque.Add(line);
                    else 
                        deque.AddFirst(line);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
            string newPath = "sorted2.txt";
            StreamWriter writer = new StreamWriter(newPath);
            
            

            try {
                string[] arrays = deque.ToArray();
                foreach (string str in arrays) { 
                    writer.WriteLine(str);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            string[] strs = deque.ToArray();
            foreach (string str in strs) {
                int cnt = 0;
                foreach (char symbol in str)
                    if (Char.IsWhiteSpace(symbol))
                        cnt += 1;
                if (cnt > n)
                    deque.Remove(str);
            }
            Console.WriteLine(deque.Size());
            Console.WriteLine(deque.GetFirst());
            writer.Close();
            reader.Close();
        }
    }
}