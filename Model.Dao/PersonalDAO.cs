using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enity;

namespace Model.Dao
{
    public class PersonalDAO
    {
        ventas2Entities db = new ventas2Entities();
        public bool Ingreso(Accesos ac, out string nombre)
        {
            bool hay;
            string Ingresar = "select* from v_Acc where Usuario='" + ac.Usuario + "' and " + " Clave='" + ac.Clave + "'";
            try
            {
                SqlCommand comando = new SqlCommand(Ingresar,);
            }
        }
    }
}
