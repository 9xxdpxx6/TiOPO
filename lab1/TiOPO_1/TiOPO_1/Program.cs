using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiOPO_1
{
    
        class Program
        {
            static int sqr(int x)
            { //10
                int q = x * x; //11
                return q; //12
            } //13
            static void Main(string[] args)
            { //0
                const int N = 10; //1
                int[] a = { 5, 2, 7, -9, 4, 8, -1, 0, 3, 6 }; //2
                                                              //Найдем сумму квадратов //3
                                                              //положительных элементов массива //4
                int s = 0; //5
                for (int i = 0; i < N; i++) //6
                    if (a[i] > 0) s += sqr(a[i]); //7
                Console.WriteLine("Сумма квадратов равна: {0}", s); //8
            } //9
        }
    }
