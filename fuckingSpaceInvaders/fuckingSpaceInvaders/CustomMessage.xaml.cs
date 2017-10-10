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
using System.Windows.Shapes;
using System.IO;

namespace fuckingSpaceInvaders
{
    /// <summary>
    /// Interaction logic for CustomMessage.xaml
    /// </summary>
    public partial class CustomMessage : Window
    {
        public bool closing;
        
        //MainWindow main = new MainWindow();
        public CustomMessage()
        {
            InitializeComponent();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ScoreThings score = new ScoreThings();

            if (closing)
                Application.Current.Shutdown();

          /*  if (btnClose.Content == "No")
                score.answer = false;
            */
            



        }

        public void setter(bool thing)
        {
            closing = thing;
        }

        

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ScoreThings score = new ScoreThings();
            //string name = txtReturn.Text;
            //if (name == null)
            //{
            //    MessageBox.Show("Please enter a name that is valid");
            //    txtReturn.Text = "Enter name here";
            //}
            //else
            //{
            //    add(name);
            //    score.answer = true;
            //}

            score.ShowHighScores();
        }

        public void add(string name)
        {
            string passing;
            ScoreThings score = new ScoreThings();
            bool check = score.checkProfiles(name);

            if (!check)
            {

            }else
            {
                btnSave.IsEnabled = false;
            }
                

        }


        private void save()
        {
            ScoreThings score = new ScoreThings();
          //  score.WriteTings();
          //Check that all is write before adding to the file
        }

      

        private void txtReturn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtReturn.Text = null;
        }
    }
}
