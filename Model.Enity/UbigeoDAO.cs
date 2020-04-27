using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class UbigeoDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;

        public List<UBIGEO> ListarDepartamento()
        {
            string findAll = "select*from v_Departamento order by DEPARTAM";
            List<UBIGEO> listapro = new List<UBIGEO>();
            try
            {
                
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand(findAll, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    UBIGEO objpro = new UBIGEO();
                    objpro.UBIGEO1 = reader[0].ToString();
                    objpro.DEPARTAM = reader[1].ToString();
                    listapro.Add(objpro);

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

            return listapro;
        }

        public List<UBIGEO> ListarProvincia(string id)
        {
            string findAll = "select*from v_Provincia where IdDepartamento='"+id+ "'order by PROVINCIA";
            List<UBIGEO> listapro = new List<UBIGEO>();
            try
            {

                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand(findAll, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    UBIGEO objpro = new UBIGEO();
                    objpro.UBIGEO1 = reader[0].ToString();
                    objpro.PROVINCIA = reader[1].ToString();
                    listapro.Add(objpro);

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

            return listapro;
        }

        public List<UBIGEO> ListarDistrito(string idprovi, string iddepacomer)
        {
            string findAll = "select*from v_Distrito where IdProvincia='" + idprovi + "'and IdDepartamento='"+ iddepacomer + "'order by DISTRITO";
            List<UBIGEO> listapro = new List<UBIGEO>();
            try
            {

                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand(findAll, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    UBIGEO objpro = new UBIGEO();
                    objpro.UBIGEO1 = reader[0].ToString();
                    objpro.DISTRITO = reader[1].ToString();
                    listapro.Add(objpro);

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

            return listapro;
        }
    }
}
