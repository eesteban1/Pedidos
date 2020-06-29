<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ManteFamilia.aspx.cs" Inherits="PedidosCegal.ManteFamilia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center text-success" style="font-family:arial";>Listado de Familias</h3>
    <div class="well well-sm">
        <a class="btn btn-primary" href="NueFamilia.aspx">Nuevo</a>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="display:block;overflow-x:auto">
        <ContentTemplate>
            <asp:GridView ID="grvfamilia" runat="server" class="table table-striped table-hover" AutoGenerateColumns="false" Width="100%" GridLines="None" PageSize="10" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Id_Familia" HeaderText="Codigo" />
                    <asp:BoundField DataField="Nombre" HeaderText="Descripcion" />
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
