using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace TodoInnocence.Models
{
    public class TodoRun
    {
        [Key]
        public int Id_run { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public int Id_user { get; set; }
        public int Id_character { get; set; }


        internal AppDb Db { get; set; }

        public TodoRun()
        {
        }
        internal TodoRun(AppDb db)
        {
            Db = db;
        }




        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE run SET id_run = @Id_run, score = @Score, data = @Date, id_character = @Id_character WHERE id_user = @Id_user;";
            BindParams(cmd);
          //  BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Id_user",
                DbType = DbType.Int32,
                Value = Id_user,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id_run",
                DbType = DbType.Int32,
                Value = Id_run,
            });

            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@score",
                DbType = DbType.Int32,
                Value = Score,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@date",
                DbType = DbType.DateTime,
                Value = Date,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Id_user",
                DbType = DbType.Int32,
                Value = Id_user,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id_character",
                DbType = DbType.Int32,
                Value = Id_character,
            });
        }



    }
}
