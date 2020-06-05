<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PedidosCegal.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inicio de Session</title>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="~/css/master.css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#show_password').hover(function show() {
                //Cambiar el atributo a texto
                $('#txtpass').attr('type', 'text');
                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
            },
                function () {
                    //Cambiar el atributo a contraseña
                    $('#txtpass').attr('type', 'password');
                    $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
                });
        });
    </script>
    <style>
       
    </style>
</head>
<body>
    <div class="login-box">
        <img src="img/icono_User.png" class="avatar" alt="Avatar Image" />
        <h1>Ingrese aquí</h1>
        <form id="form1" runat="server">
            <!-- USERNAME INPUT -->
            <label for="username">Nombre del Usuario</label>
            <asp:TextBox runat="server" ID="txtuser" placeholder="Entrar nombre del usuario" required="true" CssClass="form-control"></asp:TextBox>
            <!-- PASSWORD INPUT -->
            <label for="password">Clave</label>
            <div class="input-group">
                <asp:TextBox runat="server" ID="txtpass" placeholder="Entrar clave del usuario" TextMode="Password" required="true" CssClass="form-control"></asp:TextBox>
                <div class="input-group-append">
                    <button id="show_password" class="btn btn-primary" type="button">
                        <span class="fa fa-eye-slash icon"></span>
                    </button>
                </div>
            </div>
            <br />
            <asp:Button runat="server" Text="Iniciar Sesión" ID="btningresar" OnClick="btningresar_Click" CommandName="Login" />
            <asp:Label runat="server" ID="lblerror" Style="color: red;"></asp:Label>
        </form>
    </div>
</body>
</html>
