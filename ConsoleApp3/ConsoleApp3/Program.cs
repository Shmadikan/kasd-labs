using System;
using ConsoleApp2;
namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool CheckInArray(string s, MyVector<string> IpVector)
            {
                for (int i = 0; i < IpVector.Size(); i++) {
                    if (IpVector.get(i) == s)
                        return true;
                }
                return false;
            }





            MyVector<string> IpVector = new MyVector<string>();
            string path = "IPV4.txt";
            StreamReader reader = new StreamReader(path);
            string? line = reader.ReadLine();
            while (line != null) {
                try
                {
                    string[] splitLine = line.Split(" ");
                    int cnt = splitLine.Length;
                    foreach (string s in splitLine)
                    {
                        bool flag = false;
                        string[] inIPV4 = s.Split(".");
                        foreach (string ipBlock in inIPV4)
                        {

                            int numIpForm = Convert.ToInt32(ipBlock);
                            if (numIpForm > 0 && numIpForm <= 255)
                            {
                                flag = true;
                            }
                        }
                        if (flag)
                            if (!CheckInArray(s, IpVector))
                                IpVector.Add(s);
                    }
                    line = reader.ReadLine();
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.ToString());
                }
            }
            IpVector.Print();
        }
    }
}
