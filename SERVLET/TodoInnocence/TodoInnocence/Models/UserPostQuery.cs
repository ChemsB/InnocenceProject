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

        public async Task<TodoUser> FindOneAsync(String nick, String password)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT id_user, name, nick, password, id_videogame FROM users WHERE nick = @Nick AND password = @Password";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Nick",
                DbType = DbType.String,
                Value = nick,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Password",
                DbType = DbType.String,
                Value = password,
            });


            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }


        public async Task<List<TodoUser>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT id_user, name, nick, password, id_videogame FROM users;";
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
                           Password= reader.GetString(3),
                           Id_videogame = reader.GetInt32(4)

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
