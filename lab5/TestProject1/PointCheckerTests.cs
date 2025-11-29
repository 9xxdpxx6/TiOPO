using NUnit.Framework;
using TiOPO_5;

namespace Tests
{
    [TestFixture]
    public class PointCheckerTests
    {
        private PointChecker checker;

        [SetUp]
        public void Setup()
        {
            checker = new PointChecker();
        }

        public static object[] PointTestCases =
        {
            new object[] { 0.5, 0.6, 0 },
            new object[] { 1, 0, 1 },
            new object[] { -1, 0, 2 },
            new object[] { 1, -0.5, 0 }, // исправлено
            new object[] { 1, 1, 1 },
        };


        [Test, TestCaseSource(nameof(PointTestCases))]
        public void TestPoint_ReturnsCorrectRegion(double x, double y, int expected)
        {
            int result = checker.TestPoint(x, y);
            Assert.AreEqual(expected, result);
        }
    }
}
