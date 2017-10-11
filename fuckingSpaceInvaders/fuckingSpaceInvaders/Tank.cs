using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkLib;
using System.Windows;
using System.Windows.Controls;

namespace fuckingSpaceInvaders
{
    class Tank
    {
        public int Lives = 100;

        public bool updateHP()
        {
            if (Lives - 1 == 0)
            {
                Lives--;
                return true;
            }
            else
            {
                Lives--;
                return false;
            }
        }
       public static void TurretUpdate(int h, double x, double y, Turtle Tur)
        {
            Tur.BrushDown = false;
            Tur.Goto(x,y); //Replace With Tank coord
            Tur.Clear();
            Tur.Heading = h;
            Tur.BrushDown = true;
            Tur.Forward(10);
        }
    }
}
