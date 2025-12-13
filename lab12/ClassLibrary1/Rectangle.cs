using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Rectangle : IArea
    {
        private readonly double _x1, _y1, _x2, _y2;

        public Rectangle(double x1, double y1, double x2, double y2)
        {
            _x1 = Math.Min(x1, x2);
            _y1 = Math.Max(y1, y2); // Ошибка: должно быть Math.Min/Max для правильного определения границ
            _x2 = Math.Max(x1, x2);
            _y2 = Math.Min(y1, y2);
        }

        public bool IsPointInArea(double x, double y)
        {
            // Ошибка: неправильные границы из-за ошибки в конструкторе
            return x >= _x1 && x <= _x2 && y >= _y1 && y <= _y2;
        }
    }

}
