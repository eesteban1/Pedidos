using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class ModFamilia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                cargar();
            }
        }

        void cargar()
        {
            int id = Convert.ToInt32(Request.QueryString["IDF"]);
            FamiliaDAO db = new FamiliaDAO();
            Familia zon = db.BuscarFamilia(id);
            txtcodigo.Text = zon.Id_Familia.ToString();
            txtdescripcion.Text = zon.Nombre.ToString();
            txtid.Text = zon.Id_Familia.ToString();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            FamiliaDAO db = new FamiliaDAO();
            Familia fa = new Familia();
            fa.Id_Familia =Convert.ToInt32(txtid.Text);
            fa.Nombre = txtdescripcion.Text;
            db.update(fa);
            Response.Redirect("ManteFamilia.aspx", true);
        }
    }
}