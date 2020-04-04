using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class VerProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenarcombo();
                cargar();
            }
        }

        void cargar()
        {
            int id = Convert.ToInt32(Request.QueryString["IDP"]);
            ProductoDAO db = new ProductoDAO();
            Producto pro = db.BuscarProducto(id);
            txtcodpro.Text = pro.Id_prod.ToString();
            ddlfamilia.SelectedValue = pro.Id_Familia.ToString();
            txtdescripcion.Text = pro.descripcion;
            ddlmarca.SelectedValue = pro.IdMarca.ToString();
            ddligv.SelectedValue = pro.IdAfectoIGV.ToString();
            ddlunidadmedida.SelectedValue = pro.IdMedida.ToString();
            txtpeso.Text = pro.PesoKilos.ToString();
            txtpreciocompras.Text = pro.PComprasS.ToString();
            txtpreciocomprad.Text = pro.PCompraD.ToString();
            txtprecioventas.Text = pro.PVentaS.ToString();
            txtprecioventad.Text = pro.PVentaD.ToString();
            txtstockmax.Text = pro.StockMax.ToString();
            txtstockmin.Text = pro.StockMax.ToString();
            txtstockact.Text = pro.StockAct.ToString();
            txtobservacion.Text = pro.Observacion;
        }

        void llenarcombo()
        {
            Util.Helper.ListarFamilia(ddlfamilia);
            Util.Helper.ListarIGV(ddligv);
            Util.Helper.ListarMarca(ddlmarca);
            Util.Helper.ListarUnidad(ddlunidadmedida);
        }
    }
}