using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop
{
    class BD
    {
        public static MySqlConnection GetConnection(string host, string db, int port, string user, string pass)
        {
            String ConnString = "server = " + host + ";DataBase = " + db + ";port = " + port.ToString() + ";User id = " + user + ";Password = " + pass + ";";
            MySqlConnection conn = new MySqlConnection(ConnString);
            return conn;
        }
    }
}
