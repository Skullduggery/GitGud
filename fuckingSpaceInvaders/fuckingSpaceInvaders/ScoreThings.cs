using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace fuckingSpaceInvaders
{
    class ScoreThings
    {
        private string path = "..\\..\\..\\Profiles.csv";
        //Make an icon for the main window (window that shows when you click "Start")
        public Dictionary<string, int> Profiles = new Dictionary<string, int>();
        public string Username { get; private set; }
        public int Score { get; set; } //need a way to increase thiscore...
        public bool answer = false;

        public ScoreThings()
        {        
            //this is an empty constructor, duh...
        }

        //Adjusts the score in the profile if the user 
      /*  public void updateScore()
        {
            int profileScore = Profiles[Username];
            if (Score > profileScore)
            {
                Profiles[Username] = Score;
                WriteTings();
            }
        }*/

        //This gets called 
        public void updateScore()
        {
            Score += 10;
        }

        //Used to check if current username is already in the list of profiles 
        public bool checkProfiles(string usr)
        {
            bool found = false;
            foreach(string x in Profiles.Keys)
            {
                if (x == usr)
                {
                    found = true;
                    Username = usr;
                    break;
                }
            }
            return found;
        }

        //Used to add user to profile if they do not exist already
        public void addUser(string usr)
        {
            //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$Stapleton$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            //Have a messageBox that returns a boolean [assign this to the Answer variable
            //This messageBox will read:  "This username already exists, would you like to use it"
            //Give the user a "yes" (true) and a "no" (false) option
          
            CustomMessage custom = new CustomMessage();
            
            custom.txtName.Visibility = Visibility.Hidden;
            custom.txtScore.Visibility = Visibility.Hidden;
            custom.btnSave.Content = "Yes";
            custom.btnClose.Content = "No";
            custom.Show();
            
           
            if (checkProfiles(usr) && !answer)
            {
                //if user already exists, but the answer to the messageBox quistion is "no" then ask them to enter a new username
                custom.btnSave.Content = "Add";
                
                custom.Show();
                Username = custom.txtReturn.Text;
               
                
            }

            if (!checkProfiles(usr))
            {
                Profiles[usr] = 0;
                Username = usr;
                Score = 0;
                WriteTings();
            }
        }

        //Writes changes to the scoreboard to file
        public void WriteTings()
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(path);
                foreach(string x in Profiles.Keys)
                {
                    string line = $"{x}, {Profiles[x]}";
                    sw.WriteLine(line);
                }
            }
            catch(IOException ex)
            {
                //make more specific catches/messages
                MessageBox.Show("An IO error occured\n\n" + ex.ToString());
            }
            finally
            {
                sw.Close();
            }
        }

        //Loads all the data from the profiles (to keep track of everyone's score)
        public void LoadProfiles()
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(path);
                string line = null;
                while ((line = sr.ReadLine()) != null)//Line example:  "User, 52"
                {
                    string[] values = line.Split(',');//"User", "52"
                    int score = Convert.ToInt32(values[1]);
                    Profiles[values[0]] = score;
                }
            }
            catch(FileNotFoundException)
            {
                File.Create(path);
            }
            catch (IOException ex)
            {
                //show specific error message here
                MessageBox.Show("An IO error occured\n\n" + ex.ToString());
            }finally
            {
                sr.Close();
            }
        }

        //Shows the top 10 scores (uses the SortedList method)
        public void ShowHighScores()
        {
            //string val = "";
            int cnt = 0;
            var myList = SortedList();
            string[] names = new string[9];//that be 10 items
            int[] scores = new int[9];
            for(int i = 0; i < myList.Count(); i++)
            {
                if (cnt == 10) break;
                //val += $"{cnt + 1}. {myList[i].Key}\t-\t{myList[i].Value}\n";
                names[i] = myList[i].Key;
                scores[i] = myList[i].Value;
                cnt++;
            }

            //return val;
        }

        //Returns the sorted values from Profiles.  These values will be used to show the top 10 profiles (based on score)
        public List<KeyValuePair<string, int>> SortedList()
        {
            //Code adapted from https://stackoverflow.com/questions/289/how-do-you-sort-a-dictionary-by-value
            int c = Profiles.Count();
            List<KeyValuePair<string,int>> myList = Profiles.ToList();
            for(int inner = 0; inner < c; inner++)
            {
                for(int outer = inner + 1; outer < c; outer++)
                {
                    if (myList.ElementAt(inner).Value < myList.ElementAt(outer).Value)//compares the values based on scores
                    {
                        var a = myList[inner];
                        myList[inner] = myList[outer];
                        myList[outer] = a;
                    }
                }//for [outer]
            }//for [inner]
            return myList;
        }
    }
}
