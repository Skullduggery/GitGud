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
        ScoreThings profiles = new ScoreThings();
           
        //MainWindow main = new MainWindow();
        public CustomMessage()
        {
            InitializeComponent();
            profiles.LoadProfiles();
            txtName.Visibility = Visibility.Hidden;
            txtScore.Visibility = Visibility.Hidden;
            txtReturn.Visibility = Visibility.Visible;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            

           
                Application.Current.Shutdown();

         
            



        }

        public void setter(bool thing)
        {
            closing = thing;
        }

    

        public void add(string name)
        {
            
            ScoreThings score = new ScoreThings();
            bool check = score.checkProfiles(name);

            if (!check)
            {
                profiles.addUser(txtReturn.Text);
                // name is not yet in the data base, add it.
                // User the writer to add the name and the 

            }else
            {
                // name is in the data base, YES/NO buttons
                profiles.checkProfiles(txtReturn.Text);
            }
                

        }


        public void display()
        {
            //txtReturn.Visibility = Visibility.Hidden;
            txtName.Visibility = Visibility.Visible;
            txtScore.Visibility = Visibility.Visible;
            var list = profiles.SortedList();
            
            txtScore.Text = "";
            txtName.Text = "";
            string name = "", scores = "";
            int cnt = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (cnt == 10) break;
                 name += ""+ (i+1) +". "+ list[i].Key+ "\n";
                 scores += "" + list[i].Value + "\n";
                cnt++;
            }
            txtName.Text = name;
            txtScore.Text = scores;
            //MessageBox.Show(name);
        }

      

        private void txtReturn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtReturn.Text = null;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
