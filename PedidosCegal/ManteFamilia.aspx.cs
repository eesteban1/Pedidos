using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class ManteFamilia : System.Web.UI.Page
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
            FamiliaDAO db = new FamiliaDAO();
            grvfamilia.DataSource = db.Listar();
            grvfamilia.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            int idfamilia = Convert.ToInt32(grvfamilia.Rows[fila].Cells[0].Text);
            if (e.CommandName == "Modificar")
            {
                Response.Redirect("~/ModFamilia.aspx?IDF=" + idfamilia, true);
            }
            else if (e.CommandName == "Ver")
            {
                Response.Redirect("VerFamilia.aspx?IDF=" + idfamilia, true);
            }
            else if (e.CommandName == "Eliminar")
            {
                FamiliaDAO db = new FamiliaDAO();
                db.Eliminar(idfamilia);
                cargar();
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvfamilia.PageIndex = e.NewPageIndex;
            cargar();
        }
    }
}