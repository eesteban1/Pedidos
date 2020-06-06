<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PedidosCegal.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
    .panel .panel-heading a {
        color: white;
    }
    </style>
    <label style="color:green; font-family:Arial; font-size:xx-large">EL CEGALITO S.A.C.</label>
    <p><%: DateTime.Now %></p>
    <p style="color:dodgerblue; font-size:large">Bienvenido: <asp:Label  runat="server" style="color:dodgerblue; font-size:large" ID="lblnombre"></asp:Label></p>
    <%--<p style="color:dodgerblue; font-size:large">Zona: <asp:Label  runat="server" style="color:dodgerblue; font-size:large" ID="lblzona"></asp:Label></p>--%>
    <p style="color:dodgerblue; font-size:large">Cargo: <asp:Label  runat="server" style="color:dodgerblue; font-size:large" ID="lblcargo"></asp:Label></p>
    <div class="row">
    <div class="col-lg-3 col-md-6">
        <div class="panel panel-green">
            <div class="panel-heading">
                <a href="ManteCliente.aspx">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-users fa-5x"></i>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div class="huge">Clientes</div>
                        </div>
                    </div>
                </a>
            </div>
            <a href="ManteCliente.aspx">
                <div class="panel-footer">
                    <span class="pull-left">Mantenimiento de Clientes</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
    <div class="col-lg-3 col-md-6">
        <div class="panel panel-green">
            <div class="panel-heading">
                <a href="ManteProducto.aspx">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-tv fa-5x"></i>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div class="huge">Productos</div>
                        </div>
                    </div>

                </a>
            </div>
            <a href="ManteProducto.aspx">
                <div class="panel-footer">
                    <span class="pull-left">Mantenimiento de Productos</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
    <div class="col-lg-3 col-md-6">
        <div class="panel panel-yellow">
            <div class="panel-heading">
                <a href="MantePedido.aspx">
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
            <a href="MantePedido.aspx">
                <div class="panel-footer">
                    <span class="pull-left">Mantenimiento de pedidos</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
    <div class="col-lg-3 col-md-6">
        <div class="panel panel-red">
            <div class="panel-heading">
                <a href="#">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-users fa-5x"></i>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div class="huge">Personal</div>
                        </div>
                    </div>
                </a>
            </div>
            <a href="#">
                <div class="panel-footer">
                    <span class="pull-left">Mantenimiento del Personal</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
    <div class="col-lg-3 col-md-6">
        <div class="panel panel-green">
            <div class="panel-heading">
                <a href="ManteMercados.aspx">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-support fa-5x"></i>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div class="huge">Mercados</div>
                        </div>
                    </div>
                </a>
            </div>
            <a href="ManteMercados.aspx">
                <div class="panel-footer">
                    <span class="pull-left">Mantenimiento de Mercados</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
    <div class="col-lg-3 col-md-6">
        <div class="panel panel-green">
            <div class="panel-heading">
                <a href="ManteZonas.aspx">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <i class="fa fa-ambulance fa-5x"></i>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <div class="huge">Zonas</div>
                        </div>
                    </div>
                </a>
            </div>
            <a href="ManteZonas.aspx">
                <div class="panel-footer">
                    <span class="pull-left">Mantenimiento de Zonas</span>
                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                    <div class="clearfix"></div>
                </div>
            </a>
        </div>
    </div>
</div>
</asp:Content>
