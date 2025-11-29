using System;


public class BaseConverter
{
    private readonly int _fromBase;
    private readonly int _toBase;
    private const string Digits = "0123456789ABCDEF";

    public BaseConverter(int fromBase, int toBase)
    {
        if (fromBase < 2 || fromBase > 16 || toBase < 2 || toBase > 16)
        {
            throw new ArgumentOutOfRangeException("Основания должны быть в диапазоне от 2 до 16.");
        }
        _fromBase = fromBase;
        _toBase = toBase;
    }

    public string Convert1(string numberString)
    {
        if (string.IsNullOrEmpty(numberString))
        {
            throw new ArgumentException("Входная строка не может быть пустой.", nameof(numberString));
        }

        try
        {
            int decimalValue = Convert.ToInt32(numberString, _fromBase);

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
            throw new FormatException($"Некорректное число '{numberString}' для основания {_fromBase}.");
        }
    }
}