using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Square : IArea
    {
        private readonly double _left, _top, _right, _bottom;

        public Square(double left, double top, double right, double bottom)
        {
            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;
        }

        public bool IsPointInArea(double x, double y)
        {
            return x >= _left && x <= _right && y >= _bottom && y <= _top;
        }
    }

}
