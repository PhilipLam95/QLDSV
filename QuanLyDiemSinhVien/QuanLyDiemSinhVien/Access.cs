using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace QuanLyDiemSinhVien
{
    class Access
    {
        public static SqlConnection connection;
        /*public static string dataSource = "";
        public static string initCatalog = "";
        public static string username = "";
        public static string password = "";*/

        public static string dataSource = @"DELL-PC\SERVER_ONE";
        public static string initCatalog = "QLDSV";
        public static string username = "sa";
        public static string password = "123";

        public static string hoTen = "";
        public static string mgroup = "";
        public static string mKhoa = "";
        public static string tenKhoa="";
        public static string id;
        public static string malop;
        public static string tenlop;


     

        public static List<Connection> CnnList = new List<Connection>();

        public static bool Connect()
        {
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
            try
            {
                string connectionString = string.Format(@"Data Source={0};Initial Catalog={1};Persist Security Info=True;
                                        User ID={2};Password={3};", dataSource, initCatalog, username, password);

                
               /* string connectionString = string.Format(@"Data Source=DELL-PC\SERVER_ONE;Initial Catalog=QLDSV;Persist Security Info=True;User ID=sa;Password=123");*/
                connection = new SqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }

        public static void Close()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public static DataTable ExecuteQuery(string _cmd, string[] name = null, object[] value = null, int NoParam = 0,
            CommandType cmdType = CommandType.StoredProcedure)
        {
            try
            {
                DataTable dataTable;
                if (connection == null || connection.State == ConnectionState.Closed)
                {
                    Connect();
                }
                using (SqlCommand sqlCmd = new SqlCommand(_cmd, connection))
                {
                    for (int i = 0; i < NoParam; i++)
                    {
                        sqlCmd.Parameters.AddWithValue(name[i], value[i]);
                    }
                    sqlCmd.CommandType = cmdType;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    Close();
                }
                return dataTable;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                Close();
                return null;
            }

        }

        public static SqlDataReader ExecSqlDataReader(string _cmd, string[] name = null, object[] value = null, int NoParam = 0,
                    CommandType cmdType = CommandType.StoredProcedure)
        {
            try
            {
                SqlDataReader reader;
                if (connection == null || connection.State == ConnectionState.Closed)
                    Connect();
                using (SqlCommand sqlCmd = new SqlCommand(_cmd, connection) { CommandType = CommandType.Text })
                {
                    for (int i = 0; i < NoParam; i++)
                    {
                        sqlCmd.Parameters.AddWithValue(name[i], value[i]);
                    }
                    sqlCmd.CommandType = cmdType;
                    reader = sqlCmd.ExecuteReader();
                }
                return reader;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                Close();
                return null;
            }

        }

        public static int ExecuteNonQuery(string _cmd, string[] name = null, object[] value = null, int NoParam = 0,
            CommandType cmdType = CommandType.StoredProcedure)
        {
            int retval;
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                Connect();
            }
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand(_cmd, connection))
                {
                    for (int i = 0; i < NoParam; i++)
                    {
                        sqlCmd.Parameters.AddWithValue(name[i], value[i]);
                    }
                    SqlParameter retParam = new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@retParam", Direction = ParameterDirection.ReturnValue };
                    sqlCmd.Parameters.Add(retParam);
                    sqlCmd.CommandType = cmdType;
                    sqlCmd.ExecuteNonQuery();
                    retval = (int)sqlCmd.Parameters["@retParam"].Value;
                    Close();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                Close();
                return -1;
            }
            return retval;
        }
    }
}
