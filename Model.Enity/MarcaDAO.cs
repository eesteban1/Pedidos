using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class MarcaDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;

        public object Listar()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            List<Marcas> listaMarcas = new List<Marcas>();
            string find = "select*from Marcas order by Descripcion asc";
            try
            {
                comando = new SqlCommand(find, con);
                con.Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Marcas objMarca = new Marcas();
                    objMarca.Id_Marca = Convert.ToInt32(reader[0].ToString());
                    objMarca.Descripcion = reader[1].ToString();
                    listaMarcas.Add(objMarca);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                con.Close();
            }

            return listaMarcas;
        }
    }
}
