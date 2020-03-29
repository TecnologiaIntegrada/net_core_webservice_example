using System;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace web_api
{
    public class sys_info_class
    {
        public string sys_info_Title { get; set; }
        public string sys_info_Process { get; set; }
        public string sys_info_Category { get; set; }
        public string sys_info_Author { get; set; }
        public DateTime sys_info_Date_Published { get; set; }
        public string sys_info_Description { get; set; }

        internal AppDb Db { get; set; }

        public sys_info_class()
        {

        }

        internal sys_info_class(AppDb db)
        {
            Db = db;
        }

        
    }
}
