using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class IdentidadDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;
        //public List<DocIdentidad> Listar()
        //{
        //    List<DocIdentidad> listaIdentidad = new List<DocIdentidad>();
        //    string findAll = "select*from DocIdentidad order by Desc_Corta asc";
        //    try
        //    {
        //        string cnx = db.Database.Connection.ConnectionString;
        //        con = new SqlConnection(cnx);
        //        comando = new SqlCommand(findAll, con);
        //        con.Open();
        //        SqlDataReader reader = comando.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            DocIdentidad objCliente = new DocIdentidad();
        //            objCliente.Id_DIdent = Convert.ToInt32(reader[0].ToString());
        //            objCliente.Desc_Corta = reader[1].ToString();
        //            listaIdentidad.Add(objCliente);

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

        //    return listaIdentidad;
        //}
    }
}
