using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap6.DAO
{
    internal class DataProvider
    {
        public static string connectionString;
        public static SqlConnection conn;
        private SqlDataAdapter adapter;
        private SqlCommand command;

        public void connect()
        {
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Không kết nối được CSDL", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void disconnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public DataTable executeQuery(string sqlString)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            adapter = new SqlDataAdapter(sqlString, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            disconnect();
            return ds.Tables[0];

        }

        public void executeNonQuery(string sqlString)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command = new SqlCommand(sqlString, conn);
            command.ExecuteNonQuery();
            disconnect();
        }
        public object executeScalar(string sqlString)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command = new SqlCommand(sqlString, conn);
            disconnect();
            return command.ExecuteScalar();
        }
    }
}

