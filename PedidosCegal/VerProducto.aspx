<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="VerProducto.aspx.cs" Inherits="PedidosCegal.VerProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well well-sm text-primary text-center">
        <h2>Ver Producto</h2>
    </div>
    <div class="form-horizontal">
        <fieldset>
            <div class="form-group">
                <label class="control-label col-md-2">Código: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtcodpro" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Familia: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlfamilia" CssClass="form-control" Enabled="false"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Marca: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlmarca" CssClass="form-control" Enabled="false"></asp:DropDownList>
                 </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Descripción del producto: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtdescripcion" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Afecto IGV: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddligv" CssClass="form-control" Enabled="false"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Medida: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlunidadmedida" CssClass="form-control" Enabled="false"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Peso: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtpeso" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Precio Compra S/: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtpreciocompras" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Precio Compra $: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtpreciocomprad" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Precio venta S/: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtprecioventas" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Precio venta $: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtprecioventad" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Stock máximo: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtstockmax" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Stock mínimo: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtstockmin" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Stock actual: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtstockact" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Observacion: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtobservacion" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-actions col-md-offset-2">
                <a href="ManteProducto.aspx">Regresar al listado</a>
            </div>
        </fieldset>
    </div>
</asp:Content>
