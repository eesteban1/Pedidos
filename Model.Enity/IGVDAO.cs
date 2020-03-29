using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class IGVDAO
    {

        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;

        public List<IGV> Listar()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            List<IGV> listaCargo = new List<IGV>();
            string find = "select*from IGV order by Nombre asc";
            try
            {
                comando = new SqlCommand(find, con);
                con.Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    IGV objCargos = new IGV();
                    objCargos.IdAfecto = Convert.ToInt32(reader[0].ToString());
                    objCargos.Nombre = reader[1].ToString();
                    objCargos.Valor = Convert.ToInt32(reader[2].ToString());
                    listaCargo.Add(objCargos);

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

            return listaCargo;
        }
    }
}
