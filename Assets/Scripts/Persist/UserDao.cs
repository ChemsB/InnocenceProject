using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Persist
{
    public class UserDao
    {
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
            //string name, string nick, bool endGame, float score
            listWithUsers = new List<Player>();
            Player user1 = new Player("Alex","Alexioe",false,0.0f,"1234");
            Player user2 = new Player("Martin","MrRitman",true,2500.0f,"1111");
            Player user3 = new Player("Chems","Chems20",false,0.0f,"test");
            Player user4 = new Player("Paula","Pauloma",true,600.0f,"4321");

            listWithUsers.Add(user1);
            listWithUsers.Add(user2);
            listWithUsers.Add(user3);
            listWithUsers.Add(user4);

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
            foreach (Player player in listWithUsers)
            {
                if(player.Password.Equals(password) && player.Nick.Equals(nick))
                {
                    res = true;
                }
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
            foreach (Player player in listWithUsers)
            {
                if (player.Nick.Equals(nickToCheck))
                {
                    res = true;
                }
            }
            return res;
        }


        /// <summary>
        /// Add new user in a list
        /// </summary>
        /// <param name="player">player to add</param>
        /// <returns>true if is added</returns>
        public bool addNewPlayer(Player player)
        {
            bool res = true;
            listWithUsers.Add(player);
            return res;
        }

        /// <summary>
        /// Find user by nick
        /// </summary>
        /// <param name="nick">nick to find</param>
        /// <returns>user data or null in case of error</returns>
        private Player findUserByNick(string nick)
        {
            Player player = null;

            foreach (Player playerInList in listWithUsers)
            {
                if (playerInList.Nick.Equals(nick))
                {
                    player = playerInList;
                }
            }

            return player;
        }

        //Accessors
        public List<Player> ListWithUsers { get => listWithUsers; set => listWithUsers = value; }

    }
}
