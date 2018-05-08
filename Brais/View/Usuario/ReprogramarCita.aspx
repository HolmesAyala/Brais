<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/ReprogramarCita.aspx.cs" Inherits="View_Usuario_ReprogramarCita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">

    <style>
        .centrar{
            margin:auto;
        }
        h1.titulo_usuario{
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

        .auto-style1 {
            text-align: center;
        }

    </style>

    <h1 class="titulo_usuario">Reprogramar Citas</h1>

    <div>
        <h3>
            <asp:Label ID="Label1" runat="server" ForeColor="#33CCFF" Text="Cita a Cambiar"></asp:Label>
        </h3>
        <asp:GridView ID="GV_CitasAgendadas" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1261px" CssClass="centrar">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Seleccione">
                    <ItemTemplate>
                        <asp:RadioButton ID="RadioButton1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>

    <div>
        <h3>
            <asp:Label ID="Label2" runat="server" ForeColor="#33CCFF" Text="Citas disponibles"></asp:Label>
        </h3>
        <asp:GridView ID="GV_CitasDisponibles" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="1261px" CssClass="centrar">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>
    <div class="auto-style1">
        <asp:Button ID="BTN_Confirmar" class="BTN_Confirmar" runat="server" Text="Confirmar" Font-Bold="True" Width="98px"></asp:Button>
    </div>

</asp:Content>

