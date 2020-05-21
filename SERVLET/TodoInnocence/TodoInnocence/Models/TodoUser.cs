﻿using System;
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