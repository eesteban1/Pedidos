using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class ManteProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                cargar();
            }
        }
        private void cargar()
        {
            ProductoDAO db = new ProductoDAO();
            grvmanteproducto.DataSource = db.ListarProducto();
            grvmanteproducto.DataBind();
        }

        protected void grvmanteproducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvmanteproducto.PageIndex = e.NewPageIndex;
            cargar();
        }

        protected void grvmanteproducto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            int idpro = Convert.ToInt32(grvmanteproducto.Rows[fila].Cells[0].Text);
            if (e.CommandName == "Modificar")
            {
                Response.Redirect("~/ModProducto.aspx?IDP=" + idpro, true);
            }
            else if (e.CommandName == "Eliminar")
            {
                ProductoDAO db = new ProductoDAO();
                db.Eliminar(idpro);
                cargar();
            }
        }
    }
}