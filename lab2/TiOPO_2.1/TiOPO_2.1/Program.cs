using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiOPO_2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Добавляем прослушиватель для вывода трассировки в консоль
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.AutoFlush = true;

            Trace.TraceInformation("Начало вычисления факториала.");

            int n = 1;
            long factorial = 1; // Используем long, чтобы отсрочить переполнение

            // Бесконечный цикл для демонстрации переполнения
            while (true)
            {
                try
                {
                    // Проверяем переполнение с помощью checked
                    long previousFactorial = factorial;
                    factorial = checked(factorial * n);

                    // Вывод текущего значения в трассировку
                    Trace.WriteLine($"n = {n}, n! = {factorial}");

                    n++;
                }
                catch (OverflowException)
                {
                    // При переполнении выводим ошибку в лог трассировки и выходим из цикла
                    Trace.TraceError($"Арифметическое переполнение при вычислении {n}!");
                    // Используем Assert для индикации ошибки в отладке
                    Debug.Fail($"Произошло переполнение на шаге n = {n}. Максимальное значение: {factorial}");
                    break;
                }
            }

            Trace.TraceInformation("Вычисления завершены.");
            Console.ReadKey();
        }
    }
}