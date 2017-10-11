using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkLib;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;


namespace fuckingSpaceInvaders
{
    class Bullet
    {


        void BulletFire(Turtle Bull)
        {

        }
        public static void UpdateBullet(Turtle Bull, double p, Label txt, double wind, Random rng) // p == power
        {
            Color k = Bull.ColorUnderTurtle;
            wind = rng.Next(-30,30);
            if (wind > 0) txt.Content = $"Wind:  {wind}km East";
            else txt.Content = $"Wind:  {-1 * wind}km West";
            while (k.ToString() == "#FF3F61FE" || k.ToString() == "#FFFFFFFF" || k.ToString() == "#FF000000" || k.ToString() == "#FF00A2E8" || k.ToString() == "#FF121214" || k.ToString() == "#FF12121E" || k.ToString() == "#FF121232") //Checking the bullet is in the air)
            {//beautiful
                k = Bull.ColorUnderTurtle;
                if (Bull.Heading < 90 || (Bull.Heading > 180))
                {
                    Bull.Forward(p / 10);
                    Bull.Heading += 2;
                }
                else
                {
                    Bull.Forward(p / 10);
                    if (Bull.Position.X > 164 && Bull.Position.Y < 592)
                    {
                        
                        MessageBox.Show("HIT!");
                    }
                }
            }
                
                
            }
              
            

             
        
    }
}
