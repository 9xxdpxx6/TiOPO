using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiOPO
{
    using System; //1
    using System.Text; //2
    namespace SoftwareTestingLabsExamples01x03 //3
    { //4
        class Program //5
        { //6
          //Метод, считающий сумму элементов массива //7
            static int sum(int[] x, int N) //8
            { //9
                int s = 0; //10
                for (int i = 0; i < N; i++) //11
                    s += x[i]; //12
                return s; //13
            } //14
              //Метод для ввода целых чисел с клавиатуры //15
            static int ReadInt(string prompt) //16
            { //17
                Console.Write(prompt); //18
                int x = int.Parse(Console.ReadLine()); //19
                return x; //20
            } //21
            static void Main(string[] args) //22
            { //23
                const int N = 10; //24
                int[] a = new int[N] { 1, 3, -5, 0, 4, 6, -1, 9, 3, 2 }; //25
                                                                         //Найдем максимальный элемент массива //26
                int m = a[0]; //27
                for (int i = 1; i < N; i++) //28
                    if (m < a[i]) //29
                        m = a[i]; //30
                Console.WriteLine(m); //31
                                      //Найдем сумму элементов массива //32
                int s; //33
                s = sum(a, N); //34
                Console.WriteLine(s); //35
                int z = s / m; //36
                int k = 0; //37
                for (int i = 0; i < N; i++) //38
                    if (a[i] > z) //39
                        k += a[i]; //40
                    else //41
                        k -= a[i]; //42
                Console.WriteLine(k); //43
                int x, y; //44
                x = ReadInt(""); //45
                y = ReadInt(""); //46
                s = 0; //47
                while ((x != 0) && (y != 0)) //48
                { //49
                    x--; //50
                    y--; //51
                    s += x + y; //52
                } //53
                Console.WriteLine(s); //54
            } //55
        } //56
    } //57
}
