<%@ Page Title="" Language="C#" MasterPageFile="~/View/MPHeaderFooter.master" AutoEventWireup="true" CodeFile="~/Controller/Medico/InsertarEliminarActualizar.aspx.cs" Inherits="View_Medico_InsertarEliminarActualizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    &nbsp;&nbsp;&nbsp;

    <style>
        .campo{
            display: flex;
            justify-content: center;
            margin: 7px;
        }
        td {
            height: 40px;
        }
        td.label {
            text-align: right; 
            width: 50%;
        }
        .BTN_Accion{
            color: white;
            background-color: rgb(0, 200, 248);
            border: 1px solid rgb(0, 200, 248);
            border-radius: 5px;
        }
        div.mensaje{
            font-weight: bold;
            line-height: 1.5rem;
            text-align: left;
            color: white;
            background-color: rgb(255, 95, 95);
            padding: 10px;
            border-radius: 5px;
        }
        .auto-style1 {
            font-size: large;
        }
    </style>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:Label ID="prueba" runat="server" Text="Label"></asp:Label>
    <table style="width: 100%">
        <tr>
            <td colspan="2" style="text-align: center; height: 29px"><strong>
                <asp:Label ID="L_Titulo" runat="server" style="color: #00C8F8; " CssClass="auto-style1"></asp:Label>
                </strong>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center; height: 29px"></td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="L_Tipo_Documento" runat="server" Text="Tipo de Documento: "></asp:Label>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:DropDownList ID="DDL_Tipo_Documento" runat="server" DataSourceID="ODS_Tipo_Identificacion" DataTextField="nombre" DataValueField="id">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ODS_Tipo_Identificacion" runat="server" SelectMethod="obtenerTipoIdentificacion" TypeName="DBTipoIdentificacion"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="L_Numero_Documento" runat="server" Text="Número de Documento: "></asp:Label>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="TB_Numero_Documento" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="L_Nombre" runat="server" Text="Nombre: "></asp:Label>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="TB_Nombre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="L_Apellido" runat="server" Text="Apellido: "></asp:Label>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="TB_Apellido" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="L_Fecha_Nacimiento" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="TB_Fecha_Nacimiento" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="L_Especialidad" runat="server" Text="Especialidad: "></asp:Label>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:DropDownList ID="DDL_Especialidad" runat="server" DataSourceID="ODS_Tipo_Especialidad" DataTextField="nombre" DataValueField="id">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ODS_Tipo_Especialidad" runat="server" SelectMethod="obtenerTipoEspecialidad" TypeName="DBEspecialidad"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="L_Consultorio" runat="server" Text="Consultorio: "></asp:Label>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:DropDownList ID="DDL_Consultorio" runat="server" DataSourceID="ODS_Consultorio" DataTextField="nombre_consultorio" DataValueField="id">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ODS_Consultorio" runat="server" SelectMethod="obtenerConsultoriosDisponibles" TypeName="DBConsultorio"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="L_Correo" runat="server" Text="Correo"></asp:Label>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="TB_Correo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="L_Contrasena" runat="server" Text="Contraseña: "></asp:Label>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="TB_Contrasena" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">
                <asp:Label ID="L_Repetir_Contrasena" runat="server" Text="Repetir Contraseña: "></asp:Label>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="TB_Repetir_Contrasena" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div class="campo">
            <div class="mensaje">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Label class="LB_Mensaje" ID="LB_Mensaje" runat="server" Visible="False"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BTN_Accion" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="campo">
            <asp:Button class="BTN_Accion" ID="BTN_Accion" runat="server" Text="BTN" OnClick="BTN_Accion_Click"></asp:Button>
        </div>


</asp:Content>


