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
        cn = GetConn();
        cmd = new SqlCommand();
        cn.Open(); //TESTING DATABASE
        cn.Close();
        cmd.Connection = cn;
    }

    static public int getTerm(int year, string semester)
    {
        switch (semester.ToLower())
        {
            case "spring":
                return 2000 + ((year % 100 * 10)) + 1;
            case "summer":
                return 2000 + ((year % 100 * 10)) + 5;
            case "fall":
                return 2000 + ((year % 100 * 10)) + 8;
            case "winter":
                return 2000 + ((year % 100 * 10)) + 9;
            default:
                return -1;
        }
    }

    static public SqlConnection GetConn()
    {
        /*string dbPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        //string dbPath = System.IO.Path.Combine(folder, "db.mdf");
        int bin = dbPath.IndexOf("bin");
        dbPath = dbPath.Remove(bin);
        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.SetData("database", dbPath + "db.mdf");
        //return new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + currentDomain.GetData("database") + "';Integrated Security=True");;
        */
        return new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True");;
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

    public SqlDataReader GetReader(string column, string table, string condition)
    {
        cmd.CommandText = GetSelectString(column, table, condition);
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public SqlDataReader GetReader(string column, string table, string whereColumn, string whereValue)
    {
        cmd.CommandText = GetSelectString(column, table, whereColumn, whereValue);
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public SqlDataReader GetReader(string column, string table, string whereColumn1, string whereValue1, string whereColumn2, string whereValue2)
    {
        cmd.CommandText = GetSelectString(column, table, whereColumn1, whereValue1, whereColumn2, whereValue2);
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public SqlDataReader GetReader(string column, string table, string whereColumn1, string whereValue1, string whereColumn2, string whereValue2, string whereColumn3, string whereValue3)
    {
        cmd.CommandText = GetSelectString(column, table, whereColumn1, whereValue1, whereColumn2, whereValue2, whereColumn3, whereValue3);
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public SqlDataReader GetReader(string column, string table, string whereColumn1, string whereValue1, string whereColumn2, string whereValue2, string whereColumn3, string whereValue3, string whereColumn4, string whereValue4)
    {
        cmd.CommandText = GetSelectString(column, table, whereColumn1, whereValue1, whereColumn2, whereValue2, whereColumn3, whereValue3, whereColumn4, whereValue4);
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public SqlDataReader GetReader(string column, string table, string whereColumn1, string whereValue1, string whereColumn2, string whereValue2, string whereColumn3, string whereValue3, string whereColumn4, string whereValue4, string whereColumn5, string whereValue5)
    {
        cmd.CommandText = GetSelectString(column, table, whereColumn1, whereValue1, whereColumn2, whereValue2, whereColumn3, whereValue3, whereColumn4, whereValue4, whereColumn5, whereValue5);
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    static public string GetSelectString(string column, string table)
    {
        return "SELECT " + column + " FROM " + table;
    }
    
    static public string GetSelectString(string column, string table, string condition)
    {
        return GetSelectString(column, table) + " " + condition;
    }

    static public string GetSelectString(string column, string table, string whereColumn, string whereValue)
    {
        int i;
        return GetSelectString(column, table) + " WHERE " + whereColumn + " = " + (int.TryParse(whereValue, out i) ? "" : "'") + whereValue.ToString() + (int.TryParse(whereValue, out i) ? "" : "'");
    }

    static public string GetSelectString(string column, string table, string whereColumn, string whereValue, string condition)
    {
        return GetSelectString(column, table, whereColumn, whereValue) + " " + condition;
    }

    static public string GetSelectString(string column, string table, string whereColumn1, string whereValue1, string whereColumn2, string whereValue2)
    {
        int i;
        return GetSelectString(column, table, whereColumn1, whereValue1) + " AND " + whereColumn2 + " = " + (int.TryParse(whereValue2, out i) ? "" : "'") + whereValue2.ToString() + (int.TryParse(whereValue2, out i) ? "" : "'");
    }

    static public string GetSelectString(string column, string table, string whereColumn1, string whereValue1, string whereColumn2, string whereValue2, string whereColumn3, string whereValue3)
    {
        int i;
        return GetSelectString(column, table, whereColumn1, whereValue1, whereColumn2, whereValue2) + " AND " + whereColumn3 + " = " + (int.TryParse(whereValue3, out i) ? "" : "'") + whereValue3.ToString() + (int.TryParse(whereValue3, out i) ? "" : "'");
    }

    static public string GetSelectString(string column, string table, string whereColumn1, string whereValue1, string whereColumn2, string whereValue2, string whereColumn3, string whereValue3, string whereColumn4, string whereValue4)
    {
        int i;
        return GetSelectString(column, table, whereColumn1, whereValue1, whereColumn2, whereValue2, whereColumn3, whereValue3) + " AND " + whereColumn4 + " = " + (int.TryParse(whereValue4, out i) ? "" : "'") + whereValue4.ToString() + (int.TryParse(whereValue4, out i) ? "" : "'");
    }

    static public string GetSelectString(string column, string table, string whereColumn1, string whereValue1, string whereColumn2, string whereValue2, string whereColumn3, string whereValue3, string whereColumn4, string whereValue4, string whereColumn5, string whereValue5)
    {
        int i;
        return GetSelectString(column, table, whereColumn1, whereValue1, whereColumn2, whereValue2, whereColumn3, whereValue3, whereColumn4, whereValue4) + " AND " + whereColumn5 + " = " + (int.TryParse(whereValue5, out i) ? "" : "'") + whereValue5.ToString() + (int.TryParse(whereValue5, out i) ? "" : "'");
    }

    public void Query(string q)
    {
        cmd.CommandText = q;
        cmd.ExecuteNonQuery();
    }

    public SqlDataReader joinQuery(string q)
    {
        cmd.CommandText = q;
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }
        public SqlDataReader GetReader(string column, string table, string whereColumn, string whereValue, string condition2)
    {
        int i;
        cmd.CommandText = "SELECT " + column + " FROM " + table + " WHERE " + whereColumn + " = " + (int.TryParse(whereValue, out i) ? "" : "'") + whereValue.ToString() + (int.TryParse(whereValue, out i) ? "" : "'") + condition2;
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
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
        public SqlDataReader GetReader(string column, string table, string table2, string condition, string condition2, int asdf)
    {
        cmd.CommandText = "SELECT " + column + " FROM " + table + " inner join " + table2 +" on " + condition + condition2;
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