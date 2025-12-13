using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// Определяет контракт для любой геометрической области.
    /// Любой класс, реализующий этот интерфейс, должен уметь определять,
    /// находится ли заданная точка (x, y) внутри этой области.
    /// </summary>
    public interface IArea
    {
        /// <summary>
        /// Проверяет, находится ли точка с координатами (x, y) внутри области.
        /// </summary>
        /// <param name="x">Координата X точки.</param>
        /// <param name="y">Координата Y точки.</param>
        /// <returns>True, если точка находится внутри области, иначе False.</returns>
        bool IsPointInArea(double x, double y);
    }
}
