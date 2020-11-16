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

        public GraphicsLayer(PictureBox pb)
        {
            this.pb = pb;
            b = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(b);
        }

        public void Click(MouseEventArgs e)
        {
            Figure f;
            switch (currMode)
            {
                case WhichFigure.triangle:
                    f = new Figure(new Point(100, 100), 3);
                    myFigures.Add(f);
                    break;
                case WhichFigure.square:
                    f = new Figure(new Point(100, 100), 4);
                    myFigures.Add(f);
                    break;
                case WhichFigure.pentagon:
                    f = new Figure(new Point(100, 100), 5);
                    myFigures.Add(f);
                    break;
            }
            currMode = WhichFigure.empty;
        }

        public void getNextFrame()
        {
            g.Clear(Color.White);


            pb.Image = b;
        }
    }
}
