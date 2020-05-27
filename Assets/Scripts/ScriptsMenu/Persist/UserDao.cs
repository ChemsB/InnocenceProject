using Assets.Scenes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
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

            try
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
            catch (Exception ex)
            {
                listWithUsers = null;
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
        /// <returns>true 0 exist user, 1 if not exist, 2 in case of server error</returns>
        internal int loginUser(string nick, string password)
        {
            int res;

            try
            {

                //Check with base64 if user is register for do http petitions
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:60300/api/TodoUsers");
                string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(nick + ":" + password));
                request.Headers.Add("Authorization", "Basic " + svcCredentials);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string jsonResponse = fixJson(reader.ReadToEnd());
                Player player = JsonUtility.FromJson<Player>(jsonResponse);
               

                if (player != null)
                {
                    res = 0;
                }
                else
                {
                    res = 1;
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message); 
                res = 2;
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
            int checkNick;

            checkNick = checkIfExistNick(newNick);

            if (checkNick==1)
            {
                /*HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://localhost:60300/api/TodoUsers/chems20/test?nick=tessssteo"));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string jsonResponse = fixJson(reader.ReadToEnd());

                Debug.Log(jsonResponse);*/

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
        /// <returns>0 if exist, 1 if not exist, 2 in case of error with server</returns>
        public int checkIfExistNick(string nickToCheck)
        {
            int res = 0;

            Player player = findUserByNick(nickToCheck);
            if (player == null)
            {
                res = 2;
            }
            else if(player != null && player.Id_videogame!=-1)
            {
                res = 0;
            }else if(player.Id_videogame == -1)
            {
                res = 1;
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

            string url= String.Format("http://localhost:60300/api/TodoUsers?name={0}&nick={1}&password={2}&id_videogame={3}", player.Name,player.Nick, player.password, player.id_videogame);

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
        /// <returns>user data or player with id videogame -1 if not exist, return null in case of server error</returns>
        private Player findUserByNick(string nick)
        {
            Player player = new Player();
            
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://localhost:60300/api/TodoUsers/{0}", nick));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string jsonResponse = fixJson(reader.ReadToEnd());

                player = JsonUtility.FromJson<Player>(jsonResponse);


            }
            catch (WebException ex)
            {

                HttpWebResponse errorResponse = ex.Response as HttpWebResponse;
                if (errorResponse!=null && errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
           
                    player.Id_videogame = -1;
                    return player;
                }
                else
                {
                    player = null;
                }

                
            }
            return player;

        }

        //Accessors
        public List<Player> ListWithUsers { get => listWithUsers; set => listWithUsers = value; }

    }
}
