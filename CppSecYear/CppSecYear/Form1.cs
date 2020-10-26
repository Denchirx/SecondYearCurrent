using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static CppSecYear.GlobalVar;

namespace CppSecYear
{
    public partial class Form1 : Form
    {
        Game myGame;

        public Form1()
        {
            InitializeComponent();
            myGame = new Game(pictureBox1);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (whichTurn == PlayerTurns.XPlayer)
            {
                labelXTurn.BackColor = Color.LimeGreen;
                labelOTurn.BackColor = Color.Red;
            }
            else
            {
                labelXTurn.BackColor = Color.Red;
                labelOTurn.BackColor = Color.LimeGreen;
            }

            myGame.setNewFrame();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            myGame.Click(e.Location);
            this.Invalidate();
        }
    }
}
