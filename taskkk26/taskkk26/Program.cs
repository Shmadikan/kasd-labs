using System.Collections;
using System;
using System.Numerics;
using Task_24;
namespace taskkk26
{
    internal class Program
    {
        public class MyComparator<T> : Comparer<T> where T : IComparable, IConvertible
        {
            public override int Compare(T? x, T? y)
            {
                if (x is string && y is string)
                {
                    
                    ArrayList vecx = new ArrayList();
                    ArrayList vecy = new ArrayList();

                    string xs = x as string;
                    string ys = y as string;
                    string[] xwords = xs.Split(" ");
                    string[] ywords = ys.Split(" ");

                    int minx = xwords[0].Length;
                    int miny = ywords[0].Length;
                    vecx.Add(xwords[0]);
                    vecy.Add(ywords[0]);
                    while (true) {
                        for (int i = 0; i < xwords.Length; i++) {
                            if (xwords[i] != "")
                            if (xwords[i].Length < minx && vecx.Contains(xwords[i]) == false)
                            {
                                minx = xwords[i].Length;
                                vecx.Add(xwords[i]);
                            }
                        }


                        for (int i = 0; i < ywords.Length; i++)
                        {
                            if (ywords[i] != "")
                            if (ywords[i].Length < miny && vecy.Contains(ywords[i]) == false)
                            {
                                miny = ywords[i].Length;
                                vecy.Add(ywords[i]);
                            }
                        }

                        if (minx < miny)
                            return -1;
                        else if (minx > miny)
                            return 1;
                        else if (vecx.Count == xwords.Length)
                            return -1;
                        else if (vecy.Count == ywords.Length)
                            return 1;
                    }
                    
                }




                else
                    return x.CompareTo(y);
                

            }
        }
        static void Main(string[] args)
        {
            MyTreeSet<string> myTreeSet = new MyTreeSet<string>(new MyComparator<string>());
            string path = "input.txt";
            StreamReader reader = new StreamReader(path);
            string? line = reader.ReadLine();
            if (line == null)
                return;
            while (line != null) {
                if (line != null) 
                    myTreeSet.Put(line);
                line = reader.ReadLine(); 
            }

            foreach (string answer in myTreeSet)
                Console.WriteLine(answer);

        }
    }
}
