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

        div#restablecer .BTN_Cambiar{
            background-color: rgb(24, 177, 228);
            color: white;
            border: 1px solid rgb(24, 177, 228);
            border-radius: 5px;
        }

        div#restablecer .BTN_Cambiar:hover{
            background-color: rgb(0, 131, 175);
        }

    </style>

    <h3>Paso 2 para restablecer su contraseña</h3>

    <div id="restablecer">
        <asp:Label runat="server" Text="" ID="LB_Mensaje"></asp:Label>
        <asp:Label runat="server" Text="Nueva Contraseña: " ID="LB_Contrasena"></asp:Label>
        <asp:TextBox runat="server" ID="TB_Contrasena" TextMode="Password"></asp:TextBox>
        <asp:RegularExpressionValidator runat="server" ErrorMessage="Hay caracteres especiales" ControlToValidate="TB_Contrasena" ValidationExpression="^[\s\w]*$" ForeColor="#CC0000"></asp:RegularExpressionValidator>
        <asp:Label runat="server" Text="Repetir Contraseña: " ID="LB_RepetirContrasena"></asp:Label>
        <asp:TextBox runat="server" ID="TB_RepetirContrasena" TextMode="Password"></asp:TextBox>
        <asp:RegularExpressionValidator runat="server" ErrorMessage="Hay caracteres especiales" ControlToValidate="TB_RepetirContrasena" ValidationExpression="^[\s\w]*$" ForeColor="#CC0000"></asp:RegularExpressionValidator>
        <asp:Button runat="server" Text="Cambiar" class="BTN_Cambiar" ID="BTN_Cambiar" OnClick="BTN_Cambiar_Click"></asp:Button>
    </div>

</asp:Content>

