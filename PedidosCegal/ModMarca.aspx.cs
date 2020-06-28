using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class ModMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                cargarmarca();
            }
        }

        void cargarmarca()
        {
            int id = Convert.ToInt32(Request.QueryString["IDMA"]);
            MarcaDAO db = new MarcaDAO();
            Marcas mar = db.BuscarMarca(id);
            txtcodigo.Text = mar.Id_Marca.ToString();
            txtdescripcion.Text = mar.Descripcion.ToString();
            txtid.Text = mar.Id_Marca.ToString();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            MarcaDAO db = new MarcaDAO();
            Marcas zon = new Marcas();
            zon.Id_Marca = Convert.ToInt32(txtid.Text);
            zon.Descripcion = txtdescripcion.Text;
            db.update(zon);
            Response.Redirect("ManteMarcas.aspx", true);
        }
    }
}