using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Player
    {

        private string name;
        private string nick;
        private bool endGame;
        private float score;
        private string password;


        //Constructors
        public Player()
        {
        }

        public Player(string name, string nick, bool endGame, float score, string password)
        {
            this.name = name;
            this.nick = nick;
            this.endGame = endGame;
            this.score = score;
            this.password = password;
        }

        //Accessors
        public string Name { get => name; set => name = value; }
        public string Nick { get => nick; set => nick = value; }
        public bool EndGame { get => endGame; set => endGame = value; }
        public float Score { get => score; set => score = value; }
        public string Password { get => password; set => password = value; }
    }
}
