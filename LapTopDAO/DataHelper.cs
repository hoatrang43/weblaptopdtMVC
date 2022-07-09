using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace LapTopDAO
{
    public class DataHelper
    {
        
        string stcon = ConfigurationManager.ConnectionStrings["strconnect"].ConnectionString;
        SqlConnection con;
        public DataHelper(string stcon)
        {
            this.stcon = stcon;
            con = new SqlConnection(stcon);
        }
        public DataHelper()
        {
            con = new SqlConnection(stcon);
        }
        public string MoKetNoi()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public void Close()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
        }
        public SqlDataReader ExcuteReader(string sqlSelect)
        {
            string st = MoKetNoi();
            if (st != "")
                throw new Exception(st);
            SqlCommand cm = new SqlCommand(sqlSelect, con);
            return cm.ExecuteReader();
        }
        public SqlDataReader StoreReader(string storename, params object[] giatri)
        {
            SqlCommand cm; MoKetNoi();
            try
            {
                cm = new SqlCommand(storename, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 0; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                SqlDataReader dr = cm.ExecuteReader();
                return dr;
            }
            catch { return null; }
        }
        public string ExecuteNonQuery(string sql)
        {
            try
            {
                MoKetNoi();
                SqlCommand cm = new SqlCommand(sql, con);
                cm.ExecuteNonQuery();
                Close();
                return "";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }


        }
        public DataTable FillDataTable(string sql)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, stcon);
            
            da.Fill(dt);
            return dt;
        }
        public DataTable GetDataTable(string sqlSelect)
        {
            //if (con.State == ConnectionState.Closed)
            //    con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, con);
            da.Fill(dt);
            return dt;
        }
        public void InsertRow(DataTable dt, params object[] values)
        {
            DataRow dr = dt.NewRow();
            for (int i = 0; i < values.Length; i++)
            {
                dr[i] = values[i];
            }
            dt.Rows.Add(dr);
        }
        //"MaSV","001","TenSV","dsghdsbgdsh"
        public void InsertRow1(DataTable dt, params object[] Fields_values)
        {
            DataRow dr = dt.NewRow();
            for (int i = 0; i < Fields_values.Length; i += 2)
            {
                dr[Fields_values[i].ToString()] = Fields_values[i + 1].ToString();
            }
        }
        public SqlDataReader StoreReaders(string GetSanPhams, params object[] giatri)
        {
            SqlCommand cm;
            MoKetNoi();
            try
            {
                cm = new SqlCommand(GetSanPhams, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                SqlDataReader dr = cm.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;
            }
        }
    }
}