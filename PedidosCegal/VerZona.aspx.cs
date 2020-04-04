using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class VerZona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
    }
}