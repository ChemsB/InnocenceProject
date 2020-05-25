using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace TodoInnocence.Models
{
    public class RunPostQuery
    {
        public AppDb Db { get; set; }

        public RunPostQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<TodoRun> FindOneAsync(int Id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT id_run, score, data, id_user, id_character FROM run WHERE id_user = @Id_user;";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Id_user",
                DbType = DbType.Int32,
                Value = Id,
            });


            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<TodoRun>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT id_run, score, data, id_user, id_character FROM run;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }
        private async Task<List<TodoRun>> ReadAllAsync(DbDataReader reader)
        {
            List<TodoRun> posts = new List<TodoRun>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    TodoRun post = new TodoRun(Db)
                    {
                        Id_run = reader.GetInt32(0),
                        Score = reader.GetInt32(1),
                        Date = reader.GetDateTime(2),
                        Id_user = reader.GetInt32(3),
                        Id_character = reader.GetInt32(4),

                    };
                    posts.Add(post);
                }
            }
            return posts;
        }

    }
}
