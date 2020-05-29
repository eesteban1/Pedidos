<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ManteAcceso.aspx.cs" Inherits="PedidosCegal.ManteAcceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center text-success">Listado de accesos</h2>
     <div class="well well-sm" style="width:100%">
        <a class="btn btn-primary" href="NueAcceso.aspx">Nuevo</a>
    </div>
    <asp:UpdatePanel runat="server" ID="updmanteacceso"  style="display:block;overflow-x:auto">
        <ContentTemplate>
                <asp:GridView class="table table-hover table-striped" runat="server" ID="grvmante" AutoGenerateColumns="false" Width="100%" GridLines="None" PageSize="50" AllowPaging="true" OnPageIndexChanging="grvmante_PageIndexChanging" OnRowCommand="grvmante_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id_Acceso" ControlStyle-CssClass="hide" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" FooterStyle-CssClass="hide"/>
                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                        <asp:BoundField DataField="Nombrescom" HeaderText="Nombres y Apellidos"/>
                        <asp:BoundField DataField="NombreCargo" HeaderText="Cargo" />
                        <asp:TemplateField HeaderText="Operaciones" ItemStyle-CssClass="hidden-tablet" HeaderStyle-CssClass="hidden-tablet" >
                            <ItemTemplate>
                               <asp:Button ID="btnmodi" CssClass="btn btn-info" Text="M" runat="server" CommandName="Modificar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Modificar"/>
                                <asp:Button ID="btnver" CssClass="btn btn-success" Text="V" runat="server" CommandName="Ver" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Ver"/>
                                <asp:Button CssClass="btn btn-danger" Text="X" ID="Eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Eliminar" OnClientClick="return confirm('¿Desea eliminar el acceso del personal?');"/>
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
