using System.Runtime.InteropServices;

namespace Task_3
{
    class AllSortIsHere {
        public void BubbleSort(int[] mas) {
            for (int i = 0; i < mas.Length; i++)
                for (int j = mas.Length - 1; j > i; j--) 
                    if (mas[j] < mas[j - 1])
                    {
                        int tmp = mas[j];
                        mas[j] = mas[j - 1];
                        mas[j - 1] = tmp;
                    }
        }

        
        public void ShakeSort(int[] mas) {
            bool f = true;
            int right = mas.Length - 1;
            int left = 0;
            while (left < right && f != false) {
                f = false;
                for (int i = right; i > left; i--) 
                    if (mas[i] < mas[i - 1])
                    {
                        int tmp = mas[i];
                        mas[i] = mas[i - 1];
                        mas[i - 1] = tmp;
                        f = true; 
                    }
                left += 1;
                for (int j = left; j < right; j++)
                    if (mas[j] > mas[j + 1])
                    {
                        int tmp = mas[j];
                        mas[j] = mas[j + 1];
                        mas[j + 1] = tmp;
                        f = true;
                    }
                right -= 1;
            }
        }


        public void CombSort(int[] mas) {
            double subFactor = 1.25;
            int currentDistanse = mas.Length - 1;
            while (currentDistanse > 0)
            {
                for (int i = 0; i + currentDistanse < mas.Length; i += 1) {
                    if (mas[i] > mas[i + currentDistanse]) { 
                        int tmp = mas[i];
                        mas[i] = mas[i + currentDistanse];
                        mas[i + currentDistanse] = tmp;
                    }
                }
                currentDistanse =(int) ( currentDistanse / subFactor);
            }
        }


        public void InsertionSort(int[] mas) {
            int i, j, temp;
            for (i = 1; i < mas.Length; i++) {
                temp = mas[i];
                for (j = i - 1; j >= 0; j--) {
                    if (mas[j] < temp) break;
                    mas[j + 1] = mas[j];
                    mas[j] = temp;
                }
            }
        }


        public void ShellSort(int[] mas) {
            int step = mas.Length / 2;
            while (step > 0)
            {
                for (int i = step; i < mas.Length; i++) {
                    int j = i;
                    int stepBack = j - step;
                    while (stepBack >= 0 && mas[stepBack] > mas[j]) {
                        swap(j, stepBack);
                        j = stepBack;
                        stepBack = j - step;
                    }
                }
                step /= 2;
            }
            void swap(int j, int stepBack) {
                int tmp = mas[stepBack];
                mas[stepBack] = mas[j];
                mas[j] = tmp;
            }
        }


        public void TreeSort(int[] mas) {
            
        }
        struct Tree {
            RefTree left;
            RefTree right;
            struct RefTree
            {
                int val;
            }
        }
    
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AllSortIsHere sortObject = new AllSortIsHere();
            int[] mas = {3, 2, 1, 9, 5, 6, 7, 8, 11, 10 };
            sortObject.ShellSort(mas);
            Console.WriteLine(string.Join(" ",mas));
        }
    }
}