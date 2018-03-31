﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/MPHeaderFooter.master" AutoEventWireup="true" CodeFile="~/Controller/RecuperarContrasenaPasoUno.aspx.cs" Inherits="View_RecuperarContrasenaPasoUno" %>

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

        div#restablecer .BTN_Restablecer{
            background-color: rgb(24, 177, 228);
            color: white;
            border: 1px solid rgb(24, 177, 228);
            border-radius: 5px;
        }

        div#restablecer .BTN_Restablecer:hover{
            background-color: rgb(0, 131, 175);
        }


    </style>

    <div id="restablecer">
        <h3>Paso 1 para restablecer su contraseña</h3>
        <asp:Label runat="server" Text="Digite su numero de Identificacion:" ID="LB_Identificacion"></asp:Label>
        <asp:TextBox runat="server" ID="TB_Identificacion"></asp:TextBox>
        <asp:Label runat="server" ID="LB_Mensaje"></asp:Label>
        <asp:Button runat="server" Text="Restablecer" class="BTN_Restablecer" ID="BTN_Restablecer" OnClick="BTN_Restablecer_Click"></asp:Button>
        
    </div>

</asp:Content>
