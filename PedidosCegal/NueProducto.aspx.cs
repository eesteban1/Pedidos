using Model.Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class NueProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                llenarcombo();
            }
        }
        void llenarcombo()
        {
            Util.Helper.ListarFamilia(ddlfamilia);
            Util.Helper.ListarIGV(ddligv);
            Util.Helper.ListarMarca(ddlmarca);
            Util.Helper.ListarUnidad(ddlunidadmedida);
        }
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            ProductoDAO db = new ProductoDAO();
            Producto pro = new Producto();
            pro.IdAfectoIGV = Convert.ToInt32(ddligv.SelectedValue);
            pro.Id_Familia = Convert.ToInt32(ddlfamilia.SelectedValue);
            pro.descripcion = txtdescripcion.Text;
            pro.IdMarca = Convert.ToInt32(ddlmarca.SelectedValue);
            pro.IdMedida = Convert.ToInt32(ddlunidadmedida.SelectedValue);
            pro.PesoKilos = Convert.ToDecimal(txtpeso.Text);
            pro.PCompraD = Convert.ToDecimal(txtpreciocomprad.Text);
            pro.PComprasS = Convert.ToDecimal(txtpreciocompras.Text);
            pro.PVentaD = Convert.ToDecimal(txtprecioventad.Text);
            pro.PVentaS = Convert.ToDecimal(txtprecioventas.Text);
            pro.StockMax = Convert.ToInt32(txtstockmax.Text);
            pro.StockMin = Convert.ToInt32(txtstockmin.Text);
            pro.StockAct = Convert.ToInt32(txtstockact.Text);
            pro.Observacion = txtobservacion.Text;
            db.CrearProducto(pro);
            lblmesaje.Text = "El producto se registro correctamente.";
        }
    }
}