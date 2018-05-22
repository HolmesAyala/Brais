<%@ Page Title="" Language="C#" MasterPageFile="~/View/Medico/MPMedico.master" AutoEventWireup="true" CodeFile="HorarioTrabajoPrueba.aspx.cs" Inherits="View_Medico_HorarioTrabajoPrueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">

    <style>
        
        h1.titulo_horario{
            text-align: center;
            margin-top: 10px;
            margin-bottom: 40px;
            color: rgb(24, 177, 228);
        }
        .rango{
            margin-bottom: 30px;
            display: flex;
            flex-direction: column;
            align-items: center;
        }
        .rango h3{
            text-align: center;
            margin-bottom: 30px;
        }
        .campo{
            display: flex;
            margin-bottom: 20px;
        }
        .LB{
            width: 100px;
        }
        .P_Contenedor{
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
        }
        .P_Dia{
            display: block;
            border-radius: 10px;
            border: 2px solid #EEEEEE;
            margin-bottom: 10px;
            width: 400px;
        }
        .LB_Dia{
            display: block;
            text-align: center;
            margin-bottom: 20px;
            padding: 5px 0;
            font-size: 1.3rem;
            border-top-right-radius: 10px;
            border-top-left-radius: 10px;
            background-color: rgb(24, 177, 228);
        }
        .P_Rangos{
            margin-bottom: 10px;
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .LB_Inicio, .LB_Fin{
            display: block;
            padding: 0 10px;
            margin: 3px;
        }
        .BTN_Eliminar{
            border-radius: 5px;
            background-color: rgb(221, 80, 68);
            border: 1px solid rgb(255, 0, 0);
            color: white;
        }

    </style>

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <h1 class="titulo_horario">Horario de trabajo</h1>

    <div class="rango">

        <h3>Agregar rango</h3>

        <div class="campo">
            <asp:Label class="LB" runat="server" Text="Dia: "></asp:Label>
            <asp:DropDownList ID="DDL_Dia" runat="server">
                <asp:ListItem Value="1">Lunes</asp:ListItem>
                <asp:ListItem Value="2">Martes</asp:ListItem>
                <asp:ListItem Value="3">Miercoles</asp:ListItem>
                <asp:ListItem Value="3">Jueves</asp:ListItem>
                <asp:ListItem Value="5">Viernes</asp:ListItem>
                <asp:ListItem Value="6">Sabado</asp:ListItem>
            </asp:DropDownList>
        </div>

        

        <div class="campo">
            <asp:Label CssClass="LB" runat="server" Text="Inicio: "></asp:Label>
            <asp:DropDownList ID="DDL_Inicio" runat="server" OnSelectedIndexChanged="DDL_Inicio_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>
        
        <div class="campo">
            <asp:Label CssClass="LB" runat="server" Text="Fin: "></asp:Label>
            <asp:UpdatePanel runat="server" RenderMode="Inline">
                <ContentTemplate>
                    <asp:DropDownList ID="DDL_Fin" runat="server"></asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DDL_Inicio" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>

        <asp:Button ID="BTN_Agregar" class="BTN_Azul BTN" runat="server" Text="Agregar" OnClick="BTN_Agregar_Click"></asp:Button>
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel ID="P_Contenedor" CssClass="P_Contenedor" runat="server">

            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BTN_Agregar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="DDL_Inicio" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    

    
    
    </asp:Content>

