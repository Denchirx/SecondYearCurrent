using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DemPrepare.GlobalVar;

namespace DemPrepare
{
    public class Figure
    {
        Point coord;
        int size;
        int vertexNum;
        float offset;

        public Figure(Point coord, int vertexNum, int size = 100)
        {
            this.coord = coord;
            this.size = size;
            this.vertexNum = vertexNum;
            this.offset = vertexNum == 4 ? (float)(Math.PI / 4) : (float)(-Math.PI / 2);
        }

        public void Show(Graphics g)
        {
            g.FillPolygon(Brushes.Red, GetVertexes());
        }

        Point[] GetVertexes()
        {
            Point[] myPoints = new Point[vertexNum];

            float step = (float)(2 * Math.PI / vertexNum);

            for (int i = 0; i < vertexNum; i++)
            {
                myPoints[i] = new Point((int)(size * Math.Cos(step * i + offset)), 
                    (int)(size * Math.Sin(step * i + offset)));
                myPoints[i].Offset(coord);
            }

            return myPoints;
        }

        public void SetSize(int s)
        {
            size = s;
        }
    }
}
