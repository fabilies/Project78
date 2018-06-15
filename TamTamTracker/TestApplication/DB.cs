using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TestApplication
{
    public static class DB {
        private static MySqlConnection MyConnection{ get; set; }
        private static MySqlDataReader MyReader;


        // Requirements : Install-Package MySql.Data
        // MySql driver for visual studio https://dev.mysql.com/downloads/file/?id=476476
        public static void OpenCon() {

            MySqlConnection MyConnection = null;

            MyConnection = new MySqlConnection("server=164.132.46.37; database= admin_op78; uid= admin_op78; pwd= KGLEqgGWQp;SslMode=none");
          //"Server=127.0.0.1;Database=suggestions;UID=root;Password=stefan"
          //  MyConnection.Open();

        }

        public static void CloseCon()
        {
           // MyConnection.Close();
        }

        public static void QueryInsert<T>(string query)
        {
             MyConnection = new MySqlConnection(
             "server=164.132.46.37; database= admin_op78; uid= admin_op78; pwd= KGLEqgGWQp;SslMode=none"
            );

            MySqlCommand cmd = new MySqlCommand(query, MyConnection);

            MyConnection.Open();
            cmd.ExecuteNonQuery();
            MyConnection.Close();
        }
    }
}