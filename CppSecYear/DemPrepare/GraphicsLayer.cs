﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static DemPrepare.GlobalVar;

namespace DemPrepare
{
    class GraphicsLayer
    {
        Bitmap b;
        Graphics g;

        PictureBox pb;
        Point clickDownLoc = Point.Empty;

        public GraphicsLayer(PictureBox pb)
        {
            this.pb = pb;
            b = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(b);
        }

        public void ClickDown(MouseEventArgs e)
        {
            switch (currMode)
            {
                case WhichFigure.triangle:
                    currentFigure = new Figure(e.Location, 3);
                    break;
                case WhichFigure.square:
                    currentFigure = new Figure(e.Location, 4);
                    break;
                case WhichFigure.pentagon:
                    currentFigure = new Figure(e.Location, 5);
                    break;
                case WhichFigure.empty:
                    selectedFigure = FindClosestFigure(e.Location);
                    if (selectedFigure != null)
                    {
                        currMode = WhichFigure.selected;
                    }
                    break;
                case WhichFigure.selected:
                    selectedFigure = FindClosestFigure(e.Location);
                    break;
            }
            clickDownLoc = e.Location;
        }

        Figure FindClosestFigure(Point p)
        {
            Figure res = null;
            foreach (Figure f in myFigures)
            {
                if (f.Dist(p) < f.Size
                    && (res == null || f.Dist(p) < res.Dist(p)))
                {
                    res = f;
                }
            }
            return res;
        }

        public void ClickMove(MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (currMode == WhichFigure.selected)
                    {
                        selectedFigure.Coord = e.Location;
                    }
                    else
                    {
                        if (currentFigure != null)
                        {
                            int s = (int)Math.Sqrt(Math.Pow(
                                clickDownLoc.X - e.Location.X, 2)
                                + Math.Pow(clickDownLoc.Y - e.Location.Y, 2)
                                );
                            currentFigure.Size = s;
                        }
                    }
                    break;
                case MouseButtons.Right:
                    if (selectedFigure != null)
                    {
                        int turn = (e.Location.X - clickDownLoc.X);
                        selectedFigure.MakeTurn(turn);
                    }
                    break;

            }
        }

        public void ClickUp(MouseEventArgs e)
        {
            if (currentFigure != null)
            {
                myFigures.Add(currentFigure);
                currentFigure = null;
                currMode = WhichFigure.empty;
            }
        }

        public void getNextFrame()
        {
            g.Clear(Color.White);

            if (currentFigure != null)
            {
                currentFigure.Show(g);
            }

            foreach (Figure f in myFigures)
            {
                f.Show(g);
            }

            if (selectedFigure != null)
            {
                selectedFigure.ShowSelection(g);
            }

            pb.Image = b;
        }
    }
}
