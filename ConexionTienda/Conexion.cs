using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConexionTienda
{
    public class Conexion
    {
        MySqlConnection con;
        public Conexion(string s, string u, string p, string bd)
        {
            con = new MySqlConnection($"server={s}; user={u}; password={p}; database={bd};");
        }
        public string Comando(string q)
        {
            string rs = "";
            try
            {
                MySqlCommand i = new MySqlCommand(q, con);
                con.Open();
                i.ExecuteNonQuery();
                con.Close();
                rs = "Correcto";
            }
            catch (Exception ex)
            {
                con.Close();
                rs = ex.Message;
            }
            return rs;
        }
        public DataSet Mostrar(string q, string tabla)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(q, con);
                con.Open();
                da.Fill(ds, tabla);
                con.Close();
            }
            catch (Exception)
            {
                con.Close();

            }
            return ds;
        }
        public string ObtenerDatos(string q, string tabla, string campo)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string rs = "";
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(q, con);
                con.Open();
                da.Fill(ds, tabla);
                dt = ds.Tables[0];
                DataRow r = dt.Rows[0];
                rs = r[campo].ToString();
                con.Close();
            }
            catch (Exception)
            {
                con.Close();

            }
            return rs;

        }
    }
}
