using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiOPO_2
{
    internal class Program
    {
        // Подынтегральная функция (Вариант 2)
        static double f(double x)
        {
            return (Math.Pow(x, 2) + Math.Sin(0.48 * (x + 2))) / Math.Exp(Math.Pow(x, 2) + 0.38);
        }

        // Метод Симпсона
        static double SimpsonIntegration(double a, double b, int n)
        {
            // Убедимся, что n четное для метода Симпсона
            if (n % 2 != 0) n++;
            double h = (b - a) / n;
            double sum = f(a) + f(b);

            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                // Проверка границ при помощи Assert
                Debug.Assert(x >= a && x <= b, $"Переменная x ({x}) вышла за границы интегрирования [{a}, {b}]");
                sum += (i % 2 == 0) ? 2 * f(x) : 4 * f(x);
            }
            return sum * h / 3;
        }

        // Правило Рунге для оценки погрешности (p = 4 для Симпсона)
        static double RungeError(double I_n, double I_2n, int p = 4)
        {
            return Math.Abs(I_2n - I_n) / (Math.Pow(2, p) - 1);
        }

        static void Main(string[] args)
        {
            // Данные по варианту
            double a = 0.4;
            double b = 0.6;
            double epsilon = 0.0000000000000001;
            int FN_step = 5; 
            int LN_step = 17; 

            // Добавляем прослушиватель для вывода трассировки в консоль
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.AutoFlush = true;

            int n = 2; // Начальное количество отрезков
            double I_n = SimpsonIntegration(a, b, n);
            double I_2n = SimpsonIntegration(a, b, 2 * n);
            double error = RungeError(I_n, I_2n);
            int iteration = 1;

            // Трассировка: начало
            Trace.TraceInformation("Начало вычисления интеграла.");
            Trace.Indent();

            // Итерационный процесс с контролем точности по Рунге
            while (error > epsilon)
            {
                // Трассировка значений на каждой итерации
                Trace.WriteLine($"Итерация {iteration}: n = {n}, I_n = {I_n}, I_2n = {I_2n}, Погрешность = {error}");

                // Задание: вывод на конкретных шагах
                if (iteration == FN_step)
                {
                    Debug.WriteLine($"Значение интеграла на шаге FN ({FN_step}): {I_2n}");
                }
                if (iteration == LN_step)
                {
                    Trace.WriteLine($"Значение интеграла на шаге LN ({LN_step}): {I_2n}");
                }

                n *= 2;
                I_n = I_2n;
                I_2n = SimpsonIntegration(a, b, 2 * n);
                error = RungeError(I_n, I_2n);
                iteration++;
            }

            // Трассировка: завершение
            Trace.Unindent();
            Trace.TraceInformation($"Вычисления завершены на итерации {iteration - 1}.");
            Trace.TraceInformation($"Приближенное значение интеграла: {I_2n}");
            Trace.TraceInformation($"Оценка погрешности: {error}");

            // Финализация
            Console.WriteLine($"Результат: {I_2n}");
            Console.ReadKey();
        }
    }
}



