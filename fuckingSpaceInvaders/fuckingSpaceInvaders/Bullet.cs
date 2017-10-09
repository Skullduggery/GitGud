using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkLib;
using System.Windows.Media;
using System.Windows;

namespace fuckingSpaceInvaders
{
    class Bullet
    {
        void BulletFire(Turtle Bull)
        {

        }
        void UpdateBullet(Turtle Bull, int p) // p == power
        {
            Color k = Bull.ColorUnderTurtle;
            while(k.G < 1 && k.B < 1 && k.R <1 || k.B < 44) //Checking the bullet is in the air
            {
                while (Bull.Heading < 90 || (Bull.Heading > 180)  )
                {
                    Bull.Forward(p / 10);
                    Bull.Heading += 2;
                }
                Bull.Forward(p / 10);
            }
            

        }
    }
}
