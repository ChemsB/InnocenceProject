using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace TodoInnocence.Models
{
    public class TodoUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public int Id_videogame { get; set; }

        internal AppDb Db { get; set; }

        public TodoUser()
        {
        }
        internal TodoUser(AppDb db)
        {
            Db = db;
        }


        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO users (id_user, name, nick, password, id_videogame) VALUES (@Id, @Name, @Nick, @Password, @Id_videogame);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand(); //where id_user = @Id
            cmd.CommandText = @"UPDATE users SET name = @Name, nick = @Nick, password = @Password, id_videogame = @Id_videogame WHERE id_user = @Id;";
            BindParams(cmd);
            BindId(cmd);
          //  BindNick(cmd);
          //  BindPassword(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindNick(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@nick",
                DbType = DbType.String,
                Value = Nick,
            });
        }
        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }

        private void BindPassword(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@password",
                DbType = DbType.String,
                Value = Password,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Id",
                DbType = DbType.Int32,
                Value = Id,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@name",
                DbType = DbType.String,
                Value = Name,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@nick",
                DbType = DbType.String,
                Value = Nick,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@password",
                DbType = DbType.String,
                Value = Password,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id_videogame",
                DbType = DbType.Int32,
                Value = Id_videogame,
            });
        }
    }
}
