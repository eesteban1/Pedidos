<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="VerMarca.aspx.cs" Inherits="PedidosCegal.VerMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well well-sm text-primary text-center">
        <h2>Ver Marca</h2>
    </div>
    <div class="form-horizontal">
        <fieldset>
            <asp:TextBox runat="server" ID="txtid" CssClass="hide"></asp:TextBox>
            <div class="form-group">
                <label class="control-label col-md-2">Código: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtcodigo" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">Descripción: </label>
                <div class="col-md-2">
                    <asp:TextBox runat="server" ID="txtdescripcion" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
             <div class="form-actions col-md-offset-2">
                <a href="ManteMarcas.aspx">Regresar al listado</a>
            </div>
        </fieldset>
    </div>
</asp:Content>
