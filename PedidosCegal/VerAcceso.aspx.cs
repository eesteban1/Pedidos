using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class VerAcceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarcombo();
                txtcodigo.Text = Request.QueryString["IDACCESO"];
                cargarpersonal();
            }
        }
        void cargarcombo()
        {
            Util.Helper.ListarPersonal(ddlpersonal);
        }

        void cargarpersonal()
        {
            //txtcodigo.Text = Request.QueryString["IDACCESO"];
            int codigo = Convert.ToInt32(txtcodigo.Text);
            AccesoDAO db = new AccesoDAO();
            Accesos acc = db.BuscarAcceso(codigo);
            ddlpersonal.SelectedValue = acc.Id_Personal.ToString();
            txtusuario.Text = acc.Usuario;
            txtclave.Text = acc.Clave;
        }
       
    }
}