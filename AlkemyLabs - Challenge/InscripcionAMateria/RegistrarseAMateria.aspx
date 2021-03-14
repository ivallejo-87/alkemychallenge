<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="RegistrarseAMateria.aspx.cs" Inherits="AlkemyLabs___Challenge.InscripcionAMateria.RegistrarseAMateria" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <asp:Label runat="server"  Font-Size="X-Large" Font-Bold="False">Seleccione la modalidad y materia que desea cursar</asp:Label>
    <br />
    <br />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <header>
        <style type="text/css">
            .fondo{
                background-color:black;
                filter:alpha(opacity=90);
                opacity:0.8;
                z-index:10000;
            }
            </style>
    </header>

    <asp:Label ID="Label1" runat="server" Text="Modalidad" Height="21px" Font-Size="X-Large"></asp:Label>

    
    <asp:Label ID="LabelPRUEBA" runat="server" Text="" Height="21px" Font-Size="X-Large" Visible="true"></asp:Label> 

    <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" CssClass="table table-bordered" CellPadding="4" ForeColor="#333333" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="id_materia" GridLines="None" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectText="&amp;#9658;&amp;#9658;&amp;#9658;" />
            <asp:BoundField DataField="Materia" HeaderText="Materia" />
            <asp:BoundField DataField="estado" HeaderText="Estado" NullDisplayText="Sin registrarse" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <p>

    </p>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container" style="text-align:center">
        <br />
        <asp:Button ID="btnREGISTRARSE" runat="server" Text="Registrarse" CssClass="btn btn-success" Font-Bold="True" Font-Size="Large" OnClick="btnREGISTRARSE_Click" Height="42px" Width="220px" />
    </div>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" ProviderName="<%$ ConnectionStrings:con.ProviderName %>" SelectCommand="Select * From materia"></asp:SqlDataSource>


    <ajaxToolkit:ModalPopupExtender ID="PopPupMensaje" runat="server" TargetControlID="LabelMODALPOPPUP" PopupControlID="Panel1" CancelControlID="exit"></ajaxToolkit:ModalPopupExtender>

     <asp:Panel ID="Panel1" runat="server" style="display:none;background-color:white;width:auto;height:auto">
            <div class="modal-header">
               
                <h3 id="modallabel" style="text-align:center">Advertencia</h3>
            </div>
            <div class="modal-body">
                
                 <asp:Label ID="LabelMODALPOPPUP" runat="server" Visible="True"></asp:Label>
            </div>
            <div class="modal-footer">
                <button  id="exit" class="btn" data-dismiss="modal" aria-hidden="true">Aceptar</button>
            </div>
     </asp:Panel>


</asp:Content>
