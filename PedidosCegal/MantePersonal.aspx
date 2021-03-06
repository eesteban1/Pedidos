﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="MantePersonal.aspx.cs" Inherits="PedidosCegal.MantePersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center text-success">Listado del personal</h2>
    <div class="well well-sm" style="width:100%">
        <a class="btn btn-primary" href="NuePersonal.aspx">Nuevo</a>
    </div>
    <asp:UpdatePanel runat="server" ID="updmanteper">
        <ContentTemplate>
            <asp:GridView Class="table table-hover table-striped" runat="server" ID="grvmante" AutoGenerateColumns="false" Width="100%" GridLines="None" PageSize="50" AllowPaging="true" OnPageIndexChanging="grvmante_PageIndexChanging" OnRowCommand="grvmante_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Id_personal" HeaderText="Codigo" />
                    <asp:BoundField DataField="Nombre" HeaderText="Cargo" />
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                    <asp:BoundField DataField="Nombres" HeaderText="Nombre" />
                    <asp:BoundField DataField="Domicilio" HeaderText="Dirección" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:TemplateField HeaderText="Operaciones" ItemStyle-CssClass="hidden-tablet" HeaderStyle-CssClass="hidden-tablet" >
                            <ItemTemplate>
                               <asp:Button ID="btnmodi" CssClass="btn btn-info" Text="M" runat="server" CommandName="Modificar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Modificar"/>
                                <asp:Button ID="btnver" CssClass="btn btn-success" Text="V" runat="server" CommandName="Ver" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Ver"/>
                                <asp:Button CssClass="btn btn-danger" Text="X" ID="Eliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' title="Eliminar" OnClientClick="return confirm('¿Desea eliminar al personal?');"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <HeaderStyle BackColor="#337ab7" Font-Bold="true" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="background-color: #D6EAF8">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Cuadro de Mensajes</h4>
                </div>
                <div class="modal-body">
                    <div class="msgcentrado">
                        <asp:Label Text="No se puede eliminar al personal, tiene acceso al aplicativo." ID="lblmesaje" runat="server" Style="font-size: 18px"></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
