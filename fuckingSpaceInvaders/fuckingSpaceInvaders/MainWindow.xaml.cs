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
        BitmapImage[] environment = new BitmapImage[]
        {
            new BitmapImage(new Uri("pack://application:,,,/1.png")),
            new BitmapImage(new Uri("pack://application:,,,/2.png")),
            new BitmapImage(new Uri("pack://application:,,,/3.png"))
        };
        int current = 0;
        DispatcherTimer time = new DispatcherTimer();
        //score things here
        ScoreThings profiles = new ScoreThings();
        
        public MainWindow()
        {
            InitializeComponent();
            tracer = new Turtle(DeathDestructionBattlegroundDoom);
            tracer.Visible = false;
            //Jesus please find the exact location of the barrel of the gun and keep it there. 
            //tracer must update to location of barrel of turret when user fires
            tracer.LineBrush = Brushes.DarkRed;
            profiles.LoadProfiles();
            time.Tick += Time_Tick;
            Background.Source = environment[0];
            time.Interval = TimeSpan.FromMinutes(1);//Might change this to be based on number of turns taken as opposed to time taken
            time.IsEnabled = true;
            debugsHere();

        }

        private void debugsHere()
        {
            time.Interval = TimeSpan.FromSeconds(5);
            //MessageBox.Show(profiles.ShowHighScores());//@Debug
            //profiles.addUser("Will");//@debug
            //profiles.addUser("newPerson");
            //profiles.Score = 100;
            //profiles.updateScore();
            //profiles.Score = 100;//@debug
            //profiles.updateScore();//@debug
            //MessageBox.Show(profiles.ShowHighScores());//@debug
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            if (current + 1 < environment.Length)
            {
                current++;
            }
            else
            {
                current = 0;
            }
            Background.Source = environment[current];
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$STAPLETON DO THIS$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

            //Make this message box look FABULOUS
            //Nice icon and stuff too
            MessageBox.Show("Tanks for playing");//<-- 
        }
    }
}
