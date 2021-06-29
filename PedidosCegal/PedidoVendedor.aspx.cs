using Model.Enity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosCegal
{
    public partial class PedidoVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(Session["NO"] != null)
                {
                    btnguardar.Enabled = false;
                }
                txtfecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                cargar();
                cargarDetalles();
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
                txtnumeropuesto.Enabled = false;
                ddlclientes.Enabled = false;
            }
        }

        void cargar()
        {

            Util.Helper.Listarproductos(ddlproducto);
            Util.Helper.Listarmoneda(ddlmoneda);
            Util.Helper.ListarFormaPago(ddlformapago);
            ddlmoneda.SelectedValue = "1";
            Session["detalles"] = Util.Helper.CrearTemp_Detalles();
        }

        void cargarDetalles()
        {
            grvDetalles.DataSource = Session["detalles"];
            grvDetalles.DataBind();
        }

        void Limpiar()
        {
            txtnumeropuesto.Text = "";
            lbltotal.Text = "";
            lblnombre.Text = "";
            Session["detalles"] = Util.Helper.CrearTemp_Detalles();
            ddlproducto.SelectedValue = "0";
            ddlmercados.SelectedValue = "0";
            ddlclientes.SelectedValue = "0";
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            PedidoDAO db = new PedidoDAO();
            Encabezado en = new Encabezado();
            if(lblzona.Text.Length==0)
            {
                txtmensaje.Text = "No se puede guardar el pedido porque no tiene una zona para hoy.";
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
            }
            else
            {
                try
                {
                    en.Id_cliente = Convert.ToInt32(ddlclientes.SelectedValue);
                    en.fechaCheque = txtfecha.Text;
                    en.Id_Vendedor = Convert.ToInt32(Session["IDUsuario"]);
                    en.Total_Venta = Convert.ToDecimal(lbltotal.Text);
                    en.Id_Moneda = Convert.ToInt32(ddlmoneda.SelectedValue);
                    en.Id_FormaPago = Convert.ToInt32(ddlformapago.SelectedValue);
                    en.IGV = Convert.ToDecimal(lbligv.Text);
                    Int64 id = db.InsertarCabecera(en);
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
                        det.IGV = Convert.ToDecimal(fila.Cells[5].Text);
                        det.SubTotal = Convert.ToDecimal(fila.Cells[6].Text);
                        db.InsertarDetalles(det, id);
                    }
                    Response.Redirect("MantePedidoVendedor.aspx", true);
                }
                catch (Exception ex)
                {
                    txtmensaje.Text = ex.Message;
                    string script = "openModal();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
                }
            }
            
        }

        protected void ddlproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoDAO db = new ProductoDAO();
            int idpro = Convert.ToInt32(ddlproducto.SelectedValue);
            Producto producto = db.BuscarProducto(idpro);
            DataTable detalles = (DataTable)Session["Detalles"];
            bool seEncuentra = false;
            int cod = Convert.ToInt32(producto.Id_prod);
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
                int afecto = Convert.ToInt32(producto.IdAfectoIGV);
                decimal igv = 0.00m;
                if (afecto == 1)
                {
                    igv = 0.18m;
                }
                decimal cantidad = 1m;
                if (precio <= 15)
                {
                    decimal subtotal = Math.Round(cantidad * precio * peso, 2);
                    decimal igvsub = subtotal - Math.Round(subtotal / (1 + igv), 2);
                    Util.Helper.Agregar_Detalles(detalles, id, Descripcion, precio, cantidad, peso, igvsub, subtotal);
                    cargarDetalles();
                    Session["Detalles"] = detalles;
                    if (igv == 0.18m)
                    {
                        decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 6);
                        decimal totaligv = Util.Helper.TotalizarGrilla(grvDetalles, 5);
                        lbligv.Text = totaligv.ToString();
                        lbltotal.Text = total.ToString();
                    }
                    else
                    {
                        decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 6);
                        lbltotal.Text = total.ToString();
                    }
                    //decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 5);

                    ddlproducto.SelectedValue = "0";
                    btnguardar.Enabled = true;
                    txtcodproducto.Text = "";
                }
                else
                {
                    decimal subtotal = Math.Round(cantidad * precio, 2);
                    decimal igvsub = subtotal - Math.Round(subtotal / (1 + igv), 2);
                    Util.Helper.Agregar_Detalles(detalles, id, Descripcion, precio, cantidad, peso, igvsub, subtotal);
                    cargarDetalles();
                    Session["Detalles"] = detalles;
                    if (igv == 0.18m)
                    {
                        decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 6);
                        decimal totaligv = Util.Helper.TotalizarGrilla(grvDetalles, 5);
                        lbligv.Text = totaligv.ToString();
                        lbltotal.Text = total.ToString();
                    }
                    else
                    {
                        decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 6);
                        lbltotal.Text = total.ToString();
                    }
                    //decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 5);

                    ddlproducto.SelectedValue = "0";
                    btnguardar.Enabled = true;
                    txtcodproducto.Text = "";
                }
            }
            else
            {
                txtmensaje.Text = "El producto ya fue ingresado.";
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
                txtcodproducto.Text = "";
            }
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
                decimal subtotal = Util.Helper.TotalizarGrilla(grvDetalles, 6);
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
            decimal igv = Convert.ToDecimal(currentRow.Cells[5].Text);
            if (precio <= 15)
            {
                if (igv == 0)
                {
                    decimal subtotal = Math.Round(dcantidad * precio * peso, 2);
                    decimal subigv = Math.Round(subtotal - (subtotal / (1 + igv)), 2);
                    dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
                    dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
                    dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
                    dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
                    dtdetalles.Rows[currentRow.RowIndex]["igvsub"] = subigv;
                }
                else
                {
                    decimal subtotal = Math.Round(dcantidad * precio * peso, 2);
                    decimal subigv = Math.Round(subtotal - (subtotal / 1.18m), 2);
                    dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
                    dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
                    dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
                    dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
                    dtdetalles.Rows[currentRow.RowIndex]["igvsub"] = subigv;
                }
            }
            else
            {
                if (igv == 0)
                {
                    decimal subtotal = Math.Round(dcantidad * precio, 2);
                    decimal subigv = Math.Round(subtotal - (subtotal / (1 + igv)), 2);
                    dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
                    dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
                    dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
                    dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
                    dtdetalles.Rows[currentRow.RowIndex]["igv"] = subigv;
                }
                else
                {
                    decimal subtotal = Math.Round(dcantidad * precio, 2);
                    decimal subigv = Math.Round(subtotal - (subtotal / 1.18m), 2);
                    dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
                    dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
                    dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
                    dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
                    dtdetalles.Rows[currentRow.RowIndex]["igv"] = subigv;
                }
            }
            Session["detalles"] = dtdetalles;
            cargarDetalles();
            decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 6);
            decimal igvtotal = Util.Helper.TotalizarGrilla(grvDetalles, 5);
            lbligv.Text = igvtotal.ToString();
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
            decimal igv = Convert.ToDecimal(currentRow.Cells[5].Text);
            if (precio <= 15)
            {
                if (igv == 0)
                {
                    decimal subtotal = Math.Round(dcantidad * precio * peso, 2);
                    decimal subigv = Math.Round(subtotal - (subtotal / (1 + igv)), 2);
                    dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
                    dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
                    dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
                    dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
                    dtdetalles.Rows[currentRow.RowIndex]["igvsub"] = subigv;
                }
                else
                {
                    decimal subtotal = Math.Round(dcantidad * precio * peso, 2);
                    decimal subigv = Math.Round(subtotal - (subtotal / 1.18m), 2);
                    dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
                    dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
                    dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
                    dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
                    dtdetalles.Rows[currentRow.RowIndex]["igvsub"] = subigv;
                }
            }
            else
            {
                if (igv == 0)
                {
                    decimal subtotal = Math.Round(dcantidad * precio, 2);
                    decimal subigv = Math.Round(subtotal - (subtotal / (1 + igv)), 2);
                    dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
                    dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
                    dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
                    dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
                    dtdetalles.Rows[currentRow.RowIndex]["igv"] = subigv;
                }
                else
                {
                    decimal subtotal = Math.Round(dcantidad * precio, 2);
                    decimal subigv = Math.Round(subtotal - (subtotal / 1.18m), 2);
                    dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
                    dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
                    dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
                    dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
                    dtdetalles.Rows[currentRow.RowIndex]["igv"] = subigv;
                }
            }
            Session["detalles"] = dtdetalles;
            cargarDetalles();
            decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 6);
            decimal igvtotal = Util.Helper.TotalizarGrilla(grvDetalles, 5);
            lbligv.Text = igvtotal.ToString();
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
            decimal igv = Convert.ToDecimal(currentRow.Cells[5].Text);
            if (precio <= 15)
            {
                if (igv == 0)
                {
                    decimal subtotal = Math.Round(dcantidad * precio * peso, 2);
                    decimal subigv = Math.Round(subtotal - (subtotal / (1 + igv)), 2);
                    dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
                    dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
                    dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
                    dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
                    dtdetalles.Rows[currentRow.RowIndex]["igvsub"] = subigv;
                }
                else
                {
                    decimal subtotal = Math.Round(dcantidad * precio * peso, 2);
                    decimal subigv = Math.Round(subtotal - (subtotal / 1.18m), 2);
                    dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
                    dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
                    dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
                    dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
                    dtdetalles.Rows[currentRow.RowIndex]["igvsub"] = subigv;
                }
            }
            else
            {
                if (igv == 0)
                {
                    decimal subtotal = Math.Round(dcantidad * precio, 2);
                    decimal subigv = Math.Round(subtotal - (subtotal / (1 + igv)), 2);
                    dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
                    dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
                    dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
                    dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
                    dtdetalles.Rows[currentRow.RowIndex]["igv"] = subigv;
                }
                else
                {
                    decimal subtotal = Math.Round(dcantidad * precio, 2);
                    decimal subigv = Math.Round(subtotal - (subtotal / 1.18m), 2);
                    dtdetalles.Rows[currentRow.RowIndex]["PrecioUnidad"] = precio;
                    dtdetalles.Rows[currentRow.RowIndex]["Cantidad"] = dcantidad;
                    dtdetalles.Rows[currentRow.RowIndex]["SubTotal"] = subtotal;
                    dtdetalles.Rows[currentRow.RowIndex]["Peso"] = peso;
                    dtdetalles.Rows[currentRow.RowIndex]["igv"] = subigv;
                }
            }
            Session["detalles"] = dtdetalles;
            cargarDetalles();
            decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 6);
            decimal igvtotal = Util.Helper.TotalizarGrilla(grvDetalles, 5);
            lbligv.Text = igvtotal.ToString();
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
            ddlclientes.Enabled = true;
            ddlproducto.Enabled = true;
            grvDetalles.Enabled = true;
            lblmesaje.Text = "";
            txtnumeropuesto.Enabled = false;
            ddlclientes.Enabled = false;
        }

        protected void txtcodproducto_TextChanged(object sender, EventArgs e)
        {
            if(txtcodproducto.Text.Length>0)
            {
                ProductoDAO db = new ProductoDAO();
                int idpro = Convert.ToInt32(txtcodproducto.Text);
                Producto pro = db.BuscarProducto(idpro);
                if(pro.Id_prod != 0)
                {
                    DataTable detalles = (DataTable)Session["Detalles"];
                    bool seEncuentra = false;
                    int cod = Convert.ToInt32(pro.Id_prod);
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
                        string id = Convert.ToString(pro.Id_prod);
                        string Descripcion = pro.descripcion;
                        decimal precio = Convert.ToDecimal(pro.PVentaS);
                        decimal peso = Convert.ToDecimal(pro.PesoKilos);
                        int afecto = Convert.ToInt32(pro.IdAfectoIGV);
                        decimal igv = 0.00m;
                        if (afecto == 1)
                        {
                            igv = 0.18m;
                        }
                        decimal cantidad = 1m;
                        if (precio <= 15)
                        {
                            decimal subtotal = Math.Round(cantidad * precio * peso, 2);
                            decimal igvsub = subtotal - Math.Round(subtotal / (1 + igv), 2);
                            Util.Helper.Agregar_Detalles(detalles, id, Descripcion, precio, cantidad, peso, igvsub, subtotal);
                            cargarDetalles();
                            Session["Detalles"] = detalles;
                            if (igv == 0.18m)
                            {
                                decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 6);
                                decimal totaligv = Util.Helper.TotalizarGrilla(grvDetalles, 5);
                                lbligv.Text = totaligv.ToString();
                                lbltotal.Text = total.ToString();
                            }
                            else
                            {
                                decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 6);
                                lbltotal.Text = total.ToString();
                            }
                            //decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 5);

                            ddlproducto.SelectedValue = "0";
                            btnguardar.Enabled = true;
                            txtcodproducto.Text = "";
                        }
                        else
                        {
                            decimal subtotal = Math.Round(cantidad * precio, 2);
                            decimal igvsub = subtotal - Math.Round(subtotal / (1 + igv), 2);
                            Util.Helper.Agregar_Detalles(detalles, id, Descripcion, precio, cantidad, peso, igvsub, subtotal);
                            cargarDetalles();
                            Session["Detalles"] = detalles;
                            if (igv == 0.18m)
                            {
                                decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 6);
                                decimal totaligv = Util.Helper.TotalizarGrilla(grvDetalles, 5);
                                lbligv.Text = totaligv.ToString();
                                lbltotal.Text = total.ToString();
                            }
                            else
                            {
                                decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 6);
                                lbltotal.Text = total.ToString();
                            }
                            //decimal total = Util.Helper.TotalizarGrilla(grvDetalles, 5);

                            ddlproducto.SelectedValue = "0";
                            btnguardar.Enabled = true;
                            txtcodproducto.Text = "";
                        }
                    }
                    else
                    {
                        txtmensaje.Text = "El producto ya fue ingresado.";
                        string script = "openModal();";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
                        txtcodproducto.Text = "";
                    }
                }
                else
                {
                    txtmensaje.Text = "El producto no existe.";
                    string script = "openModal();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
                    txtcodproducto.Text = "";
                }
               
            }
            else
            {
                txtmensaje.Text = "Debe poner el código del producto.";
                string script = "openModal();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, true);
                txtcodproducto.Text = "";
            }
            
        }

        protected void ddlmercados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ddlmercados.SelectedValue;
            Util.Helper.ListarClientesxMerZon(ddlclientes, id);
            txtnumeropuesto.Enabled = true;
            ddlclientes.Enabled = true;
            txtnumeropuesto.Text = "";
        }

        protected void txtnumeropuesto_TextChanged(object sender, EventArgs e)
        {
            ClienteDAO db = new ClienteDAO();
            string numero = txtnumeropuesto.Text;
            string idmercado = ddlmercados.SelectedValue;
            Cliente clie = db.BuscarclientexPuesto(numero, idmercado);
            lblnombre.Text = clie.NombrePropietario;
            ddlclientes.SelectedValue = clie.Id_cliente.ToString();
        }

        protected void ddlclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClienteDAO db = new ClienteDAO();
            int id = Convert.ToInt32(ddlclientes.SelectedValue);
            Cliente clie = db.Buscarcliente(id, "");
            lblnombre.Text = clie.NombrePropietario;
            txtnumeropuesto.Text = clie.NumeroPuesto;
        }
    }
}