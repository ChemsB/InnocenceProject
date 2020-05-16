using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class Player
    {

        private string name;
        private string nick;
        private bool endGame;


        public Player()
        {
        }

        public Player(string name, string nick, bool endGame)
        {
            this.name = name;
            this.nick = nick;
            this.endGame = endGame;
        }

        public string Name { get => name; set => name = value; }
        public string Nick { get => nick; set => nick = value; }
        public bool EndGame { get => endGame; set => endGame = value; }
    }
}
