<%@ Page Title="" Language="C#" MasterPageFile="~/View/MPHeaderFooter.master" AutoEventWireup="true" CodeFile="~/Controller/Usuario/InsertarEliminarActualizar.aspx.cs" Inherits="View_Usuario_InsertarEliminarActualizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style>
        .formulario_usuario{
            display: flex;
            flex-direction: column;
            padding: 30px;
            font-size: 1rem;
        }

        .campo{
            display: flex;
            justify-content: center;
            margin: 7px;
        }

        .formulario_usuario .campo [class^="LB"]{
            width: 150px;
            text-align: right;
            margin: 5px;
        }

        .formulario_usuario .campo *:nth-child(2){
            width: 200px;
            padding-left:5px;
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

    </style>

    <asp:Label ID="LB_Titulo" runat="server" Text=""></asp:Label>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="formulario_usuario">

        <div class="campo">
            <asp:Label class="LB_Tipo_Documento" ID="LB_Tipo_Documento" runat="server" Text="Tipo de documento: "></asp:Label>
            <asp:DropDownList class="DDL_Tipo_Documento" ID="DDL_Tipo_Documento" runat="server" DataTextField="nombre" DataValueField="id" DataSourceID="ODS_ObtenerTipoDocumento">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ODS_ObtenerTipoDocumento" runat="server" SelectMethod="obtenerTipoIdentificacion" TypeName="DBTipoIdentificacion"></asp:ObjectDataSource>
        </div>

        <div class="campo">
            <asp:Label class="LB_Numero_Documento" ID="LB_Numero_Documento" runat="server" Text="Numero Documento: "></asp:Label>
            <asp:TextBox class="TB_Numero_Documento" ID="TB_Numero_Documento" runat="server" MaxLength="20"></asp:TextBox>
        </div>

        <div class="campo">
            <asp:Label class="LB_Nombre" ID="LB_Nombre" runat="server" Text="Nombres: "></asp:Label>
            <asp:TextBox class="TB_Nombre" ID="TB_Nombre" runat="server" MaxLength="20"></asp:TextBox>
        </div>

        <div class="campo">
            <asp:Label class="LB_Apellido" ID="LB_Apellido" runat="server" Text="Apellidos: "></asp:Label>
            <asp:TextBox class="TB_Apellido" ID="TB_Apellido" runat="server" MaxLength="20"></asp:TextBox>
        </div>

        <div class="campo">
            <asp:Label class="LB_FechaNacimiento" ID="LB_FechaNacimiento" runat="server" Text="Fecha Nacimiendo: "></asp:Label>
            <asp:TextBox class="TB_FechaNacimiento" ID="TB_FechaNacimiento" runat="server" TextMode="Date"></asp:TextBox>
        </div>

        <div class="campo">
            <asp:Label class="LB_TipoAfiliacion" ID="LB_TipoAfiliacion" runat="server" Text="Tipo Afiliacion: "></asp:Label>
            <asp:DropDownList class="DDL_TipoAfiliacion" ID="DDL_TipoAfiliacion" runat="server" DataSourceID="ODS_ObtenerTipoAfiliacion" DataTextField="nombre" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="DDL_TipoAfiliacion_SelectedIndexChanged"></asp:DropDownList>
            <asp:ObjectDataSource ID="ODS_ObtenerTipoAfiliacion" runat="server" SelectMethod="obtenerTipoAfiliacion" TypeName="DBTipoAfiliacion"></asp:ObjectDataSource>
        </div>

        <div class="campo">
            <asp:Label class="LB_Eps" ID="LB_Eps" runat="server" Text="EPS: "></asp:Label>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:DropDownList class="DDL_Eps" ID="DDL_Eps" runat="server" DataSourceID="ODS_ObtenerEps" DataTextField="nombre" DataValueField="id" Width="100%"></asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DDL_TipoAfiliacion" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:ObjectDataSource ID="ODS_ObtenerEps" runat="server" SelectMethod="obtenerEps" TypeName="DBEps"></asp:ObjectDataSource>
        </div>

        <div class="campo">
            <asp:Label class="LB_Correo" ID="LB_Correo" runat="server" Text="Correo electronico: "></asp:Label>
            <asp:TextBox class="TB_Correo" ID="TB_Correo" runat="server" TextMode="Email" MaxLength="50"></asp:TextBox>
        </div>

        <div class="campo">
            <asp:Label class="LB_Clave" ID="LB_Clave" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox class="TB_Clave" ID="TB_Clave" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
        </div>

        <div class="campo">
            <asp:Label class="LB_RepetirClave" ID="LB_RepetirClave" runat="server" Text="Repetir clave: "></asp:Label>
            <asp:TextBox class="TB_RepetirClave" ID="TB_RepetirClave" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
        </div>
        
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
        
    </div>

</asp:Content>

