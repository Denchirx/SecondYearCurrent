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
        enum TicTacToe { empty, cross, circle };

        TicTacToe[,] ticTacToes = new TicTacToe[3, 3];

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

            #region Drawing lines
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
                fieldDrawSize + fieldCoord.X,
                fieldDrawSize * 2 / 3 + fieldCoord.Y);
            #endregion

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Point figureCoord = 
                        new Point(fieldDrawSize * x / 3, fieldDrawSize  * y / 3);
                    figureCoord.Offset(fieldCoord);
                    DrawFigure(figureCoord, ticTacToes[x, y]); 
                }
            }

            field.Image = frame;
        }

        public void Click(Point clickCoord)
        {
            if (clickCoord.X < fieldCoord.X
                || clickCoord.Y < fieldCoord.Y
                || clickCoord.X > fieldCoord.X + fieldDrawSize
                || clickCoord.Y > fieldCoord.Y + fieldDrawSize)
            {
                return;
            }

            int[] cell = ClickToRowNColum(clickCoord);

            if (ticTacToes[cell[0], cell[1]] != TicTacToe.empty)
            {
                return;
            }

            if (whichTurn == PlayerTurns.XPlayer)
            {
                ticTacToes[cell[0], cell[1]] = TicTacToe.cross;
            }
            else
            {
                ticTacToes[cell[0], cell[1]] = TicTacToe.circle;
            }

            whichTurn =
                whichTurn == PlayerTurns.XPlayer
                ? PlayerTurns.OPlayer
                : PlayerTurns.XPlayer;

            field.Invalidate();
        }

        void DrawFigure(Point coord, TicTacToe ttt)
        {
            int size = fieldDrawSize / 3;
            if (ttt == TicTacToe.cross)
            {
                g.DrawLine(fieldPen, coord.X, coord.Y, coord.X + size, coord.Y + size);
                g.DrawLine(fieldPen, coord.X, coord.Y + size, coord.X + size, coord.Y);
            }
            else if (ttt == TicTacToe.circle)
            {
                g.DrawEllipse(fieldPen, coord.X, coord.Y, size, size);
            }

        }

        int[] ClickToRowNColum(Point coord)
        {
            int[] result = new int[2];

            result[0] = (coord.X - fieldCoord.X) / (fieldDrawSize / 3);
            result[1] = (coord.Y - fieldCoord.Y) / (fieldDrawSize / 3);

            return result;
        }
    }
}
