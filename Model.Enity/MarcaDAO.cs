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

        public void Create(Marcas zon)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            try
            {
                comando = new SqlCommand("usp_MarcaInsert", con);
                comando.Parameters.AddWithValue("@Descripcion", zon.Descripcion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public bool ExisteMarca(string text)
        {
            bool existe = true;
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string proce = "select * from Marcas where Descripcion='" + text + "'";
            try
            {
                comando = new SqlCommand(proce, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                existe = reader.Read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return existe;
        }

        public void update(Marcas zon)
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            try
            {
                comando = new SqlCommand("usp_UpdateMarca", con);
                comando.Parameters.AddWithValue("@Id_Marca", zon.Id_Marca);
                comando.Parameters.AddWithValue("@Descripcion", zon.Descripcion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public Marcas BuscarMarca(int id)
        {
            Marcas zon = new Marcas();
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            string find = "select*from Marcas where Id_Marca='" + id + "'";
            try
            {
                comando = new SqlCommand(find, con);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    zon.Id_Marca = Convert.ToInt32(reader[0].ToString());
                    zon.Descripcion = reader[1].ToString();
                }
                return zon;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void Eliminar(int idmarca)
        {
            string eliminar = "delete from Marcas where Id_Marca='" + idmarca + "'";
            try
            {
                string cnx = db.Database.Connection.ConnectionString;
                con = new SqlConnection(cnx);
                comando = new SqlCommand(eliminar, con);
                con.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
