<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="AltaMateria.aspx.cs" Inherits="AlkemyLabs___Challenge.Materias.AltaMateria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="height: 33px">
    <asp:Label ID="Label1" runat="server" Text="Nombre: "></asp:Label>
            </td>
            <td style="height: 33px">
    <asp:TextBox ID="txtNombreMateria" runat="server"></asp:TextBox>
            </td>
            <td style="height: 33px">
    <asp:Label ID="Label2" runat="server" Text="Horario: "></asp:Label>
            </td>
            <td style="height: 33px">
    <asp:TextBox ID="txtHorario" runat="server" TextMode="Time"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="Label3" runat="server" Text="Profesor: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlProfesor" runat="server">
                </asp:DropDownList>
            </td>
            <td>
    <asp:Label ID="Label4" runat="server" Text="Cupos Maximo: "></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="txtCupos" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
        <div style="text-align:center">
        <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-success" Font-Bold="True" Font-Size="Large" Text="Guardar Materia" OnClick="btnAceptar_Click" />
        </div>
    <asp:Label ID="LabelError" runat="server" Text="Label" Visible="false"></asp:Label>
</asp:Content>
