using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class DenominacionDAO
    {
        ventas2Entities db = new ventas2Entities();
        SqlConnection con = null;
        private SqlCommand comando;
        private SqlDataReader reader;

        public List<Denominacion>  Listar()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            List<Denominacion> listaClaseClie = new List<Denominacion>();
            string find = "select*from ClaseClie order by Nombre";
            try
            {
                comando = new SqlCommand(find, con);
                con.Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Denominacion objClaseClie = new Denominacion();
                    objClaseClie.IdDenominacion = Convert.ToInt32(reader[0].ToString());
                    objClaseClie.Descripcion = reader[1].ToString();
                    listaClaseClie.Add(objClaseClie);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return listaClaseClie;
        }
    }
}
