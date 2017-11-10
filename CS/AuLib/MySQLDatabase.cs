using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AuLib
{
    public class MySQLDatabase
    {
        public MySqlConnection conn;
        public DataTable dt;

        public MySQLDatabase(string server, string user, string password, string database)
        {
            string cnStr = "server="+server+
                ";user id="+user+
                ";password="+password+
                ";persistsecurityinfo=True;database="+database+
                ";Convert Zero Datetime=True";
            this.conn = new MySqlConnection(cnStr);
        }

        public int query(String sqlCmd)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd;

            this.dt.Dispose();
            this.dt = new DataTable();

            try
            {
                this.conn.Open();
                cmd = new MySqlCommand(sqlCmd, this.conn);
                da.SelectCommand = cmd;
                this.dt.Clear();
                da.Fill(this.dt);
                da.Dispose();
                this.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Source: " + ex.Source + ", Message: " + ex.Message);
            }

            return this.dt.Rows.Count;
        }
    }
}
