using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DatabaseManager.Utils
{
    class SqlClient
    {
        public MySqlConnection connection;

        public SqlClient() {
            connection = new MySqlConnection("host=localhost;user=root;password=;database=test;");
            connection.Open();
        }
        public void Close() {
            connection.Close();
        }
    }
}
