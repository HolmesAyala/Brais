<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/cambiarCita.aspx.cs" Inherits="View_Usuario_cambiarCita" EnableEventValidation="false"%>

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

        div#Tabla .GridView1{
            width: 80%;
            margin: 0 auto;
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

    <h1 class="titulo_usuario">Seleccione la cita a cambiar</h1>

    <div id="Tabla">
        <asp:GridView ID="GridView1" class="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" EnableModelValidation="False" OnPageIndexChanging="GridView1_PageIndexChanging" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="nm" HeaderText="Medico" />
                <asp:BoundField DataField="da" HeaderText="Dia" SortExpression="dia" DataFormatString="{0:d}" HtmlEncode=false />
                <asp:BoundField DataField="h_i" HeaderText="Hora Inicio" />
                <asp:BoundField DataField="h_f" HeaderText="Hora Fin" />
                <asp:BoundField HeaderText="Especialidad" DataField="es" />
                <asp:TemplateField HeaderText="Seleccion">
                    <ItemTemplate>
                        <asp:Button ID="BTN_Confirmar" class="BTN_Confirmar" runat="server" OnClick="b_cam_Click" Text="Cambiar" CommandArgument='<%# Eval("ci") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
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

