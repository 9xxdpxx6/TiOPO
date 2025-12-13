using System.Reflection.Emit;
using ClassLibrary1;

namespace TestProject2
{
    [TestClass]
    public class AreaTests
    {
        // Тесты для ComplexArea
        [TestMethod]
        public void ComplexArea_PointInCircleOnly_ShouldBeTrue()
        {
            // Точка только в круге (-3, 3)
            var area = new ComplexArea(5, -5, 0, 0, -5, 5, 0);
            Assert.IsTrue(area.IsPointInArea(-3, 3));
        }

        [TestMethod]
        public void ComplexArea_PointInRectangleOnly_ShouldBeTrue()
        {
            // Точка только в прямоугольнике (3, -3)
            var area = new ComplexArea(5, -5, 0, 0, -5, 5, 0);
            Assert.IsTrue(area.IsPointInArea(3, -3));
        }

        [TestMethod]
        public void ComplexArea_PointInBoth_ShouldBeTrue()
        {
            // Точка в обеих областях - такой нет, так как области не пересекаются
            var area = new ComplexArea(5, -5, 0, 0, -5, 5, 0);
            Assert.IsFalse(area.IsPointInArea(0, 0)); // Граничная точка
        }

        [TestMethod]
        public void ComplexArea_PointInNeither_ShouldBeFalse()
        {
            // Точка ни в одной области (-10, -10)
            var area = new ComplexArea(5, -5, 0, 0, -5, 5, 0);
            Assert.IsFalse(area.IsPointInArea(-10, -10));
        }

        // Тесты для SquareWithCircles
        [TestMethod]
        public void SquareWithCircles_PointInSquareNotInCircles_ShouldBeTrue()
        {
            // Точка в центре квадрата (0, 0) - не в окружностях
            var area = new SquareWithCircles(10, 0, 0);
            Assert.IsTrue(area.IsPointInArea(0, 0));
        }

        [TestMethod]
        public void SquareWithCircles_PointInTopLeftCircle_ShouldBeFalse()
        {
            // Точка в левой верхней окружности (-4, 4)
            var area = new SquareWithCircles(10, 0, 0);
            Assert.IsFalse(area.IsPointInArea(-4, 4));
        }

        [TestMethod]
        public void SquareWithCircles_PointInBottomRightCircle_ShouldBeFalse()
        {
            // Точка в правой нижней окружности (4, -4)
            var area = new SquareWithCircles(10, 0, 0);
            Assert.IsFalse(area.IsPointInArea(4, -4));
        }

        [TestMethod]
        public void SquareWithCircles_PointOutsideSquare_ShouldBeFalse()
        {
            // Точка вне квадрата (6, 6)
            var area = new SquareWithCircles(10, 0, 0);
            Assert.IsFalse(area.IsPointInArea(6, 6));
        }

        [TestMethod]
        public void SquareWithCircles_PointOnSquareBorder_ShouldBeTrue()
        {
            // Точка на границе квадрата, но не в окружностях (0, 5)
            var area = new SquareWithCircles(10, 0, 0);
            Assert.IsTrue(area.IsPointInArea(0, 5));
        }

        // Тесты для отдельных фигур
        [TestMethod]
        public void Circle_PointInside_ShouldBeTrue()
        {
            var circle = new Circle(5, 0, 0);
            Assert.IsTrue(circle.IsPointInArea(3, 3));
        }

        [TestMethod]
        public void Circle_PointOutside_ShouldBeFalse()
        {
            var circle = new Circle(5, 0, 0);
            Assert.IsFalse(circle.IsPointInArea(6, 6));
        }

        [TestMethod]
        public void Rectangle_PointInside_ShouldBeTrue()
        {
            var rect = new Rectangle(0, 5, 5, 0);
            Assert.IsTrue(rect.IsPointInArea(3, 3));
        }

        [TestMethod]
        public void Rectangle_PointOutside_ShouldBeFalse()
        {
            var rect = new Rectangle(0, 5, 5, 0);
            Assert.IsFalse(rect.IsPointInArea(6, 3));
        }

        [TestMethod]
        public void Square_PointInside_ShouldBeTrue()
        {
            var square = new Square(-5, 5, 5, -5);
            Assert.IsTrue(square.IsPointInArea(0, 0));
        }

        [TestMethod]
        public void Square_PointOutside_ShouldBeFalse()
        {
            var square = new Square(-5, 5, 5, -5);
            Assert.IsFalse(square.IsPointInArea(6, 6));
        }
    }

}