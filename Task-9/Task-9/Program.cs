using System;
using Task_8;
using ConsoleApp2;
namespace Task_9
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int Prio(string oper)
            {
                if (oper == "+" || oper == "-")
                    return 1;
                if (oper == "*" || oper == "/" || oper == "%")
                    return 2;
                if (oper == "^")
                    return 3;
                return 0;
            }


            string PolishNotationConvert(string seq, MyStack<string> operations)
            {
                seq += " ";

                string output = "";
                string numbers = "";
                string functions = "";
                int index = 0;
                bool flag = false;
                foreach (char symbol in seq)
                {
                    if (symbol == '-')
                    {
                        if (index < seq.Length && Char.IsDigit(seq[index + 1]) && functions == "")
                        {
                            numbers += "-";
                            continue;
                        }
                        else if (index < seq.Length && Char.IsDigit(seq[index + 1]) && functions != "")
                        {
                            flag = true;
                        }

                    }
                    if (Char.IsDigit(symbol))
                    {
                        numbers += symbol;
                        /*
                        if (functions == "")
                            numbers += symbol;
                        else {
                            flag = true;
                            numbers += symbol;
                        }
                        */
                    }



                    else if (symbol == ' ')
                    {
                        if (numbers != "" && functions != "")
                        {
                            operations.Push(functions);
                            output = output + numbers + " ";
                            numbers = "";
                            functions = " ";

                        }

                        else if (numbers != "")
                        {
                            output = output + numbers + " ";
                            numbers = "";
                        }



                        else if (functions != "")
                        {
                            operations.Push(functions);
                            functions = " ";

                        }

                    }


                    else if (Char.IsLetter(symbol))
                        functions += symbol;

                    else if (symbol == '(')
                        operations.Push("(");

                    else if (symbol == ')')
                    {
                        while (operations.Peek() != "(")
                        {
                            output = output + operations.Peek() + " ";
                            operations.Pop();

                        }
                        if (operations.Empty() == false)
                        {
                            operations.Pop();
                        }
                    }


                    else if (symbol == '+' || symbol == '-' || symbol == '/' || symbol == '*' || symbol == '%' || symbol == '^')
                    {
                        if (operations.Empty())
                        {
                            operations.Push(symbol.ToString());
                            continue;
                        }
                        if (Prio(operations.Peek()) == 0)
                        {
                            operations.Push(symbol.ToString());
                            continue;
                        }
                        while (Prio(symbol.ToString()) <= Prio(operations.Peek()))
                        {
                            output = output + operations.Peek() + " ";
                            operations.Pop();
                            if (operations.Empty())
                                break;
                        }
                        operations.Push(symbol.ToString());






                    }
                    index++;
                }

                while (!operations.Empty())
                {
                    output = output + operations.Peek() + " ";
                    operations.Pop();
                }
                return output;
            }






            void SymbolDef(string seqSymbol, MyStack<string> operations)
            {
                double num = Double.Parse(operations.Peek());
                operations.Pop();
                switch (seqSymbol)
                {
                    case "sin": { operations.Push(Math.Sin(num).ToString()); break; }
                    case "cos": { operations.Push(Math.Cos(num).ToString()); break; }
                    case "log": { operations.Push(Math.Log(num).ToString()); break; }
                    case "lg": { operations.Push(Math.Log10(num).ToString()); break; }
                    case "sqrt": { operations.Push(Math.Sqrt(num).ToString()); break; }
                    case "tg": { operations.Push(Math.Tan(num).ToString()); break; }
                    case "ctg": { operations.Push((1 / Math.Tan(num)).ToString()); break; }
                    case "abs": { operations.Push(Math.Abs(num).ToString()); break; }
                    case "exp": { operations.Push(Math.Exp(num).ToString()); break; }
                    case "dec": { operations.Push(Math.Round(num).ToString()); break; }
                    default: { break; }
                }

            }






            double ResultingPolish(string seq, MyStack<string> operations)
            {
                double answer = 0;


                string output = "";
                string numbers = "";
                string functions = "";
                int index = 0;
                foreach (char symbol in seq)
                {
                    if (symbol == '-')
                    {
                        if (index < seq.Length && Char.IsDigit(seq[index + 1]))
                        {
                            numbers += "-";
                            continue;
                        }
                    }
                    if (Char.IsDigit(symbol))
                        numbers += symbol;


                    else if (symbol == ' ')
                    {
                        if (numbers != "")
                        {
                            operations.Push(numbers);
                            numbers = "";
                        }

                        else if (functions != "")
                        {
                            if (functions == "max")
                            {
                                double numTop = Double.Parse(operations.Peek());
                                operations.Pop();
                                double numDown = Double.Parse(operations.Peek());
                                operations.Pop();
                                operations.Push(Math.Max(numTop, numDown).ToString());
                            }
                            else if (functions == "min")
                            {
                                double numTop = Double.Parse(operations.Peek());
                                operations.Pop();
                                double numDown = Double.Parse(operations.Peek());
                                operations.Pop();
                                operations.Push(Math.Min(numTop, numDown).ToString());
                            }

                            else if (functions == "mod")
                            {
                                double numTop = Double.Parse(operations.Peek());
                                operations.Pop();
                                double numDown = Double.Parse(operations.Peek());
                                operations.Pop();
                                operations.Push((numDown / numTop).ToString());
                            }
                            else SymbolDef(functions, operations);
                            functions = "";
                        }

                    }


                    else if (Char.IsLetter(symbol))
                        functions += symbol;







                    else if (symbol == '+' || symbol == '-' || symbol == '/' || symbol == '*' || symbol == '%' || symbol == '^')
                    {
                        if (!operations.Empty())
                        {
                            double numTop = Double.Parse(operations.Peek());
                            operations.Pop();
                            double numDown = Double.Parse(operations.Peek());
                            operations.Pop();
                            operations.Push(DoOperation(symbol, numTop, numDown).ToString());
                        }
                    }
                    index++;



                }
                return Double.Parse(operations.Peek());

                double DoOperation(char symbol, double NumTop, double NumDown)
                {
                    switch (symbol)
                    {
                        case '+': { return NumTop + NumDown; break; }
                        case '-': { return NumDown - NumTop; break; }
                        case '/': { return NumDown / NumTop; break; }
                        case '*': { return NumTop * NumDown; break; }
                        case '%': { return NumTop % NumDown; break; }
                        case '^': { return Math.Pow(NumDown, NumTop); break; }
                        default: { return 0; }
                    }

                }
            }
            MyStack<string> number = new MyStack<string>();
            MyStack<string> operation = new MyStack<string>();
            Console.WriteLine("Есть два режима работы i) Выражение и ii) выражение с переменными");
            string seqs;
            seqs = Console.ReadLine();
            if (seqs == "i")
            {
                seqs = Console.ReadLine();
                string pol = PolishNotationConvert(seqs, operation);
                Console.WriteLine(pol);
                Console.WriteLine(ResultingPolish(pol, operation));

            }
            else {
                string? line = "";
                string per = "";
                string val = "";
                Console.WriteLine("Введите переменные");
                line = Console.ReadLine();
                Dictionary<string,string> stringPair = new Dictionary<string,string>();
                while (line != "") {
                    foreach (char s in line) {
                        if (s != '=' && Char.IsDigit(s)==false)
                            per += s;
                        if (Char.IsDigit(s))
                            val += s;
                    }
                    stringPair[per] = val;

                    line = Console.ReadLine();
                }
                Console.WriteLine("Введи выражение");
                seqs = Console.ReadLine();
                string newLine = "";
                string reader = "";
                foreach (char s in seqs) {
                    if (Char.IsLetter(s)) {
                        reader += s;
                        if (stringPair.ContainsKey(reader))
                            newLine = newLine + stringPair[reader.ToString()];
                        else
                            newLine = newLine + s;
                    }
                    else if (s == ' ')
                    {
                        newLine = newLine + ' ';
                        if (stringPair.ContainsKey(reader))
                            newLine = newLine + stringPair[reader];
                        
                    }
                    else newLine = newLine + s;
                }
                Console.WriteLine(newLine);
            }
        }
    }
}