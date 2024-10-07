using System.Collections;
using System.Runtime.ExceptionServices;
using ConsoleApp2;
using ConsoleApp3;
namespace Task_12
{
    internal class Program
    {
        
        public struct Applications: IComparable
        {
            public int priority;
            public int index;
            public int stepNumber;

            public int CompareTo(object? obj)
            {
                throw new NotImplementedException();
            }
        }


        public class MyComparer2 : Comparer<Applications>
        {

            public override int Compare(Applications x, Applications y)
            {
                return y.priority.CompareTo(x.priority) * -1;
            }
        }
        


        static void Main(string[] args)
        {
            Applications s;
            
            int step = Convert.ToInt32(Console.ReadLine());
            MyComparer2 c = new MyComparer2();
            Random randObj = new Random();
            
            
            
            
            MyPriorityQueue<Applications> N = new MyPriorityQueue<Applications>(10, c);
            int indexOfApp = 1;
            string path = "log.txt";
            StreamWriter writer = new StreamWriter(path);
            
            Applications lastNum;

            try
            {
                for (int i = 1; i <= step; i++)
                {

                    int countOfApplication = randObj.Next(1, 10);
                    for (int j = 0; j < countOfApplication; j++)
                    {
                        int Priority = randObj.Next(1, 6);
                        Applications newApp;
                        newApp.priority = Priority; newApp.index = indexOfApp; newApp.stepNumber = i;
                        writer.WriteLine($"Add {newApp.index} {newApp.priority} {newApp.priority}");
                        N.Add(newApp);
                        indexOfApp++;
                    }
                }
                Console.WriteLine("");



                while (N.Size() > 1)
                {
                    Applications extract = N.Peek();
                    //Console.Write($"{N.Peek().index} ");
                    
                    writer.WriteLine($"Delete {extract.index} {extract.priority} {extract.priority}");
                    N.Pool();
                }
                Console.WriteLine($"{N.Peek().index}");
                lastNum = N.Peek();
                writer.Close();





                Console.WriteLine($"Вышла последняя заявка, ожидающая дольше всех! \n" +
                    $"Номер заявки: {lastNum.index} \n" +
                    $"Шаг поступления: {lastNum.stepNumber} \n" +
                    $"Её приоритет: {lastNum.priority} \n"
                    );
            }
            
            catch ( Exception e )
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}