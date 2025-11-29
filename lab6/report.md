# Министерство науки и высшего образования Российской Федерации  
**Федеральное государственное бюджетное образовательное учреждение высшего образования**  
**«КУБАНСКИЙ ГОСУДАРСТВЕННЫЙ ТЕХНОЛОГИЧЕСКИЙ УНИВЕРСИТЕТ»**  
(ФГБОУ ВО «КубГТУ»)  

**Институт компьютерных систем и информационной безопасности**  
**Кафедра информационных систем и программирования**

---

## ЛАБОРАТОРНАЯ РАБОТА № 6

**Дисциплина:** Тестирование и отладка программного обеспечения  
**Работу выполнил:** А.А. Фролов  
**Направление подготовки:** 09.03.04 Программная инженерия  
**Преподаватель:** А. Г. Волик  


Краснодар  
2025

---


## Цель работы

Изучить подход к тестированию методом серого ящика.

## Задание

1.  Создать класс (в соответствии с вариантом задания из п.5), реализующий преобразование строки из двоичной системы в десятичную.
2.  Протестировать класс на основе метода серого ящика с использованием средств автоматизации.
3.  Составить отчет о результатах проведенного тестирования.

## Решение

### Код класса-преобразователя

```csharp
using System;

public class BaseConverter
{
    private readonly int _fromBase;
    private readonly int _toBase;
    private const string Digits = "0123456789ABCDEF";

    /// <summary>
    /// Инициализирует конвертер с исходным и целевым основаниями.
    /// </summary>
    /// <param name="fromBase">Исходное основание (2-16).</param>
    /// <param name="toBase">Целевое основание (2-16).</param>
    public BaseConverter(int fromBase, int toBase)
    {
        if (fromBase < 2 || fromBase > 16 || toBase < 2 || toBase > 16)
        {
            throw new ArgumentOutOfRangeException("Основания должны быть в диапазоне от 2 до 16.");
        }
        _fromBase = fromBase;
        _toBase = toBase;
    }

    /// <summary>
    /// Преобразует число из одной системы счисления в другую.
    /// </summary>
    /// <param name="numberString">Строка, представляющая число в исходной системе счисления.</param>
    /// <returns>Строка, представляющая число в целевой системе счисления.</returns>
    public string Convert(string numberString)
    {
        if (string.IsNullOrEmpty(numberString))
        {
            throw new ArgumentException("Входная строка не может быть пустой.", nameof(numberString));
        }

        try
        {
            // Шаг 1: Преобразуем входную строку в десятичное число.
            // Метод Convert.ToInt32 отлично справляется с этой задачей.
            int decimalValue = Convert.ToInt32(numberString, _fromBase);

            // Шаг 2: Преобразуем десятичное число в целевую систему счисления.
            if (decimalValue == 0)
            {
                return "0";
            }

            var result = "";
            while (decimalValue > 0)
            {
                int remainder = decimalValue % _toBase;
                result = Digits[remainder] + result;
                decimalValue /= _toBase;
            }

            return result;
        }
        catch (FormatException)
        {
            // Если формат входной строки не соответствует основанию
            throw new FormatException($"Некорректное число '{numberString}' для основания {_fromBase}.");
        }
    }
}
```

### Код тестов

```csharp
using NUnit.Framework;

[TestFixture]
public class DecimalToBinaryConverterTests
{
    private BaseConverter _converter;

    /// <summary>
    /// Метод SetUp выполняется перед каждым тестом.
    /// Здесь мы создаем экземпляр нашего конвертера для конкретного варианта.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        // Вариант: Преобразование из 10-й в 2-ю систему счисления
        _converter = new BaseConverter(10, 2);
    }

    [Test]
    public void Convert_Zero_ReturnsZero()
    {
        // Тестирование преобразования нуля
        Assert.AreEqual("0", _converter.Convert("0"));
    }

    [Test]
    public void Convert_One_ReturnsOne()
    {
        // Тестирование преобразования единицы
        Assert.AreEqual("1", _converter.Convert("1"));
    }

    [Test]
    public void Convert_BasicNumbers_ReturnsCorrectBinary()
    {
        // Тестирование преобразования простых чисел
        Assert.AreEqual("10", _converter.Convert("2"));
        Assert.AreEqual("101", _converter.Convert("5"));
        Assert.AreEqual("1010", _converter.Convert("10"));
        Assert.AreEqual("1111", _converter.Convert("15"));
    }

    [Test]
    public void Convert_PowersOfTwo_ReturnsCorrectBinary()
    {
        // Тестирование чисел, являющихся степенями двойки
        Assert.AreEqual("1000", _converter.Convert("8"));
        Assert.AreEqual("10000", _converter.Convert("16"));
        Assert.AreEqual("10000000000", _converter.Convert("1024"));
    }

    [Test]
    public void Convert_LargeNumbers_ReturnsCorrectBinary()
    {
        // Тестирование больших чисел
        Assert.AreEqual("11111111", _converter.Convert("255"));
        Assert.AreEqual("1111111111", _converter.Convert("1023"));
    }
}
```

Тесты покрывают следующие сценарии:
*   Преобразование нуля и единицы.
*   Преобразование стандартных чисел.
*   Преобразование чисел, являющихся степенями двойки.
*   Преобразование чисел с большим значением.

## Результаты тестирования

![Результат запуска тестов](img/1.png)

## Вывод

В ходе выполнения лабораторной работы был изучен подход к тестированию методом серого ящика.
