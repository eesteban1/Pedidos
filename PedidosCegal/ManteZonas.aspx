<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ManteZonas.aspx.cs" Inherits="PedidosCegal.ManteZonas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center text-success" style="font-family:arial";>Listado de Zonas</h3>
<div class="well well-sm">
    <a class="btn btn-primary" href="NueZona.aspx">Nuevo</a>
</div>
    <asp:UpdatePanel runat="server" ID="updmante"  style="display:block;overflow-x:auto">
        <ContentTemplate>
            <asp:GridView class="table table-striped table-hover" runat="server" ID="grvmantezona" AutoGenerateColumns="false" Width="100%" GridLines="None" PageSize="10" AllowPaging="true" OnPageIndexChanging="grvmantezona_PageIndexChanging" OnRowCommand="grvmantezona_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="IdZona" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"/>
                        <asp:BoundField DataField="DescripCorta" HeaderText="Código" />
                        <asp:BoundField DataField="DescripLarga" HeaderText="Nombre de la zona" />
                        <asp:BoundField DataField="Observacion" HeaderText="Observacióm" />
                        <asp:TemplateField HeaderText="Operaciones" ItemStyle-CssClass="hidden-tablet" HeaderStyle-CssClass="hidden-tablet" >
                            <ItemTemplate>
                               <asp:Button  CssClass="btn btn-info" Text="M" runat="server" CommandName="Modificar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Modificar"/>
                                <asp:Button  CssClass="btn btn-success" Text="V" runat="server" CommandName="Ver" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Ver" />
                                <asp:Button CssClass="btn btn-danger" Text="X" ID="Eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Eliminar" OnClientClick="return confirm('¿Desea eliminar la zona?');"/>
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
