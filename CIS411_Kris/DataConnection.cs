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
        string folder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        string dbPath = System.IO.Path.Combine(folder, "db.mdf");
        int bin = dbPath.IndexOf("bin");
        dbPath = dbPath.Remove(bin);
 
        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.SetData("database", dbPath + "db.mdf");
        cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='"+currentDomain.GetData("database")+"';Integrated Security=True");
        cmd = new SqlCommand();
        cn.Open(); //TESTING DATABASE
        cn.Close();
        cmd.Connection = cn;
    }

    public SqlConnection GetConn()
    {
        return cn;
    }

    public void Open()
    {
        cn.Open();
    }

    public void Close()
    {
        if ((!(rd==null))&&(!(rd.IsClosed)))
            rd.Close();
        cn.Close();
    }

    public SqlDataReader GetReader(string command)
    {
        cmd.CommandText = command;
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public SqlDataReader GetReader(string column, string table)
    {
        cmd.CommandText = "SELECT " + column + " FROM " + table;
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public SqlDataReader GetReader(string column, string table, string conditionColumn, string conditionValue)
    {
        int i;
        cmd.CommandText = "SELECT " + column + " FROM " + table + " WHERE " + conditionColumn + " = " + (int.TryParse(conditionValue, out i) ? "" : "'") + conditionValue.ToString() + (int.TryParse(conditionValue, out i) ? "" : "'");
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public SqlDataReader GetReader(string column, string table, string conditionColumn, string conditionValue, string condition2)
    {
        int i;
        cmd.CommandText = "SELECT " + column + " FROM " + table + " WHERE " + conditionColumn + " = " + (int.TryParse(conditionValue, out i) ? "" : "'") + conditionValue.ToString() + (int.TryParse(conditionValue, out i) ? "" : "'") + condition2;
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public SqlDataReader GetReader(string column, string table, string conditionColumn1, string conditionValue1, string conditionColumn2, string conditionValue2)
    {
        int i;
        cmd.CommandText = "SELECT " + column + " FROM " + table + " WHERE " + conditionColumn1 + " = " + (int.TryParse(conditionValue1, out i) ? "" : "'") + conditionValue1.ToString() + (int.TryParse(conditionValue1, out i) ? "" : "'" + " AND " + conditionColumn2 + " = " + (int.TryParse(conditionValue2, out i) ? "" : "'") + conditionValue2.ToString() + (int.TryParse(conditionValue2, out i) ? "" : "'"));
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public void Query(string q)
    {
        cmd.CommandText = q;
        cmd.ExecuteNonQuery();
    }

    public SqlDataReader GetReader(string column, string table, string table2, string condition, int asdf)
    {
        cmd.CommandText = "SELECT " + column + " FROM " + table + " inner join " + table2 +" on " + condition;
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }
}