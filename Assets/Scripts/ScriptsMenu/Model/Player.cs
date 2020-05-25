using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{

    [Serializable]
    public class Player
    {
        public string name;
        public string nick;
        public bool endGame;
        public float score;
        public string password;
        public int id_videogame;


        //Constructors
        public Player()
        {
        }

        public Player(string name, string nick, bool endGame, float score, string password,int id_videogame)
        {
            this.name = name;
            this.nick = nick;
            this.endGame = endGame;
            this.score = score;
            this.password = password;
            this.id_videogame = id_videogame;
        }

        //Accessors
        public string Name { get => name; set => name = value; }
        public string Nick { get => nick; set => nick = value; }
        public bool EndGame { get => endGame; set => endGame = value; }
        public float Score { get => score; set => score = value; }
        public string Password { get => password; set => password = value; }
        public int Id_videogame { get => id_videogame; set => id_videogame = value; }
    }
}
