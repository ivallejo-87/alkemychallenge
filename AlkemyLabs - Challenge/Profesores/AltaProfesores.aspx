<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="AltaProfesores.aspx.cs" Inherits="AlkemyLabs___Challenge.Profesores.AltaProfesores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td>    <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
            <td>
    <asp:Label ID="Label2" runat="server" Text="Apellido:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            </td>
            <td>
    <asp:Label ID="Label3" runat="server" Text="DNI:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="txtDNI" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
    </table>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Label" Visible="false"></asp:Label>
    </p>
    <div style="text-align:center">
        <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-success" Font-Bold="True" Font-Size="Large" Text="Guardar Profesor" OnClick="btnAceptar_Click" />
    </div>
</asp:Content>
