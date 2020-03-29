<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmReporteCliente.aspx.cs" Inherits="PedidosCegal.Reportes.frmReporteCliente" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Arial" Font-Size="10pt" Height="297px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="210px" EnableTheming="True" SizeToReportContent="True">
            <LocalReport ReportPath="Reportes/Cliente.rdlc"></LocalReport>
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
