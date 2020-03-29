using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class MonedaDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;

        //public List<Monedas> Listar()
        //{
        //    string cnx = db.Database.Connection.ConnectionString;
        //    con = new SqlConnection(cnx);
        //    List<Moneda> ListaMoneda = new List<Moneda>();
        //    string findAll = "select*from Moneda order by Desc_Corta asc";
        //    try
        //    {
        //        comando = new SqlCommand(findAll, con);
        //        con.Open();
        //        SqlDataReader reader = comando.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Moneda objMoneda = new Moneda();
        //            objMoneda.Id_Moneda = Convert.ToInt32(reader[0].ToString());
        //            objMoneda.Desc_Corta = reader[1].ToString();
        //            objMoneda.Desc_Large = reader[2].ToString();
        //            ListaMoneda.Add(objMoneda);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //    return ListaMoneda;
        //}
    }
}
