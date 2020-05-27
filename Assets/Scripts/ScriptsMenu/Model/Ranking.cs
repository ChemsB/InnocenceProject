using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ScriptsMenu.Model
{
 
    [Serializable]
    public class Ranking
    {

        public int id_run;
        public int score;
        public String date;
        public int id_user;
        public int id_character;


        //Constructors
        public Ranking(int id_run, int score, string date, int id_user, int id_character)
        {
            this.id_run = id_run;
            this.score = score;
            this.date = date;
            this.id_user = id_user;
            this.id_character = id_character;
        }

        //Accessors
        public int Id_run { get => id_run; set => id_run = value; }
        public int Score { get => score; set => score = value; }
        public string Date { get => date; set => date = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int Id_character { get => id_character; set => id_character = value; }

    }
}
