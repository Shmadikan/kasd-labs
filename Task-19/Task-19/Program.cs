using System;
using System.Text.RegularExpressions;
using HashMap;
namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string p = "sss";
            MyHashMap<string, int> dict = new MyHashMap<string, int>();

            string path = "input.txt";
            StreamReader reader = new StreamReader(path);
            string text = "";
            string line = "";
            try
            {
                while (line != null)
                {
                    line = reader.ReadLine();
                    text += line + "\n";

                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
            reader.Close();



            Regex Expression = new Regex(@"(?<=</?)?\w+ ?(?=/?>)");
            MatchCollection matchCollection = Expression.Matches(text);
            foreach (Match match in matchCollection)
            {
                if (match.Length > 0)
                {
                    if (!dict.ContainsKey(match.Value.ToLower()))
                        dict.Put(match.Value.ToLower(), 1);
                    else
                        dict.Put(match.Value.ToLower(), dict.Get(match.Value.ToLower()) + 1);
                }
            }
            Tuple<string, int>[] answer = dict.EntrySet();
            for (int i = 0; i < answer.Length; i++)
            {
                Console.WriteLine(answer[i]);
            }
        }
    }
}