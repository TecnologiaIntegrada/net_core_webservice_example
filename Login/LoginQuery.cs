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

        public async Task<string> Auth_User(string mylogin, string mypassword)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `PERMIT` FROM `USERS` WHERE `LOGIN` = @mylogin AND `PASSWORD` = @mypassword";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@mylogin",
                DbType = DbType.String,
                Value = mylogin,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@mypassword",
                DbType = DbType.String,
                Value = mypassword,
            });
            var result = returnDS_Login(await cmd.ExecuteReaderAsync());
            return result.Length > 0 ? result.ToString() : null;
        }

        public async Task<LoginQuery> GetInstructions()
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

        private async Task<List<LoginQuery>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<LoginQuery>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new LoginQuery(Db)
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


        private string returnDS_Login(DbDataReader reader)
        {
            using (reader)
            {
                reader.ReadAsync();
                {
                    string _set_permit = reader.GetString(0);
                    return _set_permit;
                }
            }

        }
    }
}
