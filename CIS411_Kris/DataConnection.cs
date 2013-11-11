using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

static class DataConnection
{
    static public SqlConnection cn;
    static public SqlCommand cmd;
    static public SqlDataReader rd;
    static DataConnection()
    {
        cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True");
        cmd = new SqlCommand();
        cn.Open(); //TESTING DATABASE
        cn.Close();
        cmd.Connection = cn;
    }

    static public SqlConnection getConn()
    {
        cn.Open();
        return cn;
    }

    static public void closeConn()
    {
        cn.Close();
    }

    static public SqlDataReader getReader(string s)
    {
        return rd;
    }
}