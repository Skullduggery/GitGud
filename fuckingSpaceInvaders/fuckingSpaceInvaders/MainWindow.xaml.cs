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
        Turtle enemyTracer;
        //Stuff for the map here
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
            tracer = initTurtle(tracer);
            enemyTracer = initTurtle(enemyTracer);
            //Jesus please find the exact location of the barrel of the gun and keep it there. 
            profiles.LoadProfiles();
            time.Tick += Time_Tick;
            DeathDestructionBattlegroundDoom.Background = new ImageBrush(environment[0]);//Sets the background to be the morning image (1.png)
            time.Interval = TimeSpan.FromMinutes(1);//Might change this to be based on number of turns taken as opposed to time taken
            time.IsEnabled = true;
            debugsHere();           //@D.E.B.U.G
        }

        //This method is used to initialize the turtles as well as set the colour of their brushes and hide them
        private Turtle initTurtle(Turtle x)
        {
            x = new Turtle(DeathDestructionBattlegroundDoom);
            x.Visible = false;
            x.LineBrush = Brushes.Red;
            return x;
        }

        private void debugsHere()//Some debugging stuff here
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

        //This will change the picture so that our game has a day/night system
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
            DeathDestructionBattlegroundDoom.Background = new ImageBrush(environment[current]);
        }


        //Our punful message that displays when the user exits the game
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$STAPLETON DO THIS$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

            //Make this message box look FABULOUS
            //Nice icon and stuff too
            MessageBox.Show("Tanks for playing");//<--  
        }
    }
}
