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
        public Dictionary<string, int> Profiles = new Dictionary<string, int>();
        public string Username { get; private set; }
        public int Score { get; private set; }

        public ScoreThings()
        {
            //this is an empty constructor
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
            if (!checkProfiles(usr))
            {
                Profiles[usr] = 0;
            }
        }

        public void WriteTings(string path)
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
                //make more specific catches
            }finally
            {
                sw.Close();
            }
        }

        public void LoadScores(string path)
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
            }finally
            {
                sr.Close();
            }
        }

        public string ShowHighScores()
        {
            //Sort();    //need to make a sort method to sort the profiles
            string val = "";
            int cnt = 0;
            foreach(string x in Profiles.Keys)
            {
                if (cnt == 10) break;
                //format this nicely so that scores are in a nice neat column
                //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$Stapleton, do that column neatness thing here$$$$$$$$$$$$$$$$$$$$$$$$$
                val += $"{cnt + 1}. {x}\t-\t{Profiles[x]}\n";
                cnt++;
            }
            return val;
        }
    }
}
