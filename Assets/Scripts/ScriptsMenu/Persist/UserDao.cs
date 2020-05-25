using Assets.Scenes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

//class that manages user data

namespace Assets.Scripts.Persist
{

    public class UserDao
    {

        private string serverUrl = "http://localhost:60300/api/TodoUsers";
        
        private readonly static UserDao userDao = new UserDao();
        List<Player> listWithUsers;

        //Constructor singleton pattern
        private UserDao()
        {
            loadTestData();
        }


        public static UserDao Instance
        {
            get
            {
                return userDao;
            }
        }


        /// <summary>
        /// Load user list with test data
        /// </summary>
        private void loadTestData()
        {
            listWithUsers = new List<Player>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(serverUrl));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = fixJson(reader.ReadToEnd());


            Player[] players = JsonHelper.FromJson<Player>(jsonResponse);


            for (int i = 0; i < players.Length; i++)
            {
                listWithUsers.Add(players[i]);
            }

        }


        /// <summary>
        /// Change format to json values
        /// </summary>
        /// <param name="value">string in json format</param>
        /// <returns>sring with correct sintax for serialization</returns>
        string fixJson(string value)
        {
            value = "{\"Items\":" + value + "}";
            return value;
        }

        /// <summary>
        /// Check if exist user with nick and password
        /// </summary>
        /// <param name="nick">user nick to check</param>
        /// <param name="password">user password</param>
        /// <returns>true if exist user, false in case of error</returns>
        internal bool loginUser(string nick, string password)
        {
            bool res = false;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://localhost:60300/api/TodoUsers/{0}/{1}", nick, password));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = fixJson(reader.ReadToEnd());

            Player player = JsonUtility.FromJson<Player>(jsonResponse);

            if (player != null)
            {
                res = true;
            }
            else
            {
                res = false;
            }

            return res;
        }



            /// <summary>
            /// Change user nick
            /// </summary>
            /// <param name="oldNick">nick to change</param>
            /// <param name="newNick">new nick</param>
            /// <returns>true if is changed, false in case of error</returns>
            public bool changeNick(string oldNick, string newNick)
        {
            bool res = false;
            bool checkNick;

            checkNick = checkIfExistNick(newNick);

            if (!checkNick)
            {
                Player player = findUserByNick(oldNick);

                if (player != null)
                {
                    res = true;
                    player.Nick = newNick;
                }
            }
            return res;
        }


        /// <summary>
        /// Check nick is already exist
        /// </summary>
        /// <param name="nickToCheck">nick to check</param>
        /// <returns>true if exist, false if not exist</returns>
        public bool checkIfExistNick(string nickToCheck)
        {
            bool res = false;

            Player player = findUserByNick(nickToCheck);
            if (player == null)
            {
                res = false;
            }
            else
            {
                res = true;
            }

            return res;
        }


        /// <summary>
        /// Add new user in a list
        /// </summary>
        /// <param name="player">player to add</param>
        /// <returns>true if is added</returns>
        public IEnumerator addNewPlayer(Player player)
        {
            bool res = true;

            string url= String.Format("http://localhost:60300/api/TodoUsers?name={0}&nick={1}&password={2}&id_videogame={3}", player.Name,player.Nick,player.Password,player.id_videogame);

            WWWForm form = new WWWForm();
            UnityWebRequest uwr = UnityWebRequest.Post(url, form);
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                Debug.Log("Received: " + uwr.downloadHandler.text);
            }


        }

        /// <summary>
        /// Find user by nick
        /// </summary>
        /// <param name="nick">nick to find</param>
        /// <returns>user data or null in case of error</returns>
        private Player findUserByNick(string nick)
        {
            Player player = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://localhost:60300/api/TodoUsers/{0}", nick));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = fixJson(reader.ReadToEnd());

            player = JsonUtility.FromJson<Player>(jsonResponse);

            return player;
        }

        //Accessors
        public List<Player> ListWithUsers { get => listWithUsers; set => listWithUsers = value; }

    }
}
