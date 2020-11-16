using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemPrepare
{
    public enum WhichFigure { empty, triangle, square, pentagon };

    public static class GlobalVar
    {
        public static WhichFigure currMode = WhichFigure.empty;
        public static List<Figure> myFigures = new List<Figure>();
    }
}
