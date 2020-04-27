using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class ModZona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                lblmesaje.Text = "";
                cargarzona();
            }
        }
        void cargarzona()
        {
            int id = Convert.ToInt32(Request.QueryString["IDZ"]);
            ZonasDAO db = new ZonasDAO();
            zonas zon = db.BuscarZona(id);
            txtcodigo.Text = zon.DescripCorta.ToString();
            txtdescripcion.Text = zon.DescripLarga.ToString();
            txtobservacion.Text = zon.Observacion.ToString();
            txtid.Text = zon.IdZona.ToString();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            ZonasDAO db = new ZonasDAO();
            zonas zon = new zonas();
            zon.IdZona = Convert.ToInt32(txtid.Text);
            zon.DescripCorta = txtcodigo.Text;
            zon.DescripLarga = txtdescripcion.Text;
            zon.Observacion = txtobservacion.Text;
            db.update(zon);
            Response.Redirect("ManteZonas.aspx", true);
        }
    }
}