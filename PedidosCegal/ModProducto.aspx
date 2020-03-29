<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ModProducto.aspx.cs" Inherits="PedidosCegal.ModProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well well-sm text-primary text-center">
        <h2>Modificar Producto</h2>
    </div>

    <div class="form-horizontal">
        <fieldset>
            <div class="form-group">
                <label class="control-label col-md-2">Código: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtcodpro" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Familia: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlfamilia" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Marca: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlmarca" CssClass="form-control"></asp:DropDownList>
                 </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Descripción del producto: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtdescripcion" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Afecto IGV: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddligv" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Medida: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlunidadmedida" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Peso: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtpeso" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Precio Compra S/: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtpreciocompras" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Precio Compra $: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtpreciocomprad" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Precio venta S/: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtprecioventas" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Precio venta $: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtprecioventad" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Stock máximo: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtstockmax" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Stock mínimo: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtstockmin" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Stock actual: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtstockact" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Observacion: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtobservacion" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-actions col-md-offset-2">
                <asp:Button runat="server" ID="btnguardar" Text="Guardar" CssClass="btn btn-primary" OnClick="btnguardar_Click" OnClientClick="return confirm('¿Desea modificar el producto?');"/> |
                <a href="ManteProducto.aspx">Regresar al listado</a>
            </div>
        </fieldset>
    </div>
    <div class="text-primary text-success text-center">
        <asp:label runat="server" ID="lblmesaje"></asp:label>
    </div>
</asp:Content>
