<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/ReprogramarCita.aspx.cs" Inherits="View_Usuario_ReprogramarCita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">

    <style>

        h1.titulo{
            color: rgb(0, 200, 248);
            text-align: center;
            padding: 20px;
            margin-bottom: 20px;
        }

        h3{
            text-align: center;
            padding: 10px;
        }

        div{
            margin-bottom: 30px;
        }

        .BTN_Confirmar{
            display: block;
            margin: 0 auto;
            border-radius: 5px;
            background-color: rgb(0, 200, 248);
            color: white;
            border: 1px solid rgb(0, 200, 248);
        }

    </style>

    <h1 class="titulo">Reprogramar Citas</h1>

    <div>
        <h3>Cita a Cambiar</h3>
        <asp:GridView ID="GV_CitasAgendadas" runat="server"></asp:GridView>
    </div>

    <div>
        <h3>Citas disponibles</h3>
        <asp:GridView ID="GV_CitasDisponibles" runat="server"></asp:GridView>
    </div>
    <div>
        <asp:Button ID="BTN_Confirmar" class="BTN_Confirmar" runat="server" Text="Confirmar"></asp:Button>
    </div>

</asp:Content>

