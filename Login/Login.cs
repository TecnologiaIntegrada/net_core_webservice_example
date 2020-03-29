using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace web_api
{
    public class Login
    {
        public string mylogin { get; set; }
        public string mypassword { get; set; }
        public string permit { get; set; }


        internal AppDb Db { get; set; }

        public Login()
        {

        }

        internal Login(AppDb db)
        {
            Db = db;
        }

        
    }
}
