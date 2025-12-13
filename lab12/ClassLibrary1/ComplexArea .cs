using System.Drawing;

namespace ClassLibrary1
{
    // Первая фигура: комбинированная область из круга и прямоугольника
    public class ComplexArea : IArea
    {
        private readonly Circle _circle;
        private readonly Rectangle _rectangle;

        public ComplexArea(double circleRadius, double circleCenterX, double circleCenterY,
                          double rectX1, double rectY1, double rectX2, double rectY2)
        {
            _circle = new Circle(circleRadius, circleCenterX, circleCenterY);
            _rectangle = new Rectangle(rectX1, rectY1, rectX2, rectY2);
        }

        public bool IsPointInArea(double x, double y)
        {
            // Ошибка: должно быть ИЛИ, а не И
            return _circle.IsPointInArea(x, y) && _rectangle.IsPointInArea(x, y);
        }
    }

}
