using Task_8;
using ConsoleApp2;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string PolishNotation(string seq, MyStack<string> StackOper, Dictionary<string, string> vars = null)
            {
                int i = 0;
                bool flag = false;
                string output = "";
                string number = "";
                string strFunc = "";
                char[] seqArray = seq.ToCharArray();
                char[] operators = { '+', '-' , '/','%','*'};
                
                while (i < seqArray.Length)
                {
                    var s = seqArray[i];
                    if (seqArray[i] == '(')
                    {
                        if (seqArray[i] == '(' && strFunc != "")
                        {
                            flag = true;


                        }
                        else
                        {
                            StackOper.Push(seqArray[i].ToString());
                        }


                    }

                    else if (seqArray[i] == '.' || seqArray[i] == ',') {
                        if (number != "")
                            number = number + ".";
                        else
                            throw new Exception();
                    }


                    else if (seqArray[i] == ')')
                    {
                        if (!flag)
                        {
                            if (Char.IsDigit(seqArray[i - 1]))
                            {
                                output = output + number + " ";
                                number = "";
                            }
                            BracketPush();
                        }
                        else
                        {
                            if (number != "")
                                output = output + number + " ";
                            output = output + strFunc + " ";
                            strFunc = "";
                            number = "";
                            flag = false;
                        }
                    }


                    else if (Char.IsDigit(seqArray[i]))
                    {
                        number = number + seqArray[i].ToString();

                    }




                    else if (seqArray[i] == '-')
                    {
                        if (i != seqArray.Length - 1)
                        {
                            if (Char.IsDigit(seqArray[i + 1]))
                                number = number + '-'.ToString();

                            else if (seqArray[i + 1] == '(' || seqArray[i + 1] == ' ')
                                OperatorsPushing('-');
                        }
                    }

                    else if (Char.IsLetter(seqArray[i]))
                    {
                        if (vars == null)
                            strFunc += seqArray[i].ToString();
                        else
                            number = number + vars[seqArray[i].ToString()];

                    }

                    else if (seqArray[i] == ' ')
                    {
                        if (number.Length != 0)
                        {
                            output = output + number + " ";
                            number = "";
                        }

                        if (strFunc.Length != 0 && !flag)
                        {
                            output = output + strFunc + " ";
                            strFunc = "";
                        }

                    }

                    else
                    {
                        if (number.Length != 0)
                        {
                            output = output + number + " ";
                            number = "";


                        }

                        if (strFunc.Length != 0 && !flag)
                        {
                            output = output + strFunc + " ";
                            strFunc = "";
                        }

                        switch (seqArray[i])
                        {





                            case '+': { OperatorsPushing('+'); break; }
                            case '-': { OperatorsPushing('-'); break; }
                            case '*': { OperatorsPushing('*'); break; }
                            case '/': { OperatorsPushing('/'); break; }
                            case '%': { OperatorsPushing('%'); break; }
                            case '^': { OperatorsPushing('^'); break; }
                        }


                    }
                    i++;


                }
                if (number != "") {
                    output = output + number + " ";
                    number = "";

                }

                if (strFunc.Length != 0)
                {
                    StackOper.Push(strFunc);
                    strFunc = "";
                }

                while (!StackOper.Empty()) {
                    output = output + StackOper.Peek() + " ";
                    StackOper.Pop();
                
                }


                return output;


                void OperatorsPushing(char oper) {
                    if (StackOper.Empty())
                    {
                        StackOper.Push(oper.ToString());
                        return;
                    }
                    if (OperatorsPriority(StackOper.Peek()) == 0)
                    {
                        StackOper.Push(oper.ToString());
                        return;
                    }



                    while (!StackOper.Empty()) {
                        if (OperatorsPriority(oper.ToString()) <= OperatorsPriority(StackOper.Peek()))
                        {
                            output = output + StackOper.Peek() + " ";
                            StackOper.Pop();
                        }
                        else
                            break;
                    }
                    StackOper.Push(oper.ToString());
                }

                void BracketPush() {
                    while (!StackOper.Empty()) { 
                        string val = StackOper.Peek();
                        if (val == "(")
                        {
                            StackOper.Pop();
                            return;
                        }
                        
                        output = output + val + " ";
                        StackOper.Pop();
                    }
                
                
                }


                int OperatorsPriority(string Operator) {
                    if (Operator == "+" || Operator == "-")
                        return 1;
                    if (Operator == "*" || Operator == "/" || Operator == "%")
                        return 2;
                    if (Operator == "^")
                        return 3;
                    return 0;
                }
            }

            string ResultOfNotation(string polishPerf, MyStack<string> ValStack, Dictionary<string, string> vars = null) {
                
                int i = 0;
                bool flag = false;
                string output = "";
                string number = "";
                string strFunc = "";
                char[] seqArray = polishPerf.ToCharArray();

                while (i < seqArray.Length) {
                    if (Char.IsDigit(seqArray[i]))
                    {
                        number += seqArray[i];
                    }

                    else if (seqArray[i] == '.' & number != "") { 
                        number = number+',';
                    }

                    else if (seqArray[i] == '-' && i < seqArray.Length - 1)
                    {
                        if (Char.IsDigit(seqArray[i + 1]))
                            number = "-" + number;
                        else if (seqArray[i + 1] == ' ')
                        {
                            Resulting("-");


                        }



                    }

                    else if (Char.IsLetter(seqArray[i]))
                    {
                        if (vars == null)
                            strFunc = strFunc + seqArray[i];
                        else
                        {
                            if (vars.ContainsKey(seqArray[i].ToString()))
                                ValStack.Push(vars[seqArray[i].ToString()]);
                            else
                                strFunc = strFunc + seqArray[i];
                        }
                    }

                    else if (seqArray[i] == ' ')
                    {
                        if (number != "")
                        {
                            ValStack.Push(number);
                            number = "";
                        }

                        if (strFunc != "")
                        {
                            Resulting(strFunc);
                            strFunc = "";
                        }

                    }
                    else
                        Resulting(seqArray[i].ToString());


                    i++;
                }

                void Resulting(string strFunc) {
                    
                    
                    double stackTop;
                    
                    double stackDown;
                    
                    switch (strFunc) {
                        case "+": {
                             stackTop = PeekPop();
                             stackDown = PeekPop();
                             ValStack.Push((stackTop + stackDown).ToString());
                             break;
                            
                        }
                        case "-": {
                                stackTop = PeekPop();
                                stackDown = PeekPop();
                                ValStack.Push((stackDown - stackTop).ToString());
                                break;

                        }

                        case "/": {
                                stackTop = PeekPop();
                                stackDown = PeekPop();
                                ValStack.Push((stackDown / stackTop).ToString());
                                break;
                        }

                        case "%":
                            {
                                stackTop = PeekPop();
                                stackDown = PeekPop();
                                ValStack.Push((stackDown % stackTop).ToString());
                                break;
                            }

                        case "*":
                            {
                                stackTop = PeekPop();
                                stackDown = PeekPop();
                                ValStack.Push((stackTop * stackDown).ToString());
                                break;

                            }
                        case "^": {
                                stackTop = PeekPop();
                                stackDown = PeekPop();
                                ValStack.Push((Math.Pow(stackDown, stackTop)).ToString());
                                break;

                        }

                        case "sin": { 
                                stackTop = PeekPop();
                                ValStack.Push(Math.Sin(stackTop).ToString());
                                break;
                            }

                        case "cos":
                            {
                                stackTop = PeekPop();
                                ValStack.Push(Math.Cos(stackTop).ToString());
                                break;
                            }
                        case "tg":
                            {
                                stackTop = PeekPop();
                                ValStack.Push(Math.Tan(stackTop).ToString());
                                break;
                            }
                        case "ctg":
                            {
                                stackTop = PeekPop();
                                ValStack.Push((1/Math.Tan(stackTop)).ToString());
                                break;
                            }
                        case "ln":
                            {
                                stackTop = PeekPop();
                                ValStack.Push(Math.Log(stackTop).ToString());
                                break;
                            }
                        case "lg":
                            {
                                stackTop = PeekPop();
                                ValStack.Push(Math.Log10(stackTop).ToString());
                                break;
                            }
                        case "exp":
                            {
                                stackTop = PeekPop();
                                ValStack.Push(Math.Exp(stackTop).ToString());
                                break;
                            }
                        case "abs":
                            {
                                stackTop = PeekPop();
                                ValStack.Push(Math.Abs(stackTop).ToString());
                                break;
                            }
                        case "dec":
                            {
                                stackTop = PeekPop();
                                ValStack.Push(Math.Round(stackTop).ToString());
                                break;
                            }
                        case "max":
                            {
                                stackTop = PeekPop();
                                stackDown = PeekPop();
                                ValStack.Push((Math.Max(stackDown, stackTop)).ToString());
                                break;

                            }

                        case "min":
                            {
                                stackTop = PeekPop();
                                stackDown = PeekPop();
                                ValStack.Push((Math.Min(stackDown, stackTop)).ToString());
                                break;

                            }
                    }     
                    
                    
                    
                }
                return ValStack.Peek();



                double PeekPop() {
                    
                    double num = Double.Parse(ValStack.Peek());
                    ValStack.Pop();
                    return num;
                }

            }


            Dictionary<string, string> dict = new Dictionary<string, string>();
            MyStack<string> stackForOperators = new MyStack<string>();
            MyStack<string> ValStack = new MyStack<string>();
            Console.WriteLine("Лучший калькулятор в обратной польской нотации.");
            if (args.Length == 0)
            {
                while (true)
                {
                    string seq = Console.ReadLine();
                    if (seq == "end")
                        break;
                    string polska = PolishNotation(seq, stackForOperators);

                    Console.WriteLine($"Выражение в польской нотации: {polska}");
                    Console.WriteLine($"Результат : {ResultOfNotation(polska, ValStack)}");
                }
            }
            else {
                string letters = "";
                string numbers = "";
                for (int i = 0; i < args.Length; i++) {
                    foreach (char c in args[i])
                    {
                        if (Char.IsLetter(c))
                            letters += c;
                        if (Char.IsDigit(c))
                            numbers += c;
                    }
                    dict[letters] = numbers;
                    
                    letters = "";
                    numbers = "";
                }
                Console.WriteLine("Введите математическое выражение");
                string seq = Console.ReadLine();
                string polska = PolishNotation(seq, stackForOperators);
                Console.WriteLine($"Выражение в польской нотации: {polska}");
                Console.WriteLine($"Результат : {ResultOfNotation(polska, ValStack, dict)}");


            }       

                   

            
            

        }
    }
}