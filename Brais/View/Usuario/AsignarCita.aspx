<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/AsignarCita.aspx.cs" Inherits="View_Usuario_AsignarCita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">

    <style>

        h1.titulo{
            color: rgb(0, 200, 248);
            text-align: center;
            padding: 20px;
        }

        div.campo{
            display: flex;
            justify-content: center;
            padding: 10px;
        }

        div.campo > *{
            width: 50%;
        }

        div.tipocita_fechasdisponibles{
            display: flex;
            flex-wrap: wrap;
            justify-content: space-around;
            margin-bottom: 30px;
        }

        div.tipo_cita{
            padding: 10px;
            width: 300px;
        }

        div.fechas_disponibles{
            padding: 10px;
        }

        div.fechas_disponibles h3, div.disponibilidad_horaria{
            text-align: center;
            padding: 10px;
        }

        div.disponibilidad_horaria{
            height: 200px;
        }

        .BTN_BuscarCita{
            display: block;
            margin: 0 auto;
            border-radius: 5px;
            background-color: rgb(0, 200, 248);
            color: white;
            border: 1px solid rgb(0, 200, 248);
        }

    </style>

    <h1 class="titulo">Asignar Citas</h1>

    <div class="tipocita_fechasdisponibles">
        <div class="tipo_cita">
            <div class="campo">
                <asp:Label ID="LB_TipoCita" class="LB_TipoCita" runat="server" Text="Tipo de cita: "></asp:Label>
                <asp:DropDownList ID="DDL_TipoCita" class="DDL_TipoCita" runat="server">
                    <asp:ListItem>Odontologica</asp:ListItem>
                    <asp:ListItem>Medicina General</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="campo">
                <asp:Label ID="LB_Jornada" class="LB_Jornada" runat="server" Text="Jornada: "></asp:Label>
                <asp:RadioButtonList ID="RBL_Jornada" class="RBL_Jornada" runat="server">
                    <asp:ListItem Value="Mañana">Mañana</asp:ListItem>
                    <asp:ListItem>Tarde</asp:ListItem>
                </asp:RadioButtonList>
            </div>

            <div class="campo">
                <asp:Button class="BTN_BuscarCita" ID="BTN_BuscarCita" runat="server" Text="Buscar Cita"></asp:Button>
            </div>
        </div>

        <div class="fechas_disponibles">
            <h3>Fechas Disponibles</h3>
            <asp:Calendar ID="C_FechasDisponibles" class="C_FechasDisponibles" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <WeekendDayStyle BackColor="#CCCCFF" />
            </asp:Calendar>
        </div>
    </div>

    <div class="disponibilidad_horaria">
        <h3>Disponibilidad Horaria</h3>
        <asp:GridView ID="GV_DisponibilidadHoraria" class="GV_DisponibilidadHoraria" runat="server"></asp:GridView>
    </div>

</asp:Content>

