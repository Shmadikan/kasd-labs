using System.Runtime.InteropServices;

/// Используется файл html.txt
/// Текст, содержащийся в файле.
/// <!DOCTYPE html>
/// <html>
/// <head>
/// < metacharset = "utf-8">
/// <title> Пример веб - страницы </title>
/// </head>
/// <body>
/// <h1> Заголовок </h1>
/// <p> Первый абзац.</p>
/// <p> Второй абзац.</p>
///</body>
///</html> s



using System;
using Task4;
namespace ConsoleApp1
{
    internal class Program
    {



        static void Main(string[] args)
        {
            bool FindWordInArray(string htmlTag, MyArrayList<string> array)
            {
                /// Метод, который находит совпадение в массиве.
                /// Принцип работы: приведение слов к единообразию -
                /// Удаление не буквенных символов, а также запись в нижнем регистер.


                string changeTag = "";
                string changeArrayTag = "";
                foreach (char i in htmlTag)
                {
                    if (Char.IsLetter(i))
                        changeTag += Char.ToLower(i);
                }

                for (int i = 0; i < array.Size(); i++)
                {
                    foreach (char c in array.get(i))
                    {
                        if (Char.IsLetter(c))
                            changeArrayTag += Char.ToLower(c);

                    }
                    if (changeTag == changeArrayTag) return true;
                    changeArrayTag = "";
                }

                return false;
            }







            MyArrayList<string> stringArray = new MyArrayList<string>(20);
            string path = "html.txt";
            StreamReader fileReader = new StreamReader(path);
            string htmlData = "";
            try
            {
                bool flag = false;
                bool SpaceFlag = false;
                while (!fileReader.EndOfStream)
                {

                    char symbol = (char)fileReader.Read();
                    if (symbol == '<')
                    {
                        htmlData += symbol;
                        SpaceFlag = true;
                        flag = true;
                        continue;
                    }


                    if (flag)
                    {
                        if (Char.IsWhiteSpace(symbol) == false && SpaceFlag && symbol != '>')
                            htmlData += symbol;
                        else if (Char.IsWhiteSpace(symbol))
                            SpaceFlag = false;

                        if (symbol == '>')
                        {
                            htmlData += symbol;
                            flag = false;
                            if (stringArray.Size() == 0)
                                stringArray.AddElement(htmlData);
                            else
                            {
                                if (FindWordInArray(htmlData, stringArray) == false)
                                    stringArray.AddElement(htmlData);
                            }
                            htmlData = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            stringArray.Print();
        }
    }
}