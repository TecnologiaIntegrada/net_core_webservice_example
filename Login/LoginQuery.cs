using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace web_api
{
    public class LoginQuery
    {
        public AppDb Db { get; }

        public LoginQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Login> Auth_User(string user, string passwd)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `Title`, `Content` FROM `BlogPost` WHERE `Id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                //ParameterName = "@id",
                //DbType = DbType.Int32,
                //Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<Login> GetInstructions()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"select * from INFO_SYS order by INFO_SYS.ORDER_PROCESS ASC , INFO_SYS.ORDER_CATEGORY ASC, INFO_SYS.DATE_PUBLISHED DESC";
            cmd.Parameters.Add(new MySqlParameter
            {
                //ParameterName = "@id",
                //DbType = DbType.Int32,
                //Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        private async Task<List<Login>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Login>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Login(Db)
                    {
                        //Id = reader.GetInt32(0),
                        //Title = reader.GetString(1),
                        //Content = reader.GetString(2),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
