<%@ Page Title="" Language="C#" MasterPageFile="~/View/MPHeaderFooter.master" AutoEventWireup="true" CodeFile="~/Controller/RecuperarContrasenaPasoDos.aspx.cs" Inherits="View_RecuperarContrasenaPasoDos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style>

        h3{
            text-align: center;
            padding: 30px;
        }

        div#restablecer{
            display:flex;
            flex-direction: column;
            align-items: center;
            margin-bottom: 40px;
            justify-content: space-around;
            height: 200px;
        }

    </style>

    <h3>Paso 2 para restablecer su contraseña</h3>

    <div id="restablecer">
        <asp:Label runat="server" Text="" ID="LB_Mensaje"></asp:Label>
        <asp:Label runat="server" Text="Nueva Contraseña: " ID="LB_Contrasena"></asp:Label>
        <asp:TextBox runat="server" ID="TB_Contrasena" TextMode="Password"></asp:TextBox>
        <asp:Label runat="server" Text="Repetir Contraseña: " ID="LB_RepetirContrasena"></asp:Label>
        <asp:TextBox runat="server" ID="TB_RepetirContrasena" TextMode="Password"></asp:TextBox>
        <asp:Button runat="server" Text="Cambiar" ID="BTN_Cambiar" OnClick="BTN_Cambiar_Click"></asp:Button>
    </div>

</asp:Content>

