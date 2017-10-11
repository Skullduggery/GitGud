using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace fuckingSpaceInvaders
{
    
    class Enemy:Tank //it might not inherit, don't know yet... 
    {
        Point[] positions = new Point[]
        {
            new Point(592,164),
            new Point(661,164),
            new Point(385,114)
        };
        int current = 0;

        //Enemies suck, so they only have one health
        public void move(Image enemy, Image explosion)
        {
            if (current + 1 < positions.Length)
            {
                current++;
            }
            else
            {
                current = 0;
            }
            double x = positions[current].X;
            double y = positions[current].Y;
            Canvas.SetLeft(enemy, x);
            Canvas.SetTop(enemy, y);
            Canvas.SetLeft(explosion, x -100);
            Canvas.SetTop(explosion, y -100);
        }
    }
}