using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enity
{
    public class UniMedDAO
    {
        SqlConnection con = null;
        ventas2Entities db = new ventas2Entities();
        private SqlCommand comando;
        private SqlDataReader reader;

        public List<UniMed> Listar()
        {
            string cnx = db.Database.Connection.ConnectionString;
            con = new SqlConnection(cnx);
            List<UniMed> listaUniMed = new List<UniMed>();
            string find = "select*from UniMed order by Descripcion asc";
            try
            {
                comando = new SqlCommand(find, con);
                con.Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    UniMed objUniMed = new UniMed();
                    objUniMed.Id_Umedida = Convert.ToInt32(reader[0].ToString());
                    objUniMed.Simbolo = reader[1].ToString();
                    objUniMed.Descripcion = reader[2].ToString();
                    objUniMed.Medida = reader[3].ToString();
                    listaUniMed.Add(objUniMed);
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

            return listaUniMed;
        }
    }
}
