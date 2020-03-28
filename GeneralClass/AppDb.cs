using System;
using MySql.Data.MySqlClient;

namespace web_api
{
    public class AppDb : IDisposable
    {
        public MySqlConnection Connection { get; }

        public AppDb(string connectionString = "server=192.168.2.47;user id=root;password=admadles;port=3306;database=blog;")
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}
