<%@ Page Title="" Language="C#" MasterPageFile="~/View/Medico/MPMedico.master" AutoEventWireup="true" CodeFile="~/Controller/Medico/VerPacientes.aspx.cs" Inherits="View_Medico_VerPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">

        <style>

        h2{
            text-align: center;
            color: rgb(0, 200, 248);
            margin: 50px 0;
        }

        .TB_Buscar{
            font-size: 1rem;
            border-top-left-radius: 10px;
            border-bottom-left-radius: 10px;
            border: 1px solid rgb(128, 128, 128);
            padding: 5px;
            width: 300px;
        }

        .BTN_Buscar{
            border: 1px solid rgb(128, 128, 128);
            border-bottom-right-radius: 10px;
            border-top-right-radius: 10px;
            padding: 5px;
            font-size: 1rem;
        }

        .BTN_AgregarMedico{
            border-radius: 5px;
            border: 1px solid rgb(128, 128, 128);
            color: white;
            background-color: rgb(22, 157, 179);
        }

        div#Buscar_Agregar div{
            display: flex;
            justify-content:center;
        }

        div#Buscar_Agregar{
            display: flex;
            justify-content: space-around;
            margin-bottom: 30px;
        }

        div#Tabla{
            margin-bottom: 30px;
        }

        div#Tabla .GV_Pacientes{
            width: 80%;
            margin: 0 auto;
        }
        
        .BTN_Confirmar_Cita{
            color: white;
            background-color: rgb(255, 56, 34);
            border: 1px solid rgb(0, 77, 99);
            border-radius: 5px;
            width: 200px;
        }

        .BTN_Modificar_Historial{
            color: white;
            background-color: rgb(22, 157, 179);
            border: 1px solid rgb(0, 77, 99);
            border-radius: 5px;
        }
    </style>

    <h2 style="text-align:center">Pacientes Agendados</h2>

    <div id="Tabla">

        <asp:GridView class="GV_Pacientes" runat="server" ID="GV_Pacientes" AllowPaging="True" AutoGenerateColumns="False" CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" EnableModelValidation="False" OnPageIndexChanging="GV_Pacientes_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="hora" HeaderText="Hora" />
                <asp:BoundField DataField="identificacion" HeaderText="Identificación" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LB_Modificar_Historial" runat="server" Text='<%# Eval("identificacion") %>' Visible="False"></asp:Label>
                        <asp:Button class="BTN_Modificar_Historial" ID="BTN_Modificar_Historial" runat="server" Text="Modificar Historial"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LB_Confirmar_Cita" runat="server" Text='<%# Eval("identificacion") %>' Visible="False"></asp:Label>
                        <asp:Button ID="BTN_Confirmar_Cita" runat="server" class="BTN_Confirmar_Cita" Text="Cita atendida"/>
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



