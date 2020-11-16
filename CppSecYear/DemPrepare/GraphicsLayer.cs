using System;
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
            }
            currMode = WhichFigure.empty;
            clickDownLoc = e.Location;
        }

        public void ClickMove(MouseEventArgs e)
        { 

        }

        public void ClickUp(MouseEventArgs e)
        {
            if (currentFigure != null)
            { 
                myFigures.Add(currentFigure);
                currentFigure = null;
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

            pb.Image = b;
        }
    }
}
