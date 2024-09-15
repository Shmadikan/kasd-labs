using System;
class Programm {
    struct ComplexNumber
    {
        public double Real;
        public double Imag;



        public void SumOfComplex(ref ComplexNumber num, double real, double imag)
        {
            num.Real += real;
            num.Imag += imag;
        }


        public void SubOfComplex(ref ComplexNumber num, double real, double imag)
        {
            num.Real -= real;
            num.Imag -= imag;
        }


        public void MulOfComplex(ref ComplexNumber num, double real, double imag)
        {
            num.Real = (num.Real * real) - (num.Imag * imag);
            num.Imag = (num.Real * imag) + num.Imag + real;
        }


        public void DivOfComplex(ref ComplexNumber num, double real, double imag)
        {
            num.Real /= real;
            num.Imag /= imag;
        }


        public double ModuleOfComplex(ComplexNumber num)
        {
            double real = num.Real;
            double imag = num.Imag;   
            return Math.Sqrt((real * real) + (imag * imag));
        }


        public double ArgOfComplex(ComplexNumber num) {
            double x = num.Real;
            double y = num.Imag;
            if (x > 0 && y >= 0) return Math.Atan(y / x);
            else if (x < 0 && y >= 0) return Math.PI - Math.Atan(Math.Abs(y / x));
            else if (y < 0 && x < 0) return Math.PI + Math.Atan(Math.Abs(y / x));
            else if (x > 0 && y < 0) return 2 * Math.PI - Math.Atan(Math.Abs(y / x));
            else if (x == 0 && y > 0) return Math.PI / 2;
            else if (x == 0 && y < 0) return (Math.PI * 3) / 2;
            return 0;
        }


        public ComplexNumber ComplexCreate(ComplexNumber num) {
           
            Console.Write("Введите вещественную часть a=");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите вещественную часть b=");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Создано число {a} + {b}i");
            num.Real = a;
            num.Imag = b;
            return num;
        }


        public double GiveBackReal(ComplexNumber num) => num.Real;


        public double GiveBackImag(ComplexNumber num) => num.Imag;


        public void ComplexPrint(ComplexNumber num) => Console.WriteLine($"Число {num.Real} + {num.Imag}i");
    }

    static void Main(String[] args)
    {
        ComplexNumber number = new ComplexNumber();
        number.Real = 0;
        number.Imag = 0;
        string? clientInput = "";
        bool f = true;
        while (f)
        {
            Console.Write("Введите команду =");
            clientInput = Console.ReadLine();
            switch (clientInput)
            {
                case "S":
                    {
                        ComplexNumber secondNumber = new ComplexNumber();
                        secondNumber = secondNumber.ComplexCreate(secondNumber);
                        number.SumOfComplex(ref number, secondNumber.Real, secondNumber.Imag);
                        Console.Write("Результат Суммы: "); number.ComplexPrint(number);
                        break;
                    }
                case "s":
                    {
                        ComplexNumber secondNumber = new ComplexNumber();
                        secondNumber = secondNumber.ComplexCreate(secondNumber);
                        number.SubOfComplex(ref number, secondNumber.Real, secondNumber.Imag);
                        Console.Write("Результат Вычитания: "); number.ComplexPrint(number);
                        break;
                    }
                case "M":
                    {
                        ComplexNumber secondNumber = new ComplexNumber();
                        secondNumber = secondNumber.ComplexCreate(secondNumber);
                        number.MulOfComplex(ref number, secondNumber.Real, secondNumber.Imag);
                        Console.Write("Результат умножения: ");number.ComplexPrint(number);
                        break;
                    }
                case "D":
                    {
                        ComplexNumber secondNumber = new ComplexNumber();
                        secondNumber = secondNumber.ComplexCreate(secondNumber);
                        number.DivOfComplex(ref number, secondNumber.Real, secondNumber.Imag);
                        Console.Write("Результат Деления: "); number.ComplexPrint(number);
                        break;
                    }
                case "m":
                    {
                        Console.WriteLine($"Комплексное число {number.Real} + {number.Imag}i");
                        Console.WriteLine($"Модуль комплексного числа = {number.ModuleOfComplex(number)}");
                        break;
                    }
                case "a":
                    {
                        Console.WriteLine($"Комплексное число {number.Real} + {number.Imag}i");
                        Console.WriteLine($"Аргумент комплексного числа = {number.ArgOfComplex(number)}");
                        break;
                    }
                case "R": { Console.WriteLine($"Вещественная часть {number.Real}"); break; }
                case "I": { Console.WriteLine($"Мнимая часть {number.Imag}"); break; }
                case "P": { number.ComplexPrint(number); break; }
                case "C":
                    {
                        Console.WriteLine("Создание нового комплексного числа для работы с ним");
                        number = number.ComplexCreate(number); break;
                    }
                case "Q": { Console.WriteLine("Выход из цикла..."); f = false; break; }
                default: { Console.WriteLine("Нету такой команды"); break; }
            }
        }
    }

}