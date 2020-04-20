using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class MantePedido : System.Web.UI.Page
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
            PedidoDAO db = new PedidoDAO();
            grvDetalles.DataSource = db.ListarPedidos();
            grvDetalles.DataBind();

        }

        protected void grvDetalles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDetalles.PageIndex = e.NewPageIndex;
            cargar();
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            PedidoDAO db = new PedidoDAO();
            string fi = txtfechainicia.Text;
            string ff = txtfechafinal.Text;
            if(fi.Length > 0 && ff.Length > 0)
            {
                grvDetalles.DataSource = db.ListarPedidosFecha(fi, ff);
                grvDetalles.DataBind();
            }
            else
            {
                //txtmensaje.Text = "Debe introducir un rango de fecha.";
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "mensaje", "openModal();", true);

                string script = @"<script type='text/javascript'>
                            alert('Debe introducir un rango de fecha.');
                        </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
           
        }

        protected void grvDetalles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Eliminar")
            {
                int id = Convert.ToInt32(grvDetalles.Rows[0].Cells.ToString());
                PedidoDAO db = new PedidoDAO();
                db.Eliminar(id);
                cargar();
            }
            else if (e.CommandName == "Ver")
            {
                int id = Convert.ToInt32(grvDetalles.Rows[fila].Cells[0].Text);
                Response.Redirect("VerPedido.aspx?IDV=" + id, true);
            }
        }

        

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pedido.aspx", true);
        }
    }
}