using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CppSecYear.GlobalVar;

namespace CppSecYear
{
    class Game
    {
        PictureBox field;

        Bitmap frame;
        Graphics g;

        int fieldDrawSize => Math.Min(width, height);
        Point fieldCoord => width > height 
            ? new Point((width - fieldDrawSize) / 2, 0) 
            : new Point(0, (height - fieldDrawSize) / 2);

        public Game(PictureBox pb)
        {
            field = pb;
            width = field.Width;
            height = field.Height;
            frame = new Bitmap(width, height);
            g = Graphics.FromImage(frame);
        }

        public void setNewFrame()
        {
            g.Clear(Color.White);

            g.DrawLine(fieldPen,
                fieldDrawSize / 3 + fieldCoord.X,
                0 + fieldCoord.Y,
                fieldDrawSize / 3 + fieldCoord.X,
                fieldDrawSize + fieldCoord.Y);
            g.DrawLine(fieldPen,
                fieldDrawSize * 2 / 3 + fieldCoord.X,
                0 + fieldCoord.Y,
                fieldDrawSize * 2 / 3 + fieldCoord.X,
                fieldDrawSize + fieldCoord.Y);

            g.DrawLine(fieldPen,
                0 + fieldCoord.X,
                fieldDrawSize / 3 + fieldCoord.Y,
                fieldDrawSize + fieldCoord.X,
                fieldDrawSize / 3 + fieldCoord.Y);
            g.DrawLine(fieldPen,
                0 + fieldCoord.X,
                fieldDrawSize * 2 / 3 + fieldCoord.Y,
                fieldDrawSize+ fieldCoord.X,
                fieldDrawSize * 2 / 3 + fieldCoord.Y );

            field.Image = frame;
        }


        public void Click(Point clickCoord)
        {
            whichTurn = whichTurn == PlayerTurns.XPlayer ? PlayerTurns.OPlayer : PlayerTurns.XPlayer;
        }
    }
}
