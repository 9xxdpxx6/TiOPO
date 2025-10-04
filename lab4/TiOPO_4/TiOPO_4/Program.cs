using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiOPO_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            var tests = new StringMergerTests();

            // Запуск всех тестов
            tests.TestBothEmpty();
            tests.TestFirstEmpty();
            tests.TestSecondEmpty();
            tests.TestEqualLength();
            tests.TestFirstLonger();
            tests.TestSecondLonger();
            tests.TestWithNull();

            // Демонстрация работы метода
            Console.WriteLine("\nДемонстрация работы метода:");
            var merger = new StringMerger();

            string[] testCases = {
                "Строка1: 'abc', Строка2: '123'",
                "Строка1: 'hello', Строка2: 'WORLD'",
                "Строка1: 'короткая', Строка2: 'длиннаястрока'",
                "Строка1: 'длиннаяперваястрока', Строка2: 'кор'"
            };

            string[][] testData = {
                new[] { "abc", "123" },
                new[] { "hello", "WORLD" },
                new[] { "короткая", "длиннаястрока" },
                new[] { "длиннаяперваястрока", "кор" }
            };

            for (int i = 0; i < testData.Length; i++)
            {
                string result = merger.MergeStrings(testData[i][0], testData[i][1]);
                Console.WriteLine($"{testCases[i]} -> Результат: '{result}'");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
