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
        public long Id { get; set; }
        public string Name { get; set; }
        public string Nick { get; set; }
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
            cmd.CommandText = @"INSERT INTO `users` (`Name`, `Nick`) VALUES (@name, @nick);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `users` SET `Name` = @name, `Nick` = @nick WHERE `Id` = @id_user;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id_user",
                DbType = DbType.Int32,
                Value = Id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
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
        }
    }
}
