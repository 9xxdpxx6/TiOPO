using System;

namespace TiOPO_3
{
    internal class Program
    {
        public static void Main()
        {
            PointChecker checker = new PointChecker();

            // Тесты для первой области (классы эквивалентности)
            Console.WriteLine("Тест 1ой области:\n");
            TestPoint(checker, 1, 0.5, 1);  // Внутри первой области
            TestPoint(checker, 0.25, 0.05, 1);  // Внутри первой области
            TestPoint(checker, 0.5, 0.5, 1); // На границе y=x
            TestPoint(checker, 0.501, 0.5, 1); // Чуть правее границы y=x
            TestPoint(checker, 1, 1, 1); // Точка пересечения
            TestPoint(checker, 1, 0.99, 1); // Чуть ниже точки пересечения
            TestPoint(checker, 1.3, 0, 1); // На границе по оси X
            TestPoint(checker, 0.5, 0.501, 0); // Выше границы y=x
            TestPoint(checker, 1.01, 1, 0); // Выше точки пересечения
            TestPoint(checker, 1.3, -0.001, 0); // Ниже границы по оси X 
            TestPoint(checker, 1.42, 0, 0); // Правее параболы
            TestPoint(checker, 0.5, 1, 0); // Вне области

            Console.WriteLine("Тест 2ой области:\n");
            TestPoint(checker, -1, -0.5, 2);  // Внутри второй области
            TestPoint(checker, -0.25, -0.05, 2);  // Внутри второй области
            TestPoint(checker, -0.5, -0.5, 2); // На границе y=x
            TestPoint(checker, -0.501, -0.5, 2); // Чуть левее границы y=x
            TestPoint(checker, -2, -2, 2); // Точка пересечения
            TestPoint(checker, -1.99999, -1.99999, 2); // Чуть выше точки пересечения
            TestPoint(checker, -1.3, 0, 2); // На границе по оси X
            TestPoint(checker, -0.5, -0.501, 0); // Ниже границы y=x
            TestPoint(checker, -2, -2.001, 0); // Выше точки пересечения
            TestPoint(checker, -1.3, 0.001, 0); // Выше границы по оси X 
            TestPoint(checker, -1.42, 0, 0); // Правее параболы
            TestPoint(checker, -1, -3, 0); // Вне области
            TestPoint(checker, Math.Sqrt(2), 0, 1);   // Пересечение параболы с осью X (правая часть)
            TestPoint(checker, -Math.Sqrt(2), 0, 2);  // Пересечение параболы с осью X (левая часть)
            TestPoint(checker, 1, 1, 1);              // На линии y=x внутри параболы

            Console.WriteLine("Тестирование завершено.");
        }

        private static void TestPoint(PointChecker checker, double x, double y, int expectedRegion)
        {
            int actualRegion = checker.TestPoint(x, y);
            if (actualRegion == expectedRegion)
            {
                Console.WriteLine($"Точка ({x}, {y}) - успешно прошла проверку. Ожидаемая область: {expectedRegion}");
            }
            else
            {
                Console.WriteLine($"Ошибка! Точка ({x}, {y}) должна быть в области {expectedRegion}, но попала в область {actualRegion}.");
            }
        }
    }

    public class PointChecker
    {
        public int TestPoint(double x, double y)
        {
            double Y = -(x * x) + 2;

            // Проверка, попадает ли точка в первую область
            if (y >= 0 && y <= x && y <= Y)
                return 1; // Первая область

            // Проверка, попадает ли точка во вторую область
            if (y <= 0 && y >= x && y <= Y)
                return 2; // Вторая область

            return 0;
        }
    }
}