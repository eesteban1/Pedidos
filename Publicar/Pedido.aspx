<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="PedidosCegal.Pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <fieldset>
            <label style="color: skyblue; font-family: Arial; font-size: xx-large">Nuevo Pedido:</label>

            <div class="form-group">
                <div class="col-md-2">
                    <label style="color: skyblue; font-family: Arial;">Zona:
                        <br />
                        <asp:Label runat="server" ID="lblzona" Style="color: skyblue; font-family: Arial;"></asp:Label>
                    </label>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-2">
                    <label style="color: skyblue; font-family: Arial;">Mercados: </label>
                    <asp:DropDownList runat="server" ID="ddlmercados" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <label style="color: skyblue; font-family: Arial;">Fecha: </label>
                    <asp:TextBox runat="server" ID="txtfecha" type="date" CssClass="form-control" ></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2">
                    <label style="color: skyblue; font-family: Arial;">Cod. Cliente:</label>
                    <asp:TextBox runat="server" ID="txtcodcliente" CssClass="form-control col-md-2" OnTextChanged="txtcodcliente_TextChanged" AutoPostBack="true" type="number"></asp:TextBox>
                </div>

                <div class="col-md-2">
                    <label style="color: skyblue; font-family: Arial;">Nombre del cliente: </label>
                    <br />
                    <asp:Label runat="server" ID="lblnombre" Style="color: skyblue; font-family: Arial;"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2">
                    <label style="color: skyblue; font-family: Arial;">Lista de productos</label>
                    <asp:DropDownList runat="server" ID="ddlproducto" CssClass="form-control" OnSelectedIndexChanged="ddlproducto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-12" style="overflow-x:auto; display:block">
                <asp:UpdatePanel runat="server" ID="updDetalles">
                    <ContentTemplate>
                        <asp:GridView runat="server" ID="grvDetalles" CssClass="table table-stripe table-hover" AutoGenerateColumns="false" style="align-items:center" Width="100%" PageSize="22" EmptyDataText="Sin Seleccion  de Productos" ShowHeaderWhenEmpty="True" GridLines="None" OnRowCommand="grvDetalles_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="IdArticulo" HeaderText="Cod."/>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server"
                                            Text='<% #Eval("Cantidad") %>' ID="txtcantidad" Width="50" style="border-radius:5px" type="number"
                                            AutoPostBack="true" OnTextChanged="txtcantidad_TextChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Kilos">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtpeso" Width="50" style="border-radius:5px" type="number"
                                            Text='<% #Eval("Peso") %>' OnTextChanged="txtpeso_TextChanged"
                                            AutoPostBack="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preciounidad">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtprecio" Width="50" style="border-radius:5px" type="number" OnTextChanged="txtprecio_TextChanged"
                                            Text='<% #Eval("PrecioUnidad") %>' AutoPostBack="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="SubTotal" HeaderText="Sub Total" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ImageUrl="~/img/anulada.jpg" Width="16px" Height="16px" CommandName="Eliminar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Eliminar" OnClientClick="return confirm('¿Esta seguro que desea borrar el pedido?');"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="GreenYellow"  />
                        </asp:GridView>

                        <div class="form-group">
                            <div class="col-sm-12" style="text-align: right">
                                <table>
                                    <tr>
                                        <label style="color: skyblue; font-family: Arial; font-size: large">Total: </label>
                                    </tr>
                                    
                                    <tr>
                                        <asp:Label Style="color: skyblue; font-family: Arial; font-size: large" Text="0" runat="server" ID="lbltotal" />
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-6">
                <asp:Button runat="server" ID="btnguardar" Text="Guardar Pedido" CssClass="btn btn-primary" OnClick="btnguardar_Click" />|
                <asp:Button runat="server" ID="btnuevo" Text="Nuevo" CssClass="btn btn-primary" OnClick="btnuevo_Click" /> |
                <asp:Button runat="server" ID="btnimprimir" Text="Imprimir" CssClass="btn btn-primary" OnClick="btnimprimir_Click" Enabled="false"/> |
                <a href="MantePedido.aspx">Regresar al listado de pedidos</a>
            </div>
        </fieldset>
    </div>
    <div class="text-primary text-success text-center">
        <asp:label runat="server" ID="lblmesaje"></asp:label>
    </div>
</asp:Content>
