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
        float offOffSet = 0.0f;

        public Point Coord
        {
            get
            {
                return coord;
            }
            set
            {
                coord = value;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                if (value > 0)
                {
                    size = value;
                }
            }

        }

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
                myPoints[i] = new Point((int)(size * Math.Cos(step * i + offset + offOffSet)),
                    (int)(size * Math.Sin(step * i + offset + offOffSet)));
                myPoints[i].Offset(coord);
            }

            return myPoints;
        }


        public float Dist(Point p)
        {
            return (float)Math.Sqrt(Math.Pow(p.X - coord.X, 2) + Math.Pow(p.Y - coord.Y, 2));
        }

        public void ShowSelection(Graphics g)
        {
            Point[] pts = GetVertexes();
            switch (sm)
            {
                case SelectMode.points:                    
                    foreach (Point p in pts)
                    {
                        g.FillEllipse(Brushes.Black, p.X - 5, p.Y - 5, 10, 10);
                    }
                    break;
                case SelectMode.rec:
                    Point min = new Point(int.MaxValue, int.MaxValue), 
                        max = new Point(0, 0);
                    foreach (Point p in pts)
                    {
                        if (p.X <= min.X)
                        {
                            min.X = p.X;
                        }
                        if (p.Y <= min.Y)
                        {
                            min.Y = p.Y;
                        }
                        if (p.X >= max.X)
                        {
                            max.X = p.X;
                        }
                        if (p.Y >= max.Y)
                        {
                            max.Y = p.Y;
                        }
                    }
                    g.DrawRectangle(Pens.Black, min.X, min.Y, max.X - min.X, max.Y - min.Y);
                    break;
            }
        }

        public void MakeTurn(int turn)
        {
            float rad = (turn * (float)Math.PI) / 180;
            offOffSet = rad;
        }
    }
}
