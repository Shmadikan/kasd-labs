using System.IO;
using System;
using System.Diagnostics.Tracing;
using System.ComponentModel;





void ReaderFromFile(StreamReader reader, int[] mas) {
    ///Метод для чтения 1 строки матрицы из файла.
    string? line = reader.ReadLine();
    if (line != null)
    {
        string[] s = line.Split(' ');
        int i = 0;
        foreach (string num in s)
        {
            mas[i] = int.Parse(num);
            i++;
        }
    }
}


bool MatrSimmetry(int[][] matr, int n) {
    ///Метод проверки матрицы на симметричность.
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) { 
            if (i!=j && matr[i][j] != matr[j][i])return false;
        }
    }
    return true;
}


double MatrixMultipliaction(int[][] matr,int[] x_vector){
    ///Метод умножения матрицы на вектор столбец.
    int num = 0;
    
    for (int j = 0; j < matr.Length; j++)
    {
        int row_val = 0;
        for (int i = 0; i < matr.Length; i++)
        {
            row_val += x_vector[i] * matr[i][j];
            

        }
        num+=x_vector[j]*row_val;
    }
    return Math.Sqrt((double) num);
}

string Path = "matr.txt";
StreamReader reader = new StreamReader(Path);
string? Line;
Line = reader.ReadLine();
string[] vec = Line.Split(' ');
int[] vector = new int[vec.Length];

//Читаем вектор
for (int num=0;num<vec.Length;num++)
{
    int number = int.Parse(vec[num]);
    vector[num] = number;
}

int n = int.Parse(Line = reader.ReadLine());
int[][] matr = new int[n][];
for (int i = 0; i < matr.Length; i++)
    matr[i] = new int[n];



//Читаем матрицу.
for (int i = 0; i < n;i++) {
    ReaderFromFile(reader, matr[i]);
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write($"{matr[i][j]} ");
    }
    Console.WriteLine('\n');
}
if (MatrSimmetry(matr, n) == true) {
    Console.WriteLine("Matrix is sim");
    Console.WriteLine(MatrixMultipliaction(matr, vector));
}

reader.Close();