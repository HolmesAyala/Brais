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
            /*background-color: red;*/
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

    </style>

    <asp:Label ID="LB_Titulo" runat="server" Text=""></asp:Label>

    <div class="formulario_usuario">

        <div class="campo">
        <asp:Label class="LB_Tipo_Documento" ID="LB_Tipo_Documento" runat="server" Text="Tipo de documento: "></asp:Label>
        <asp:DropDownList class="DDL_Tipo_Documento" ID="DDL_Tipo_Documento" runat="server" DataTextField="nombre" DataValueField="id" DataSourceID="ODS_ObtenerTipoDocumento">
        </asp:DropDownList>
            <asp:ObjectDataSource ID="ODS_ObtenerTipoDocumento" runat="server" SelectMethod="obtenerTipoIdentificacion" TypeName="DBTipoIdentificacion"></asp:ObjectDataSource>
        </div>

        <div class="campo">
            <asp:Label class="LB_Numero_Documento" ID="LB_Numero_Documento" runat="server" Text="Numero Documento: "></asp:Label>
            <asp:TextBox class="TB_Numero_Documento" ID="TB_Numero_Documento" runat="server"></asp:TextBox>
        </div>

        <div class="campo">
            <asp:Label class="LB_Nombre" ID="LB_Nombre" runat="server" Text="Nombres: "></asp:Label>
            <asp:TextBox class="TB_Nombre" ID="TB_Nombre" runat="server"></asp:TextBox>
        </div>

        <div class="campo">
            <asp:Label class="LB_Apellido" ID="LB_Apellido" runat="server" Text="Apellidos: "></asp:Label>
            <asp:TextBox class="TB_Apellido" ID="TB_Apellido" runat="server"></asp:TextBox>
        </div>

        <div class="campo">
            <asp:Label class="LB_FechaNacimiento" ID="LB_FechaNacimiento" runat="server" Text="Fecha Nacimiendo: "></asp:Label>
            <asp:TextBox class="TB_FechaNacimiento" ID="TB_FechaNacimiento" runat="server" TextMode="Date"></asp:TextBox>
        </div>

        <div class="campo">
            <asp:Label class="LB_TipoAfiliacion" ID="LB_TipoAfiliacion" runat="server" Text="Tipo Afiliacion: "></asp:Label>
            <asp:DropDownList class="DDL_TipoAfiliacion" ID="DDL_TipoAfiliacion" runat="server" DataSourceID="ODS_ObtenerTipoAfiliacion" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
            <asp:ObjectDataSource ID="ODS_ObtenerTipoAfiliacion" runat="server" SelectMethod="obtenerTipoAfiliacion" TypeName="DBTipoAfiliacion"></asp:ObjectDataSource>
        </div>
        <div class="campo">
            <asp:Label class="LB_Correo" ID="LB_Correo" runat="server" Text="Correo electronico: "></asp:Label>
            <asp:TextBox class="TB_Correo" ID="TB_Correo" runat="server" TextMode="Email"></asp:TextBox>
        </div>

        <div class="campo">
            <asp:Label class="LB_Clave" ID="LB_Clave" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox class="TB_Clave" ID="TB_Clave" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div class="campo">
            <asp:Label class="LB_RepetirClave" ID="LB_RepetirClave" runat="server" Text="Repetir clave: "></asp:Label>
            <asp:TextBox class="TB_RepetirClave" ID="TB_RepetirClave" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div class="campo">
            <asp:Button class="BTN_Accion" ID="BTN_Accion" runat="server" Text="BTN" OnClick="BTN_Accion_Click"></asp:Button>
        </div>

    </div>

</asp:Content>

