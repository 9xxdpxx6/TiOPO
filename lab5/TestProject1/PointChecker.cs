using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiOPO_5
{
    public class PointChecker
    {
        public int TestPoint(double x, double y)
        {
            double Y = -(x * x) + 2;

            // Проверка, попадает ли точка в первую область
            if (y >= 0 && y <= x && y <= Y)
                return 1; // Первая область

            // Проверка, попадает ли точка во вторую область
            if (y <= 0 && y >= x && y <= Y)
                return 2; // Вторая область

            return 0;
        }
    }
}
