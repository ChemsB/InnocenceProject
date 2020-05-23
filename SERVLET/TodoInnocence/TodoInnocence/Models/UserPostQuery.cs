using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace TodoInnocence.Models
{
    public class UserPostQuery
    {
        public AppDb Db { get; set; }

        public UserPostQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<TodoUser> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT id_user, name, nick, id_videogame FROM users WHERE id_user = @Id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }


        public async Task<List<TodoUser>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT id_user, name, nick, id_videogame FROM users;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }


        private async Task<List<TodoUser>> ReadAllAsync(DbDataReader reader)
        {
            List <TodoUser> posts = new List<TodoUser>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    TodoUser post = new TodoUser(Db)
                    {
                           Id = reader.GetInt32(0),
                           Name = reader.GetString(1),
                           Nick = reader.GetString(2),
                           Id_videogame = reader.GetInt32(3)

                    /*    Id = Convert.ToInt32(reader["id_user"]),
                        Name = reader["name"].ToString(),
                        Nick = reader["nick"].ToString(),
                        Id_videogame= Convert.ToInt32(reader["id_videogame"])*/
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
