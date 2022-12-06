using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop
{
    class BDUtills
    {
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();

        public static MySqlConnection GetDBConnection()
        {
            string host = "37.77.105.162";
            string db = "ZooShop";
            int port = 3306;
            string user = "Lyuts";
            string pass = "meox9AKR@";

            return BD.GetConnection(host, db, port, user, pass);
        }
    }
}
