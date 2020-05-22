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
        public AppDb Db { get; }

        public UserPostQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<TodoUser> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `Name`, `Nick` FROM `users` WHERE `Id` = @id_user";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }


        public async Task<List<TodoUser>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id_user`, `name`, `nick`, `id_videogame` FROM `users`;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }


        private async Task<List<TodoUser>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<TodoUser>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new TodoUser(Db)
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Nick = reader.GetString(2),
                        Id_videogame = reader.GetInt32(3),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
