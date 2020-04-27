using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class ManteZonas : System.Web.UI.Page
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
            ZonasDAO db = new ZonasDAO();
            grvmantezona.DataSource = db.ListarmanteZonas();
            grvmantezona.DataBind();
        }

        protected void grvmantezona_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvmantezona.PageIndex = e.NewPageIndex;
            cargar();
        }

        protected void grvmantezona_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            int idzona = Convert.ToInt32(grvmantezona.Rows[fila].Cells[0].Text);
            if (e.CommandName == "Modificar")
            {
                Response.Redirect("~/ModZona.aspx?IDZ=" + idzona, true);
            }
            else if(e.CommandName=="Ver")
            {
                Response.Redirect("VerZona.aspx?IDZ=" + idzona, true);
            }
            else if (e.CommandName == "Eliminar")
            {
                ZonasDAO db = new ZonasDAO();
                db.Eliminar(idzona);
                cargar();
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
        }
    }
}