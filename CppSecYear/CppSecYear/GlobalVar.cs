using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CppSecYear
{ 
    public enum PlayerTurns { XPlayer, OPlayer };
    
    public static class GlobalVar
    {
        public static PlayerTurns whichTurn = PlayerTurns.XPlayer;
        
        public static Pen fieldPen = new Pen(Color.Black, 10);
        public static int width = 0;
        public static int height = 0;
    }
}
