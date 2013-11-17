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
        cmd.CommandText = GetReaderString(column, table, conditionColumn, conditionValue);
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
        cmd.CommandText = GetReaderString(column, table, conditionColumn1, conditionValue1, conditionColumn2, conditionValue2);
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public SqlDataReader GetReader(string column, string table, string conditionColumn1, string conditionValue1, string conditionColumn2, string conditionValue2, string conditionColumn3, string conditionValue3)
    {
        cmd.CommandText = GetReaderString(column, table, conditionColumn1, conditionValue1, conditionColumn2, conditionValue2, conditionColumn3, conditionValue3);
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public SqlDataReader GetReader(string column, string table, string conditionColumn1, string conditionValue1, string conditionColumn2, string conditionValue2, string conditionColumn3, string conditionValue3, string conditionColumn4, string conditionValue4)
    {
        cmd.CommandText = GetReaderString(column, table, conditionColumn1, conditionValue1, conditionColumn2, conditionValue2, conditionColumn3, conditionValue3, conditionColumn4, conditionValue4);
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public SqlDataReader GetReader(string column, string table, string conditionColumn1, string conditionValue1, string conditionColumn2, string conditionValue2, string conditionColumn3, string conditionValue3, string conditionColumn4, string conditionValue4, string conditionColumn5, string conditionValue5)
    {
        cmd.CommandText = GetReaderString(column, table, conditionColumn1, conditionValue1, conditionColumn2, conditionValue2, conditionColumn3, conditionValue3, conditionColumn4, conditionValue4, conditionColumn5, conditionValue5);
        if (rd == null)
            rd = cmd.ExecuteReader();
        else
        {
            rd.Close();
            rd = cmd.ExecuteReader();
        }
        return rd;
    }

    public string GetReaderString(string column, string table)
    {
        return "SELECT " + column + " FROM " + table;
    }

    public string GetReaderString(string column, string table, string conditionColumn, string conditionValue)
    {
        int i;
        return GetReaderString(column, table) + " WHERE " + conditionColumn + " = " + (int.TryParse(conditionValue, out i) ? "" : "'") + conditionValue.ToString() + (int.TryParse(conditionValue, out i) ? "" : "'");
    }

    public string GetReaderString(string column, string table, string conditionColumn1, string conditionValue1, string conditionColumn2, string conditionValue2)
    {
        int i;
        return GetReaderString(column, table, conditionColumn1, conditionValue1) + " AND " + conditionColumn2 + " = " + (int.TryParse(conditionValue2, out i) ? "" : "'") + conditionValue2.ToString() + (int.TryParse(conditionValue2, out i) ? "" : "'");
    }

    public string GetReaderString(string column, string table, string conditionColumn1, string conditionValue1, string conditionColumn2, string conditionValue2, string conditionColumn3, string conditionValue3)
    {
        int i;
        return GetReaderString(column, table, conditionColumn1, conditionValue1, conditionColumn2, conditionValue2) + " AND " + conditionColumn3 + " = " + (int.TryParse(conditionValue3, out i) ? "" : "'") + conditionValue3.ToString() + (int.TryParse(conditionValue3, out i) ? "" : "'");
    }

    public string GetReaderString(string column, string table, string conditionColumn1, string conditionValue1, string conditionColumn2, string conditionValue2, string conditionColumn3, string conditionValue3, string conditionColumn4, string conditionValue4)
    {
        int i;
        return GetReaderString(column, table, conditionColumn1, conditionValue1, conditionColumn2, conditionValue2, conditionColumn3, conditionValue3) + " AND " + conditionColumn4 + " = " + (int.TryParse(conditionValue4, out i) ? "" : "'") + conditionValue4.ToString() + (int.TryParse(conditionValue4, out i) ? "" : "'");
    }

    public string GetReaderString(string column, string table, string conditionColumn1, string conditionValue1, string conditionColumn2, string conditionValue2, string conditionColumn3, string conditionValue3, string conditionColumn4, string conditionValue4, string conditionColumn5, string conditionValue5)
    {
        int i;
        return GetReaderString(column, table, conditionColumn1, conditionValue1, conditionColumn2, conditionValue2, conditionColumn3, conditionValue3, conditionColumn4, conditionValue4) + " AND " + conditionColumn5 + " = " + (int.TryParse(conditionValue5, out i) ? "" : "'") + conditionValue5.ToString() + (int.TryParse(conditionValue5, out i) ? "" : "'");
    }

    public void Query(string q)
    {
        cmd.CommandText = q;
        cmd.ExecuteNonQuery();
    }
}