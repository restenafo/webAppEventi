using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppEventiCrociera.classes
{
    public class DBConnection
    {
        SqlConnection conn = new SqlConnection();

        private SqlConnection GetConnectionOpen()
        {
            string connString = @"Data Source=DESKTOP-HNGR6PQ\SQLEXPRESS;Initial Catalog=EVENTICROCIERA;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connString);
            OpenConn(conn);
            return conn;
        }

        private void OpenConn(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }


        /// <summary>
        /// Fa operazioni che restituiscono dati dal DB
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public DataTable DoQuerySelect(string qry)
        {
            SqlConnection conn = GetConnectionOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = qry;

            // Prende i dati dal DB e li inserisce nel DataTable (oggetto simile ad una tabella)
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            conn.Close();
            return dt;
        }


        /// <summary>
        /// Fa operazioni sul DB che non restituiscono nulla (es. INSERT, UPDATE, ecc...)
        /// </summary>
        /// <param name="qry"></param>
        public void ExecuteNonQuery(string qry)
        {
            int esito;
            DataTable dt = new DataTable();

            SqlConnection conn = GetConnectionOpen();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = qry;

            esito = cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}