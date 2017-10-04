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

/// <summary>
/// Important stuff to note here...
/// How we coded up the logic for a simple state machine with three states.
/// 
/// The  Model/View/Controller parts of the program are separated 
///            from each other.
///            
///     The Timer is the Controller and generates the events.  
///         It could also be a button click, etc.
///         
///     The Model of how the lights work internally is our state machine.
///     The View shows what is happening in the model. 
/// </summary>
namespace TrafficLights
{
    public partial class TrafficLightsMainWindow : Window
    {
        // define the global timer variable
        private int currentState;
        private BitmapImage[] theTrafficPics, thePedstrianPics;

        // Timer declare
        private DispatcherTimer theTimer;

        // bool for pedestrian button
        private bool isPressed;

        // Pack declare
        private string inThisProject = "pack://application:,,,/";
        
        public TrafficLightsMainWindow()
        {
            InitializeComponent();

            // Timer setup
            theTimer = new DispatcherTimer();
            theTimer.Interval = TimeSpan.FromMilliseconds(5000); // the controller will 'sample' after every 5 seconds
            theTimer.IsEnabled = true;
            theTimer.Tick += dispatcherTimer_Tick;

            // Image array setup
            theTrafficPics = new BitmapImage[] {
                        new BitmapImage(new Uri(inThisProject + "TrafficLightGreen.png")),
                        new BitmapImage(new Uri(inThisProject + "TrafficLightAmber.png")),
                        new BitmapImage(new Uri(inThisProject + "TrafficLightRed.png")) };

            thePedstrianPics = new BitmapImage[] {
                        new BitmapImage(new Uri(inThisProject + "do_not_cross.png")),
                        new BitmapImage(new Uri(inThisProject + "wait.png")),
                        new BitmapImage(new Uri(inThisProject + "cross_now.png")) };

            // State and event variables
            isPressed = false;
            currentState = 0;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // invoke the controller
            checkPressedController();

            // update the views
            updateView();
        }

        private void updateView()
        {
            // this method represents the implementation of the view as it displays all GUI related functions
            mainPic.Source = theTrafficPics[currentState];

            imgCross.Source = thePedstrianPics[currentState];
        }

        private void checkPressedController()
        {
            // the controller is split into two via the button  and the transition machine
            // this is because the crossing is pedestrian (user) controller rather than time controlled
            switch (isPressed)
            {
                case false:
                    if (currentState == 0) currentState = 0;
                    else if (currentState == 1) currentState = 2;
                    else if (currentState == 2) currentState = 0; isPressed = false; // reset so that it loops

                    break;

                case true:
                    if (currentState == 0) currentState = 1;
                    else if (currentState == 1) currentState = 2;
                    else if (currentState == 2) currentState = 0; isPressed = false; // reset so that it loops

                    break;

                default: break;
            }
        }

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // the controller is split into two via the button  and the transition machine
            // this is because the crossing is pedestrian (user) controller rather than time controlled
            // there are many ways to model this, one way is by togelling the state between presses to model
            // pressed and depressed
            isPressed = !isPressed;
        }
    }
}
