using Model.Enity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class Pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblmesaje.Text = "";
                txtfecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                cargarDetalles();
                cargar();
                btnguardar.Enabled = false;
                btnguardar.CssClass = "btn btn-primary";
                btnguardar.Text = "Guardar Pedido";
                AsignaZonaDAO db = new AsignaZonaDAO();
                string id = Session["IDUsuario"].ToString();
                string zona = db.BuscarZonaAsignada(id, out string idzona);
                lblzona.Text = zona;
                MercadoDAO db1 = new MercadoDAO();
                ddlmercados.DataSource = db1.MercadoxZona(idzona);
                ddlmercados.DataTextField = "NombreLargo";
                ddlmercados.DataValueField = "IdMercado";
                ddlmercados.DataBind();
                ddlmercados.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
        }

        void cargar()
        {
            Util.Helper.Listarproductos(ddlproducto);
            
            Session["detalles"] = Util.Helper.CrearTemp_Detalles();
        }

        void cargarDetalles()
        {
            grvDetalles.DataSource = Session["detalles"];
            grvDetalles.DataBind();
        }

        void Limpiar()
        {
            txtcodcliente.Text = "";
            lbltotal.Text = "";
            lblnombre.Text = "";
            ddlmercados.SelectedValue = "0";
            ddlproducto.SelectedValue = "0";
            Session["detalles"] = Util.Helper.CrearTemp_Detalles();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                PedidoDAO db = new PedidoDAO();
                Encabezado en = new Encabezado();
                en.Id_cliente = Convert.ToInt32(txtcodcliente.Text);
                en.fechaCheque = txtfecha.Text;
                en.Id_Vendedor = Convert.ToInt32(Session["IDUsuario"]);
                en.Total_Venta = Convert.ToDecimal(lbltotal.Text);
                Int64 id = db.InsertarCabecera(en);
                Session["IDPEDIDO"] = id;
                foreach (GridViewRow fila in grvDetalles.Rows)
                {
                    Detalles det = new Detalles();
                    TextBox cantidad = (TextBox)fila.FindControl("txtcantidad");
                    det.Paquetes = Convert.ToInt32(cantidad.Text);
                    TextBox precio = (TextBox)fila.FindControl("txtprecio");
                    det.PrecioUnit = Convert.ToDouble(precio.Text);
                    TextBox peso = (TextBox)fila.FindControl("txtpeso");
                    det.CantidadKilos = Convert.ToDecimal(peso.Text);
                    det.Id_prod = Convert.ToInt32(fila.Cells[0].Text);
                    det.SubTotal = Convert.ToDecimal(fila.Cells[5].Text);
                    db.InsertarDetalles(det, id);
                }
                lblmesaje.Text = "El pedido se guardo con exito.";
                ddlmercados.Enabled = false;
                txtfecha.Enabled = false;
                txtcodcliente.Enabled = false;
                ddlproducto.Enabled = false;
                grvDetalles.Enabled = false;
                btnimprimir.Enabled = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoDAO db = new ProductoDAO();
            int idpro = Convert.ToInt32(ddlproducto.SelectedValue);
            Producto producto = db.BuscarProducto(idpro);
            DataTable detalles = (DataTable)Session["Detalles"];
            bool seEncuentra = false;
            int cod = producto.Id_prod;
            List<Producto> art = new List<Producto>();
            foreach (GridViewRow grv in grvDetalles.Rows)
            {
                Producto ar = new Producto();
                ar.Id_prod = Convert.ToInt32(grv.Cells[0].Text);
                art.Add(ar);
            }
            seEncuentra = art.Exists(x => x.Id_prod == cod);
            if (seEncuentra == false)
            {
                string id = Convert.ToString(producto.Id_prod);
                string Descripcion = producto.descripcion;
                decimal precio = Convert.ToDecimal(producto.PVentaS);
                decimal peso = Convert.ToDecimal(producto.PesoKilos);
                decimal cantidad = 1m;

                decimal subtotal = Math.Round(cantidad * precio, 2);
                Util.Helper.Agregar_Detalles(detalles, id, Descripcion, precio, cantidad, peso,subtotal);
                cargarDetalles();
                Session["Detalles"] = detalles;

                decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 5);
                lbltotal.Text = total.ToString();
                ddlproducto.SelectedValue = "0";
                btnguardar.Enabled = true;
            }
            else
            {
                string script = @"<script type='text/javascript'>
                            alert('El producto ya fue ingresado.');
                        </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }

        protected void txtcodcliente_TextChanged(object sender, EventArgs e)
        {
            ClienteDAO db = new ClienteDAO();
            int id = Convert.ToInt32(txtcodcliente.Text);
            Cliente clie = db.Buscarcliente(id);
            lblnombre.Text = clie.NombrePropietario; 
        }

        protected void grvDetalles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int fila = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Eliminar")
            {
                DataTable dtdetalles = (DataTable)Session["Detalles"];
                dtdetalles.Rows[fila].Delete();
                cargarDetalles();
                Session["Detalles"] = dtdetalles;
                decimal subtotal = Util.Helper.TotalizarGrilla(grvDetalles, 5);
                lbltotal.Text = subtotal.ToString();
            }
        }

        protected void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            DataTable dtdetalles = (DataTable)Session["detalles"];
            TextBox txt = (TextBox)currentRow.FindControl("txtcantidad");
            TextBox pre = (TextBox)currentRow.FindControl("txtprecio");
            TextBox pes = (TextBox)currentRow.FindControl("txtpeso");
            decimal precio = Math.Round(Convert.ToDecimal(pre.Text), 2);
            decimal peso = Math.Round(Convert.ToDecimal(pes.Text), 2);
            int dcantidad = Convert.ToInt32(txt.Text);
            decimal subtotal = dcantidad * precio ;
            dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
            dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
            dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
            dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
            Session["detalles"] = dtdetalles;
            cargarDetalles();
            decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 5);
            lbltotal.Text = total.ToString();
        }

        protected void txtpeso_TextChanged(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            DataTable dtdetalles = (DataTable)Session["detalles"];
            TextBox txt = (TextBox)currentRow.FindControl("txtcantidad");
            TextBox pre = (TextBox)currentRow.FindControl("txtprecio");
            TextBox pes = (TextBox)currentRow.FindControl("txtpeso");
            decimal precio = Math.Round(Convert.ToDecimal(pre.Text), 2);
            decimal peso = Math.Round(Convert.ToDecimal(pes.Text), 2);
            int dcantidad = Convert.ToInt32(txt.Text);
            decimal subtotal = dcantidad * precio ;
            dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
            dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
            dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
            dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
            Session["detalles"] = dtdetalles;
            cargarDetalles();
            decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 5);
            lbltotal.Text = total.ToString();
        }

        protected void txtprecio_TextChanged(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            DataTable dtdetalles = (DataTable)Session["detalles"];
            TextBox txt = (TextBox)currentRow.FindControl("txtcantidad");
            TextBox pre = (TextBox)currentRow.FindControl("txtprecio");
            TextBox pes = (TextBox)currentRow.FindControl("txtpeso");
            decimal precio = Math.Round(Convert.ToDecimal(pre.Text), 2);
            decimal peso = Math.Round(Convert.ToDecimal(pes.Text), 2);
            int dcantidad = Convert.ToInt32(txt.Text);
            decimal subtotal = Math.Round(dcantidad * precio,2);
            dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
            dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
            dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
            dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
            Session["detalles"] = dtdetalles;
            cargarDetalles();
            decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 5);
            lbltotal.Text = total.ToString();
            
        }

        protected void btnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnguardar.Enabled = false;
            btnguardar.CssClass = "btn btn-primary";
            btnguardar.Text = "Guardar Pedido";
            ddlmercados.Enabled = true;
            txtfecha.Enabled = true;
            txtcodcliente.Enabled = true;
            ddlproducto.Enabled = true;
            grvDetalles.Enabled = true;
            lblmesaje.Text = "";
        }

        protected void btnimprimir_Click(object sender, EventArgs e)
        {
            string ID = Session["IDPEDIDO"].ToString();
            string sRuta = "Reportes/ReporteFactura.aspx?Id_Encabe=" + ID ;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Window1", "<script> window.open('" + sRuta + "');</script>", false);
        }

        protected void ddlclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtcodcliente.Text = ddlclientes.SelectedValue;
            ClienteDAO db = new ClienteDAO();
            int id = Convert.ToInt32(txtcodcliente.Text);
            Cliente clie = db.Buscarcliente(id);
            lblnombre.Text = clie.NombrePropietario;
        }

        protected void ddlmercados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ddlmercados.SelectedValue;
            Util.Helper.ListarClientesxMerZon(ddlclientes, id);
        }
    }
}