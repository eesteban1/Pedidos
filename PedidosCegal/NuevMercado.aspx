<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="NuevMercado.aspx.cs" Inherits="PedidosCegal.NuevMercado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="well well-sm text-primary text-center">
        <h2>Nuevo Mercado</h2>
    </div>
    <div class="form-horizontal">
        <fieldset>
            <div class="form-group">
                <label class="control-label col-md-2">Código: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtcodigo" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Descripción de la zona: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlzona" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Nombre del mercado: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtmercado" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Dirección: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtdireccion" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Departamento: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddldepartamento" CssClass="form-control" OnSelectedIndexChanged="ddldepartamento_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Provincias: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddlprovincia" CssClass="form-control" OnSelectedIndexChanged="ddlprovincia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Distrito: </label>
                <div class="col-md-2">
                    <asp:DropDownList runat="server" ID="ddldistrito" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Observación: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtobservacion" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-actions col-md-offset-2">
                <asp:Button runat="server" ID="btnguardar" Text="Guardar" CssClass="btn btn-primary" OnClick="btnguardar_Click"/> |
                <a href="ManteCliente.aspx">Regresar al listado</a>
            </div>
        </fieldset>
    </div>
    <div class="text-primary text-success text-center">
        <asp:label runat="server" ID="lblmesaje"></asp:label>
    </div>
</asp:Content>
