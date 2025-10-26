using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SmartWarehouseDesktop.Conexion
{
    public class DBConnection
    {
        private MySqlConnection connection;
        private string connectionString = "Server=localhost;Database=smartwarehouse_db;Uid=root;Pwd=1234;";

        public DBConnection()
        {
       
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public void CloseConnection()
        {
            connection.Close();
        }

    }
}
