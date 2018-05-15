<%@ Page Title="" Language="C#" MasterPageFile="~/View/Usuario/MPUsuario.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/ReprogramarCita.aspx.cs" Inherits="View_Usuario_ReprogramarCita"  EnableEventValidation="false"%>

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

        div#Tabla{
            margin-bottom: 30px;
        }

        div#Tabla .GV_CitasAgendadas{
            width: 80%;
            margin: 0 auto;
        }

        </style>

    <h1 class="titulo_usuario">Reprogramar Citas</h1>

    <div>
        <h3>
            <asp:Label ID="Label1" runat="server" ForeColor="#33CCFF" Text="Cita a Cambiar"></asp:Label>
        </h3>
        <div id="Tabla">
        <asp:GridView id="GV_CitasAgendadas" class="GV_CitasAgendadas" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" EnableModelValidation="False" OnSelectedIndexChanged="GV_CitasAgendadas_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Seleccione">
                    <ItemTemplate>
                        <asp:Button class="BTN_Confirmar" ID="BTN_Confirmar" runat="server" Text="Seleccionar" CommandArgument='<%# Eval("id") %>' OnClick="Button1_Click"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="nombre_medico" HeaderText="Medico" />
                <asp:BoundField DataField="hora_inicio" HeaderText="Hora Inicio" />
                <asp:BoundField DataField="hora_fin" HeaderText="Hora Fin" />
                <asp:BoundField DataField="dia" HeaderText="Dia" SortExpression="dia" DataFormatString="{0:d}" HtmlEncode=false/>
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
    </div>

</asp:Content>

