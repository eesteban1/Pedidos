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
            ddlfamilia.SelectedValue = "1";
            ddlmarca.SelectedValue = "1";
        }
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            if ((txtpreciocomprad.Text.Length) < 1)
                txtpreciocomprad.Text = "0.00";
            if (txtpeso.Text.Length < 1)
                txtpeso.Text = "0.00";
            if (txtpreciocompras.Text.Length < 1)
                txtpreciocompras.Text = "0.00";
            if (txtprecioventad.Text.Length < 1)
                txtprecioventad.Text = "0.00";
            if (txtprecioventas.Text.Length < 1)
                txtprecioventas.Text = "0.00";
            if (txtstockmax.Text.Length < 1)
                txtstockmax.Text = "0";
            if (txtstockmin.Text.Length < 1)
                txtstockmin.Text = "0";
            if (txtstockact.Text.Length < 1)
                txtstockact.Text = "0";

            ProductoDAO db = new ProductoDAO();
            Producto pro = new Producto();
            if(txtcodigo.Text.Length>0)
            {
                pro = db.BuscarProducto(Convert.ToInt32(txtcodigo.Text));
                if(pro.descripcion == null)
                {
                    pro.Id_prod = Convert.ToInt32(txtcodigo.Text);
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
                    Response.Redirect("ManteProducto.aspx", true);
                }
                else
                {
                    Label1.Text = "El codigo ya existe.";
                    string script = "openModal();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "error", script, true);
                }
               
            }
            else
            {
                Label1.Text = "Debe poner un codigo al producto.";
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "error", script, true);
            }
            
        }
    }
}