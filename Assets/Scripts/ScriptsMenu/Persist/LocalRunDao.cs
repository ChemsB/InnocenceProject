using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


//this class manages the game data in local sqlite
namespace Assets.Scripts.ScriptsMenu.Persist
{
    public class LocalRunDao
    {

        private List<LocalRun> listWithGameData; //List with game data
        private readonly static LocalRunDao localRunDao = new LocalRunDao();
        private DBConnector connector = new DBConnector();
        private SqliteCommand comamand;
        private SqliteDataReader dataReader;


        //Constructor singleton pattern
        private LocalRunDao()
        {
        }

        public static LocalRunDao Instance
        {
            get
            {
                return localRunDao;
            }
        }

        /// <summary>
        /// Save game
        /// </summary>
        /// <param name="save">game attributes to save</param>
        public void saveGame(LocalRun save)
        {
            SqliteConnection conn = connector.OpenConnection();
            conn.Open();

            SqliteCommand cmd = new SqliteCommand(conn);
            cmd.CommandText = "INSERT INTO local_run (x,y,health,scene,time,id_character) VALUES (@x,@y,@health,@scene,@time,@id_character)";

            cmd.Parameters.AddWithValue("@x", save.X);
            cmd.Parameters.AddWithValue("@y", save.Y);
            cmd.Parameters.AddWithValue("@health", save.Health);
            cmd.Parameters.AddWithValue("@scene", save.Scene);
            cmd.Parameters.AddWithValue("@time", save.Timer);
            cmd.Parameters.AddWithValue("@id_character", save.Id_character);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// loading saved game
        /// </summary>
        /// <returns>game with coordenates and character attributes</returns>
        internal List<LocalRun> loadGame()
        {
            listWithGameData = new List<LocalRun>();

            SqliteConnection conn = connector.OpenConnection();
            conn.Open();
            string query = "SELECT * FROM local_run";
            comamand = (SqliteCommand)conn.CreateCommand();
            comamand.CommandText = query;
            dataReader = comamand.ExecuteReader();

            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    listWithGameData.Add(new LocalRun(
                        int.Parse(dataReader.GetValue(0).ToString()),
                        float.Parse(dataReader.GetValue(1).ToString()),
                        float.Parse(dataReader.GetValue(2).ToString()),
                        int.Parse(dataReader.GetValue(3).ToString()), 
                        dataReader.GetValue(4).ToString(),
                        dataReader.GetValue(5).ToString(),
                        int.Parse(dataReader.GetValue(6).ToString())));
                }
            }

            conn.Close();
            return listWithGameData;
        }

        /// <summary>
        /// Modify the saved game with recent data
        /// </summary>
        /// <param name="vector">vector to overwrite</param>
        /// <param name="character">character to overwrite</param>
        /// <returns></returns>
        public Boolean checkPoint(Vector3 vector, Character character)
        {
            bool res = false;

            try
            {
                SqliteConnection conn = connector.OpenConnection();
                SqliteCommand cmd = new SqliteCommand();
                cmd.CommandText = @"Update local_run Set x=@x, y=@y, health=@health where id_character=@id_character";
                cmd.Connection = conn;

                cmd.Parameters.Add(new SqliteParameter("@x", vector.x));
                cmd.Parameters.Add(new SqliteParameter("@y", vector.y));
                cmd.Parameters.Add(new SqliteParameter("@health", character.Health));
                cmd.Parameters.Add(new SqliteParameter("@id_character", character.Id));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }catch(Exception ex)
            {
                res = false;
            }
      

            return res;
        }


        /// <summary>
        /// Find game with chracter id
        /// </summary>
        /// <param name="characerId">id to search</param>
        /// <returns></returns>
        public LocalRun findRun(int characerId)
        {
            LocalRun localRun = null;
            foreach (LocalRun local in loadGame())
            {
                if(local.Id_character== characerId)
                {
                    localRun = local;
                }
            }

            return localRun;

        }
    }
}
