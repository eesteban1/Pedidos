<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ManteProducto.aspx.cs" Inherits="PedidosCegal.ManteProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2 class="text-center text-s   uccess">Listado de Productos</h2>
    <div class="well well-sm">
        <a class="btn btn-primary" href="NueProducto.aspx">Nuevo</a>
    <a class="btn btn-primary" href="NueCliente.aspx" target="_blank">Imprimir</a>
    </div>

    <asp:UpdatePanel runat="server" ID="updproducto" style="overflow-x:auto; display:block">
        <ContentTemplate>
                <asp:GridView class="table table-striped table-hover" runat="server" ID="grvmanteproducto" AutoGenerateColumns="false" Width="100%" GridLines="None" PageSize="50" AllowPaging="true" OnPageIndexChanging="grvmanteproducto_PageIndexChanging" OnRowCommand="grvmanteproducto_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id_prod" HeaderText="Codigo" ItemStyle-CssClass="hidden-phone hidden-tablet" HeaderStyle-CssClass="hidden-phone hidden-tablet"/>
                        <asp:BoundField DataField="descripcion" HeaderText="Nombre producto" ItemStyle-CssClass="hidden-phone hidden-tablet" HeaderStyle-CssClass="hidden-phone hidden-tablet"/>
                        <asp:BoundField DataField="Nombre" HeaderText="Familia" ItemStyle-CssClass="hidden-tablet" HeaderStyle-CssClass="hidden-tablet"/>
                        <asp:BoundField DataField="Marca" HeaderText="Marca" ItemStyle-CssClass="hidden-tablet" HeaderStyle-CssClass="hidden-tablet"/>
                        <asp:BoundField DataField="PesoKilos" HeaderText="Peso en Kg" ItemStyle-CssClass="hidden-phone hidden-tablet" HeaderStyle-CssClass="hidden-phone hidden-tablet"/>
                        <asp:BoundField DataField="PVentaS" HeaderText="P. venta S/"  ItemStyle-CssClass="hidden-phone hidden-tablet" HeaderStyle-CssClass="hidden-phone hidden-tablet"/>
                        <asp:BoundField DataField="PVentaD" HeaderText="P. venta $"  ItemStyle-CssClass="hidden-phone hidden-tablet" HeaderStyle-CssClass="hidden-phone hidden-tablet"/>
                        <asp:TemplateField HeaderText="Operaciones" ItemStyle-CssClass="hidden-tablet" HeaderStyle-CssClass="hidden-tablet" >
                            <ItemTemplate>
                               <asp:Button ID="btnmodi" CssClass="btn btn-info" Text="M" runat="server" CommandName="Modificar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Modificar"/>
                                <asp:Button ID="btnver" CssClass="btn btn-success" Text="V" runat="server" CommandName="Ver" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Ver" />
                                <asp:Button CssClass="btn btn-danger" Text="X" ID="Eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Eliminar" OnClientClick="return confirm('¿Desea eliminar el producto?');"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <HeaderStyle BackColor="#337ab7" Font-Bold="true" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                   
                                     
                </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
