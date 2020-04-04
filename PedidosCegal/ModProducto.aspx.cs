using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.Enity;

namespace PedidosCegal
{
    public partial class ModProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                llenarcombo();
                cargar();
            }
        }
        void llenarcombo()
        {
            Util.Helper.ListarFamilia(ddlfamilia);
            Util.Helper.ListarIGV(ddligv);
            Util.Helper.ListarMarca(ddlmarca);
            Util.Helper.ListarUnidad(ddlunidadmedida);
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
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            ProductoDAO db = new ProductoDAO();
            Producto pro = new Producto();
            pro.Id_prod = Convert.ToInt32(txtcodpro.Text);
            pro.descripcion = txtdescripcion.Text;
            pro.IdAfectoIGV = Convert.ToInt32(ddligv.SelectedValue);
            pro.PesoKilos = Convert.ToDecimal(txtpeso.Text);
            pro.PCompraD = Convert.ToDecimal(txtpreciocomprad.Text);
            pro.PComprasS =Convert.ToDecimal( txtpreciocompras.Text);
            pro.PVentaD = Convert.ToDecimal(txtprecioventad.Text);
            pro.PVentaS = Convert.ToDecimal(txtprecioventas.Text);
            pro.StockMax = Convert.ToInt32(txtstockmax.Text);
            pro.StockMin = Convert.ToInt32(txtstockmin.Text);
            pro.StockAct = Convert.ToInt32(txtstockact.Text);
            pro.IdMarca = Convert.ToInt32(ddlmarca.SelectedValue);
            pro.Id_Familia = Convert.ToInt32(ddlfamilia.SelectedValue);
            pro.IdMedida = Convert.ToInt32(ddlunidadmedida.SelectedValue);
            pro.Observacion = txtobservacion.Text;
            db.update(pro);
            lblmesaje.Text = "El producto se actulizo correctamente.";
        }
    }
}