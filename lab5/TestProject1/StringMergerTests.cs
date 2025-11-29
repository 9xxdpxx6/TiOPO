using NUnit.Framework;
using TiOPO_5;

namespace Tests
{
    [TestFixture]
    public class StringMergerTests
    {
        private StringMerger merger;

        [SetUp]
        public void Setup()
        {
            merger = new StringMerger();
        }

        // Тесты покрывают все ветви: цикл основного слияния, остатки строк, null, разные длины

        [Test]
        public void MergeStrings_BothNormal_EqualLength()
        {
            string result = merger.MergeStrings("ABC", "123");
            Assert.AreEqual("A1B2C3", result);
        }

        [Test]
        public void MergeStrings_FirstLonger()
        {
            string result = merger.MergeStrings("ABCDE", "12");
            Assert.AreEqual("A1B2CDE", result);
        }

        [Test]
        public void MergeStrings_SecondLonger()
        {
            string result = merger.MergeStrings("AB", "12345");
            Assert.AreEqual("A1B2345", result);
        }

        [Test]
        public void MergeStrings_FirstNull()
        {
            string result = merger.MergeStrings(null, "123");
            Assert.AreEqual("123", result);
        }

        [Test]
        public void MergeStrings_SecondNull()
        {
            string result = merger.MergeStrings("ABC", null);
            Assert.AreEqual("ABC", result);
        }

        [Test]
        public void MergeStrings_BothNull()
        {
            string result = merger.MergeStrings(null, null);
            Assert.AreEqual("", result);
        }

        [Test]
        public void MergeStrings_OneEmpty()
        {
            string result = merger.MergeStrings("", "123");
            Assert.AreEqual("123", result);
        }

        [Test]
        public void MergeStrings_OtherEmpty()
        {
            string result = merger.MergeStrings("ABC", "");
            Assert.AreEqual("ABC", result);
        }
    }
}
