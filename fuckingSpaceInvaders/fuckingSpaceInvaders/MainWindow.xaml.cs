using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ThinkLib;
using System.IO;

namespace fuckingSpaceInvaders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         * Use a dictionary to have profiles of user  <username and their highscore>
         * if currentScore > highScore, change that user's highScore in their profile [when they die or quit]
         * dictionary<string,int>
         * profiles saved to file
         * load these in at program start
         * if entered username does not exist, then add to the profiles (start with score of zero)
         * show highscores when death == true
         */

        //tank things here
        Turtle tracer;
        //Stuff for the map here
        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$Stapleton add the bitmap images here$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        //BitmapImage day = new BitmapImage(new Uri(""));
        //BitmapImage dusk = new BitmapImage(new Uri(""));
        //BitmapImage night = new BitmapImage(new Uri(""));
        DispatcherTimer time = new DispatcherTimer();
        //score things here
        ScoreThings profiles = new ScoreThings();
        bool Hit;
        public MainWindow()
        {
            
            InitializeComponent();
            tracer = new Turtle(DeathDestructionBattlegroundDoom);
            tracer.Visible = false;
            //Jesus please find the exact location of the barrel of the gun and keep it there. 
            //tracer must update to location of barrel of turret when user fires
            tracer.LineBrush = Brushes.DarkRed;
            profiles.LoadScores();//@Debug
            MessageBox.Show(profiles.ShowHighScores());//@Debug
            profiles.WriteTings();//@Debug

  
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$STAPLETON DO THIS$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

            //Make this message box look FABULOUS
            //Nice icon and stuff too
            MessageBox.Show("Tanks for playing");//<-- 
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
          //TurretUpdate used to be here I Broke it :(
        }

        private void FireBtn_Click(object sender, RoutedEventArgs e)
        {
            //BulletUpdate goes here
            if (tracer.Position.X > (Canvas.GetTop(tankThing)) && tracer.Position.Y > Canvas.GetLeft(tankThing)) 
            {
                Hit = true;
            }
        }
    }
}
