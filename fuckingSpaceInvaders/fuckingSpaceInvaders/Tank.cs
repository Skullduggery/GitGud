using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkLib;
using System.Windows;

namespace fuckingSpaceInvaders
{
    class Tank
    {
       public int Lives { get; private set; }
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
