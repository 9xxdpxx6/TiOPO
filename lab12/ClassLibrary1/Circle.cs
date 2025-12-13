using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Circle : IArea
    {
        private readonly double _radius;
        private readonly double _centerX;
        private readonly double _centerY;

        public Circle(double radius, double centerX, double centerY)
        {
            _radius = radius;
            _centerX = centerX;
            _centerY = centerY;
        }

        public bool IsPointInArea(double x, double y)
        {
            double distanceSquared = Math.Pow(x - _centerX, 2) + Math.Pow(y - _centerY, 2);
            return distanceSquared <= Math.Pow(_radius, 2);
        }
    }

}
