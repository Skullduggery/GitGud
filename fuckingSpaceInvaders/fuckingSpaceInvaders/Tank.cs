using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkLib;

namespace fuckingSpaceInvaders
{
    class Tank
    {
       public int Lives { get; private set; }
       public virtual void TurretUpdate(int x, Turtle Tur)
        {
            Tur.BrushDown = false;
            Tur.Goto(0, 0); //Replace With Tank coord
            Tur.Clear();
            Tur.Heading = x;
            Tur.BrushDown = true;
            Tur.Forward(5);
        }
    }
}
