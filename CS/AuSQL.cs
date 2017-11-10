using MySql.Data.MySqlClient;

class AuSQL
{
    public MySqlConnection conn;
    public DataTable dt;

    public AuSQL(String connectionString)
    {
        this.conn = new MySqlConnection(connectionString);
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