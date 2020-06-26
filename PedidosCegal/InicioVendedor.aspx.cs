using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class InicioVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Session["IDUsuario"] != null)
                {
                    lblnombre.Text = Session["NombreUsuario"].ToString();
                    lblcargo.Text = Session["CargoUsuario"].ToString();
                    string id = Session["IDUsuario"].ToString();
                    AsignaZonaDAO db = new AsignaZonaDAO();
                    string zona = db.BuscarZonaAsignada(id, out string idzona);
                    if (zona.Length > 0)
                    {
                        lblzona.Text = zona;
                    }
                    else
                    {
                        lblzona.Text = "Usted no tiene asigando una zona para el dia de hoy.";
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx?mensaje=1");
                }
            }
        }
    }
}