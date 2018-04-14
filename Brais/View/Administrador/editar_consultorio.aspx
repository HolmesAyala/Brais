<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador/MPAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador/editar_consultorio.aspx.cs" Inherits="View_Administrador_editar_consultorio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="text-align: center; height: 31px">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#00CCFF" Text="Editar Consultorio"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center; height: 25px;">
                <asp:Label ID="Label3" runat="server" Text="Nombre Consultorio"></asp:Label>&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:TextBox ID="TB_nombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_nombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Label4" runat="server" Text="Ubicacion Consultorio"></asp:Label>
&nbsp;&nbsp;
                <asp:TextBox ID="TB_ubicacion" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_ubicacion" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enviar" />
            </td>
        </tr>
    </table>
</asp:Content>

