using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class VerFamili : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                cargarfamilia();
            }
        }
        void cargarfamilia()
        {
            int id = Convert.ToInt32(Request.QueryString["IDF"]);
            FamiliaDAO db = new FamiliaDAO();
            Familia zon = db.BuscarFamilia(id);
            txtcodigo.Text = zon.Id_Familia.ToString();
            txtdescripcion.Text = zon.Nombre.ToString();
            txtid.Text = zon.Id_Familia.ToString();
        }
    }
}