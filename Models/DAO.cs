using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace KP.Models
{
    public class DAO
    {
        public MySqlConnection conn;
        public static readonly string СonnectionString = MakeConnStr();

        static string MakeConnStr()
        {
            MySqlConnectionStringBuilder connStr = new MySqlConnectionStringBuilder();
            connStr.Server = "localhost";
            connStr.Database = "tp_kp";
            connStr.UserID = "root";
            connStr.Password = "root";
            return connStr.ConnectionString;
        }

        public void Connect()
        {
            conn = new MySqlConnection(СonnectionString);
            conn.Open();
        }

        public void Disconnect()
        {
            conn.Close();
        }

    }
}