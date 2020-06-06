using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class MantePersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargar();
            }
        }
        private void cargar()
        {
            PersonalDAO db = new PersonalDAO();
            grvmante.DataSource = db.ListarPersonal();
            grvmante.DataBind();
        }

        protected void grvmante_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvmante.PageIndex = e.NewPageIndex;
            cargar();
        }

        protected void grvmante_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            int idpersonal = Convert.ToInt32(grvmante.Rows[fila].Cells[0].Text);
            if(e.CommandName == "Modificar")
            {
                Response.Redirect("~/ModPersonal.aspx?IDPERSONA=" + idpersonal, true);
            }
            else if(e.CommandName=="Ver")
            {
                Response.Redirect("VerPersonal.aspx?IDPERSONA=" + idpersonal, true);
            }
            else if(e.CommandName=="Eliminar")
            {
                PersonalDAO db = new PersonalDAO();
                string mensaje = db.Eliminar(idpersonal,out string error);
                if(mensaje.Length == 0)
                {
                    cargar();
                }
                else
                {
                    mensajeerror();
                }
                
            }
        }

        void mensajeerror()
        {
            string script = "openModal();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "error", script, true);
        }


    }
}