using Assets.Scripts.ScriptsMenu.Persist;
using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Persist
{
    public class CharacterDao
    {
        private List<Character> listWithCharacters; //List with characters
        private readonly static CharacterDao characterDao = new CharacterDao();
        private DBConnector connector = new DBConnector();
        private SqliteCommand comamand;
        private SqliteDataReader dataReader;


        //Constructor singleton pattern
        private CharacterDao()
        {
            loadTestData();
        }

        public static CharacterDao Instance
        {
            get
            {
                return characterDao;
            }
        }


        /// <summary>
        /// load character list with sqlite data
        /// </summary>
        private void loadTestData()
        {
            listWithCharacters = new List<Character>();

            SqliteConnection conn = connector.OpenConnection();
            conn.Open();
            string query = "SELECT * FROM characters";
            comamand = (SqliteCommand)conn.CreateCommand();
            comamand.CommandText = query;
            dataReader = comamand.ExecuteReader();

            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    listWithCharacters.Add(new Character(int.Parse(dataReader.GetValue(0).ToString()),
                        dataReader.GetValue(1).ToString(), 
                        int.Parse(dataReader.GetValue(2).ToString()),
                        int.Parse(dataReader.GetValue(3).ToString()),
                        Resources.Load<Sprite>(dataReader.GetValue(4).ToString())));
                }
            }
            conn.Close();
        }

        //Accessors
        public List<Character> ListWithCharacters { get => listWithCharacters; set => listWithCharacters = value; }

    }
}
