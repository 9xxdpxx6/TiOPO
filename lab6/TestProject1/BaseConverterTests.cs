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
        Assert.AreEqual("0", _converter.Convert1("0"));
    }

    [Test]
    public void Convert_One_ReturnsOne()
    {
        // Тестирование преобразования единицы
        Assert.AreEqual("1", _converter.Convert1("1"));
    }

    [Test]
    public void Convert_BasicNumbers_ReturnsCorrectBinary()
    {
        // Тестирование преобразования простых чисел
        Assert.AreEqual("10", _converter.Convert1("2"));
        Assert.AreEqual("101", _converter.Convert1("5"));
        Assert.AreEqual("1010", _converter.Convert1("10"));
        Assert.AreEqual("1111", _converter.Convert1("15"));
    }

    [Test]
    public void Convert_PowersOfTwo_ReturnsCorrectBinary()
    {
        // Тестирование чисел, являющихся степенями двойки
        Assert.AreEqual("1000", _converter.Convert1("8"));
        Assert.AreEqual("10000", _converter.Convert1("16"));
        Assert.AreEqual("10000000000", _converter.Convert1("1024"));
    }

    [Test]
    public void Convert_LargeNumbers_ReturnsCorrectBinary()
    {
        // Тестирование больших чисел
        Assert.AreEqual("11111111", _converter.Convert1("255"));
        Assert.AreEqual("1111111111", _converter.Convert1("1023"));
    }
}