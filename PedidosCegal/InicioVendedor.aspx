<%@ Page Title="" Language="C#" MasterPageFile="~/Home2.Master" AutoEventWireup="true" CodeBehind="InicioVendedor.aspx.cs" Inherits="PedidosCegal.InicioVendedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
    .panel .panel-heading a {
        color: white;
    }
    </style>
    <label style="color:green; font-family:Arial; font-size:xx-large">EL CEGALITO S.A.C.</label>
    <p><%: DateTime.Now %></p>
    <p style="color:dodgerblue; font-size:large">Bienvenido: <asp:Label  runat="server" style="color:dodgerblue; font-size:large" ID="lblnombre"></asp:Label></p>
    <p style="color:dodgerblue; font-size:large">Zona: <asp:Label  runat="server" style="color:dodgerblue; font-size:large" ID="lblzona"></asp:Label></p>
    <p style="color:dodgerblue; font-size:large">Cargo: <asp:Label  runat="server" style="color:dodgerblue; font-size:large" ID="lblcargo"></asp:Label></p>
    <div class="row">
    
    
    <div class="col-lg-3 col-md-6">
        <div class="panel panel-yellow">
            <div class="panel-heading">
                <a href="MantePedidoVendedor.aspx">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-shopping-cart fa-5x"></i>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div class="huge">Pedidos</div>
                        </div>
                    </div>
                </a>
            </div>
        </div>
    </div>
</div>
</asp:Content>
