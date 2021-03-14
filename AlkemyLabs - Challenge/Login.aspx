<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AlkemyLabs___Challenge.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    <p>
        <table align="center" class="auto-style1">
            <tr>
                <td class="auto-style2">
        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:TextBox ID="txtUsuario" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
    <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="align-content:center" class="auto-style2">
        <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesion" OnClick="Button1_Click" CssClass= "login100-form-btn" />
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
                        </div>
                </td>
            </tr>
        </table>
    </p>
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
