using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class salida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("NombreUsuario");
            Session.Remove("IDUsuario");
            Session.Remove("CargoUsuario");
            Response.Redirect("Login.aspx", true);
        }
    }
}