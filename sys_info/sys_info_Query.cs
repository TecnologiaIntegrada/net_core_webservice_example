using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace web_api
{
    public class sys_info_Query
    {
        public AppDb Db { get; }

        public sys_info_Query(AppDb db)
        {
            Db = db;
        }

        public async Task<List<sys_info>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"select INFO_SYS.Title, INFO_SYS.Process, INFO_SYS.Category, INFO_SYS.Author, INFO_SYS.Date_Published, INFO_SYS.Description from INFO_SYS order by INFO_SYS.ORDER_PROCESS ASC , INFO_SYS.ORDER_CATEGORY ASC, INFO_SYS.DATE_PUBLISHED DESC";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        private async Task<List<sys_info>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<sys_info>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new sys_info(Db)
                    {
                        sys_info_Title = reader.GetString(0),
                        sys_info_Process = reader.GetString(1),
                        sys_info_Category = reader.GetString(2),
                        sys_info_Author = reader.GetString(3),
                        sys_info_Date_Published = reader.GetDateTime(4),
                        sys_info_Description = reader.GetString(5)
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
