using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class CargoDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;

        public List<cargos> Listar()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            List<cargos> ListaMoneda = new List<cargos>();
            string findAll = "select*from cargos";
            try
            {
                comando = new SqlCommand(findAll, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    cargos objMoneda = new cargos();
                    objMoneda.Codigo = Convert.ToInt32(reader[0].ToString());
                    objMoneda.Nombre = reader[1].ToString();
                    ListaMoneda.Add(objMoneda);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }

            return ListaMoneda;
        }
    }
}
