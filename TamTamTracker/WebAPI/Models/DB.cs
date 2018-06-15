using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Web;

namespace WebAPI
{
    public static class DB {
        private static MySqlConnection MyConnection{ get; set; }
        private static MySqlDataReader MyReader;
        // Requirements : Install-Package MySql.Data
        // MySql driver for visual studio https://dev.mysql.com/downloads/file/?id=476476
        public static MySqlConnection OpenCon() {

            MySqlConnection MyConnection = null;
            MyConnection = new MySqlConnection("server=164.132.46.37; database= admin_op78; uid= admin_op78; pwd= KGLEqgGWQp;SslMode=none");
            return MyConnection;

        }
        public static void CloseCon()
        {
            MyConnection.Close();
        }
        public static MySqlDataReader QuerySelect(string query)
        {
            MySqlDataReader reader = null;
  
            MyConnection = DB.OpenCon();
            try
            {            
                MySqlCommand cmd = new MySqlCommand(query, MyConnection);
                MyConnection.Open();
                reader = cmd.ExecuteReader();
                
            }
            catch
            {
                Console.Write("Select query gaat fout" + query);
            }
          
            return reader;

        }
        public static void QueryInsert<T>(string query)
        {
            MyConnection = DB.OpenCon();

            MySqlCommand cmd = new MySqlCommand(query, MyConnection);

            MyConnection.Open();
            cmd.ExecuteNonQuery();
            MyConnection.Close();
        }
    }
}