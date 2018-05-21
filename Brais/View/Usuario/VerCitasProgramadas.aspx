<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/VerCitasProgramadas.aspx.cs" Inherits="View_Usuario_VerCitasProgramadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">

    <style>

        h1.titulo_usuario{
            color: rgb(0, 200, 248);
            text-align: center;
            padding: 20px;
        }

        div#Tabla{
            margin-bottom: 30px;
        }

        div#Tabla .GV_Ver_citas{
            width: 80%;
            margin: 0 auto;
        }

    </style>

    <h1 class="titulo_usuario">Citas Programadas</h1>

    <div id="Tabla">
        <asp:GridView class="GV_Ver_citas" runat="server" ID="GV_Ver_citas" AllowPaging="True" AutoGenerateColumns="False" CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" EnableModelValidation="False" OnPageIndexChanging="GV_Cancelar_Cita_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="dia" HeaderText="Fecha" SortExpression="dia" DataFormatString="{0:d}" HtmlEncode=false />
                <asp:BoundField DataField="hora_inicio" HeaderText="Hora" />
                <asp:BoundField DataField="especialidad" HeaderText="Tipo" />
                <asp:BoundField DataField="nombre_medico" HeaderText="Médico" />
                <asp:BoundField DataField="nombre_consultorio" HeaderText="Consultorio" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        

    </div>

</asp:Content>


