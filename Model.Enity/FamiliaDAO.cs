using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class FamiliaDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;

        public object Listar()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);

            List<Familia> listaFamilia = new List<Familia>();
                string findAll = "select*from Familia order by Nombre asc";
                try
                {
                    comando = new SqlCommand(findAll, con);
                    con.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Familia objFamilia = new Familia();
                        objFamilia.Id_Familia = Convert.ToInt32(reader[0].ToString());
                        objFamilia.Nombre = reader[1].ToString();
                        listaFamilia.Add(objFamilia);

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

                return listaFamilia;

            }
        
    }
}
