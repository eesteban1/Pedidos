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
            grvmante.DataSource = db.ListarVendedor();
            grvmante.DataBind();
        }


    }
}