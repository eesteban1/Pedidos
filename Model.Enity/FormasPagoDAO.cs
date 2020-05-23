using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class FormasPagoDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;
        public object Listar()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            List<FormasPago> ListaMoneda = new List<FormasPago>();
            string findAll = "select*from FormasPago";
            try
            {
                comando = new SqlCommand(findAll, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    FormasPago objMoneda = new FormasPago();
                    objMoneda.Id_FormaPago = Convert.ToInt32(reader[0].ToString());
                    objMoneda.Nombre = reader[1].ToString();
                    ListaMoneda.Add(objMoneda);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ListaMoneda;
        }
    }
}
