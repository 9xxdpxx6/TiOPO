using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // Вторая фигура: квадрат с вырезанными окружностями в углах
    public class SquareWithCircles : IArea
    {
        private readonly Square _square;
        private readonly Circle _topLeftCircle;
        private readonly Circle _bottomRightCircle;

        public SquareWithCircles(double squareSide, double squareCenterX, double squareCenterY)
        {
            double halfSide = squareSide / 2;

            // Квадрат
            _square = new Square(squareCenterX - halfSide, squareCenterY + halfSide,
                               squareCenterX + halfSide, squareCenterY - halfSide);

            // Ошибка: радиус должен быть halfSide, но установлен неправильно
            double circleRadius = squareSide; // Должно быть halfSide

            // Центры окружностей в углах квадрата
            _topLeftCircle = new Circle(circleRadius, squareCenterX - halfSide, squareCenterY + halfSide);
            _bottomRightCircle = new Circle(circleRadius, squareCenterX + halfSide, squareCenterY - halfSide);
        }

        public bool IsPointInArea(double x, double y)
        {
            // Ошибка: неправильная логика - должно быть в квадрате И НЕ в окружностях
            return _square.IsPointInArea(x, y) ||
                   !_topLeftCircle.IsPointInArea(x, y) &&
                   !_bottomRightCircle.IsPointInArea(x, y);
        }
    }

}
