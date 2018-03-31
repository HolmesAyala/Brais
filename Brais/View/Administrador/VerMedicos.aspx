<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador/MPAdministrador.master" AutoEventWireup="true" CodeFile="~/Controller/Administrador/VerMedicos.aspx.cs" Inherits="View_Administrador_VerMedicos" %>

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

        div#Tabla .GV_Usuarios{
            width: 80%;
            margin: 0 auto;
        }
        
        .BTN_Eliminar{
            color: white;
            background-color: rgb(255, 56, 34);
            border: 1px solid rgb(0, 77, 99);
            border-radius: 5px;
        }

        .BTN_Modificar{
            color: white;
            background-color: rgb(22, 157, 179);
            border: 1px solid rgb(0, 77, 99);
            border-radius: 5px;
        }

    </style>

    <h2>Medicos Registrados</h2>
    <div id="Buscar_Agregar">
        <div>
            <asp:TextBox runat="server" class="TB_Buscar" ID="TB_Buscar" placeholder="Buscar por identificacion"></asp:TextBox>
            <asp:Button runat="server" Text="Buscar" class="BTN_Buscar" ID="BTN_Buscar" OnClick="BTN_Buscar_Click"></asp:Button>
        </div>
        <asp:Button runat="server" class="BTN_AgregarMedico" ID="BTN_AgregarMedico" Text="Agregar Medico" OnClick="BTN_AgregarUsuario_Click"></asp:Button>
    </div>

    <div id="tabla">

        <asp:GridView class="GV_Usuarios" runat="server" ID="GV_Usuarios" AllowPaging="True" AutoGenerateColumns="False" CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" EnableModelValidation="False" OnPageIndexChanging="GV_Usuarios_PageIndexChanging" Width="1329px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="identificacion" HeaderText="Identificacion" />
                <asp:BoundField DataField="id_tipo_identificacion" HeaderText="Tipo" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="id_tipo_afiliacion" HeaderText="Afiliacion" />
                <asp:BoundField DataField="correo" HeaderText="Correo" />
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LB_Modificar" runat="server" Text='<%# Eval("identificacion") %>' Visible="False"></asp:Label>
                        <asp:Button class="BTN_Modificar" ID="BTN_Modificar" runat="server" Text="Modificar" OnClick="BTN_Modificar_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LB_Eliminar" runat="server" Text='<%# Eval("identificacion") %>' Visible="False"></asp:Label>
                        <asp:Button ID="BTN_Eliminar" runat="server" class="BTN_Eliminar" OnClick="BTN_Eliminar_Click" Text="Eliminar" />
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

