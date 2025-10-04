using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiOPO_4
{
    public class StringMerger
    {

        /// <summary>
        /// Сливает две строки посимвольно
        /// </summary>
        /// <param name="str1">Первая строка</param>
        /// <param name="str2">Вторая строка</param>
        /// <returns>Результат посимвольного слияния</returns>
        public string MergeStrings(string str1, string str2)
        {
            // Блок 1: Инициализация
            StringBuilder result = new StringBuilder();
            int i = 0;
            int length1 = str1?.Length ?? 0;
            int length2 = str2?.Length ?? 0;

            // Блок 2: Основной цикл слияния
            while (i < length1 && i < length2)  // Условие 1
            {
                // Блок 3: Добавление символов из обеих строк
                if (str1 != null && i < str1.Length)
                    result.Append(str1[i]);

                if (str2 != null && i < str2.Length)
                    result.Append(str2[i]);

                i++;  // Блок 4: Инкремент счетчика
            }

            // Блок 5: Добавление остатка первой строки
            while (i < length1)  // Условие 2
            {
                if (str1 != null && i < str1.Length)
                    result.Append(str1[i]);
                i++;
            }

            // Блок 6: Добавление остатка второй строки
            while (i < length2)  // Условие 3
            {
                if (str2 != null && i < str2.Length)
                    result.Append(str2[i]);
                i++;
            }

            // Блок 7: Возврат результата
            return result.ToString();
        }
    }
}
