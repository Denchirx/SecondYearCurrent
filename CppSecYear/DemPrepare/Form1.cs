using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static DemPrepare.GlobalVar;

namespace DemPrepare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap b1 = new Bitmap(200, 200);
            Graphics g1 = Graphics.FromImage(b1);
            Figure f = new Figure(new Point(100, 100), 3);
            f.Show(g1);
            pictureBox1.Image = b1;

            Bitmap b2 = new Bitmap(200, 200);
            Graphics g2 = Graphics.FromImage(b2);
            f = new Figure(new Point(100, 100), 4);
            f.Show(g2);
            pictureBox2.Image = b2;

            Bitmap b3 = new Bitmap(200, 200);
            Graphics g3 = Graphics.FromImage(b3);
            f = new Figure(new Point(100, 100), 5);
            f.Show(g3);
            pictureBox3.Image = b3;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currMode == WhichFigure.triangle)
            {
                currMode = WhichFigure.empty;
            }
            else
            {
                currMode = WhichFigure.triangle;
            }
            this.Invalidate();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (currMode == WhichFigure.square)
            {
                currMode = WhichFigure.empty;
            }
            else
            {
                currMode = WhichFigure.square;
            }
            this.Invalidate();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (currMode == WhichFigure.pentagon)
            {
                currMode = WhichFigure.empty;
            }
            else
            {
                currMode = WhichFigure.pentagon;
            }
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 1; i <= 3; i++)
            {
                this.Controls["pictureBox" + i].BackColor = Color.White;
            }

            switch (currMode)
            {
                case WhichFigure.triangle:
                    pictureBox1.BackColor = Color.Green;
                    break;
                case WhichFigure.square:
                    pictureBox2.BackColor = Color.Green;
                    break;
                case WhichFigure.pentagon:
                    pictureBox3.BackColor = Color.Green;
                    break;
            }
        }
    }
}
