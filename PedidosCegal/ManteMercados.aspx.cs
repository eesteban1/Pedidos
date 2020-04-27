using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class ManteMercados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargar();
            }
        }

        void cargar()
        {
            MercadoDAO db = new MercadoDAO();
            grvmantemercado.DataSource = db.ListarMercados();
            grvmantemercado.DataBind();
        }

        protected void grvmantemercado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            int idmer = Convert.ToInt32(grvmantemercado.Rows[fila].Cells[0].Text);
            if (e.CommandName == "Modificar")
            {
                Response.Redirect("~/ModMercado.aspx?IDM=" + idmer, true);
            }
            else if (e.CommandName == "Ver")
            {
                Response.Redirect("~/VerMercado.aspx?IDM=" + idmer, true);
            }
            else if (e.CommandName == "Eliminar")
            {
                
                    MercadoDAO db = new MercadoDAO();
                    db.Eliminar(idmer);
                    cargar();
                    string script = "openModal();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "correcto", script, true);
            }
        }

        protected void grvmantemercado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvmantemercado.PageIndex = e.NewPageIndex;
            cargar();
        }
    }
}