using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class ManteMarcas : System.Web.UI.Page
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
            MarcaDAO db = new MarcaDAO();
            grvmarcas.DataSource = db.Listar();
            grvmarcas.DataBind();
        }

        protected void grvmarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            int idmarca = Convert.ToInt32(grvmarcas.Rows[fila].Cells[0].Text);
            if (e.CommandName == "Modificar")
            {
                Response.Redirect("~/ModMarca.aspx?IDMA=" + idmarca, true);
            }
            else if (e.CommandName == "Ver")
            {
                Response.Redirect("VerMarca.aspx?IDMA=" + idmarca, true);
            }
            else if (e.CommandName == "Eliminar")
            {
                MarcaDAO db = new MarcaDAO();
                db.Eliminar(idmarca);
                cargar();
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
        }

        protected void grvmarcas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvmarcas.PageIndex = e.NewPageIndex;
            cargar();
        }
    }
}