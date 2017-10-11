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
       public static void  UpdateBullet(Turtle Bull, int p) // p == power
        {
            Color k = Bull.ColorUnderTurtle;



            while (k.ToString() == "#FF3F61FE" || k.ToString() == "#FFFFFFFF" || k.ToString() == "#FF000000" || k.ToString() == "#FF00A2E8" || k.ToString() == "#FF121214" || k.ToString() == "#FF12121E" || k.ToString() == "#FF121232") //Checking the bullet is in the air
            {
                k = Bull.ColorUnderTurtle;
                if (Bull.Heading < 90 || (Bull.Heading > 180))
                {
                    Bull.Forward(p / 10);
                    Bull.Heading += 2;
                }
                else
                {
                    Bull.Forward(p / 10);
                }
            }
                
                
            }
              
            

             
        
    }
}
