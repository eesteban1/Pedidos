using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                lblnombre.Text = Session["NombreUsuario"].ToString();
                lblcargo.Text = Session["CargoUsuario"].ToString();
                string id = Session["IDUsuario"].ToString();
                //AsignaZonaDAO db = new AsignaZonaDAO();
                //string zona = db.BuscarZonaAsignada(id, out string idzona);
                //lblzona.Text = zona;
            }
        }
    }
}