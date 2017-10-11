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
        bool ourTurn = true;    //We go first
        bool Hit = false;
        DispatcherTimer attacking = new DispatcherTimer();
        Random rng = new Random();
        double wind = 0;
        //Custom message things
        CustomMessage custom = new CustomMessage();
        //Stuff for the map here
        BitmapImage TempIcon = new BitmapImage(new Uri("pack://application:,,,/PaintTank.png"));
        BitmapImage[] environment = new BitmapImage[]
        {
            new BitmapImage(new Uri("pack://application:,,,/1.png")),
            new BitmapImage(new Uri("pack://application:,,,/2.png")),
            new BitmapImage(new Uri("pack://application:,,,/3.png")),
            new BitmapImage(new Uri("pack://application:,,,/4.png")),
            new BitmapImage(new Uri("pack://application:,,,/5.png")),
            new BitmapImage(new Uri("pack://application:,,,/6.png")),
            new BitmapImage(new Uri("pack://application:,,,/7.png")),
            new BitmapImage(new Uri("pack://application:,,,/8.png")),
            new BitmapImage(new Uri("pack://application:,,,/9.png")),
            new BitmapImage(new Uri("pack://application:,,,/10.png")),
            new BitmapImage(new Uri("pack://application:,,,/11.png")),
            new BitmapImage(new Uri("pack://application:,,,/12.png")),
            new BitmapImage(new Uri("pack://application:,,,/13.png")),
            new BitmapImage(new Uri("pack://application:,,,/14.png")),
            new BitmapImage(new Uri("pack://application:,,,/15.png")),
            new BitmapImage(new Uri("pack://application:,,,/16.png"))
         
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
            profiles.LoadProfiles();
            time.Tick += Time_Tick;
            DeathDestructionBattlegroundDoom.Background = new ImageBrush(environment[0]);//Sets the background to be the morning image (1.png)
            time.Interval = TimeSpan.FromMinutes(1);//Might change this to be based on number of turns taken as opposed to time taken
            //If we use a turn counter instead, we can do a check to make sure that it is an odd number (our) turn our an even number (enemy's turn)
            time.IsEnabled = true;
            attacking.Interval = TimeSpan.FromMinutes(1);
            attacking.Tick += Attacking_Tick;
            attacking.IsEnabled = true;
            wind = rng.Next(-30, 30);
            if (wind > 0)  label.Content = $"Wind:  {wind}km East"; 
            else label.Content = $"Wind:  {-1 * wind}km West";  
                debugsHere();           //@D.E.B.U.G
            }

        //The idea is that the timer will check every minute whether it is the enemy's turn
        //If it is the enemy's turn, they will attack us.
        private void Attacking_Tick(object sender, EventArgs e)
        {
            if (!ourTurn)
            {
                /**-------------------------------IDEAS-------------------------------------------
                 * Do things here [will have to implement enemy class/system before I can do this]
                 * enemyTracer will be used to track the enemy's attacks on us
                 * If the enemyTracer turtle touches our tank, reduce our lives by 1
                 * If this reduces our live count to 0 or -1 (depending if we count from 0 or 1)
                 * then gameover, update the user's score (if required), and then show 
                 * the highscores
                 */
            }
        }

        //This method is used to initialize the turtles as well as set the colour of their brushes and hide them
        private Turtle initTurtle(Turtle x)
        {
            x = new Turtle(DeathDestructionBattlegroundDoom, Canvas.GetTop(shootingThing), Canvas.GetLeft(shootingThing));
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
            /*
             * Can have a save feature whereby if the user quits while playing, they can resume where the left off
             * will probably not have time to do this, but it is an idea
             * if we do implememt this it will be a limited feature 
             * (working only for the last person that quit midway through a game) 
             */
            //profiles.updateScore();
            //MessageBox.Show("Tanks for playing");//<-- 
            custom.txtReturn.Visibility = Visibility.Hidden;
            //custom.txtInputOutput.Visibility = Visibility.Hidden;
            //custom.btnSave.Visibility = Visibility.Hidden;
            custom.txtName.Text = "Thanks for playing.";
            custom.txtScore.Text = "Would you like to save your game?";
            custom.setter(true);
            custom.Show();
            
           
        }

        //This is to change the angle of the shot
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Tank.TurretUpdate((int)slider.Value, 70 ,205, tracer);
        }

        //This is to draw the tracer of the bullet (handles the shooting tings)
        private void FireBtn_Click(object sender, RoutedEventArgs e)
        {
            Bullet.UpdateBullet(tracer, 100, label, wind,rng);
        }
    }
}
