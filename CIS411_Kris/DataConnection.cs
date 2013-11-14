using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

public class DataConnection
{
    public SqlConnection cn;
    public SqlCommand cmd;
    public SqlDataReader rd;
    public DataConnection()
    {
        cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True");
        cmd = new SqlCommand();
        cn.Open(); //TESTING DATABASE
        cn.Close();
        cmd.Connection = cn;
    }

    public SqlConnection getConn()
    {
        cn.Open();
        return cn;
    }

    public void open()
    {
        cn.Open();
    }

    public void close()
    {
        if (!(rd.IsClosed))
            rd.Close();
        cn.Close();
    }

    public SqlDataReader getReader(string command)
    {
        cmd.CommandText = command;
        rd = cmd.ExecuteReader();
        return rd;
    }

    public SqlDataReader getReader(string column, string table)
    {
        cmd.CommandText = "SELECT '" + column + "' FROM '" + table + "'";
        rd = cmd.ExecuteReader();
        return rd;
    }

    public SqlDataReader getReader(string column, string table, string conditionColumn, string conditionValue)
    {
        int i;
        cmd.CommandText = "SELECT " + column + " FROM " + table + " WHERE " + conditionColumn + " = " + (int.TryParse(conditionValue, out i) ? "" : "'") + conditionValue.ToString() + (int.TryParse(conditionValue, out i) ? "" : "'");
        rd = cmd.ExecuteReader();
        return rd;
    }

    public void query(string q)
    {
        cmd.CommandText = q;
        cmd.ExecuteNonQuery();
    }
}