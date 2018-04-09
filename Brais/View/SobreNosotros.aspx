<%@ Page Title="" Language="C#" MasterPageFile="~/View/MPHeaderFooter.master" AutoEventWireup="true" CodeFile="~/Controller/SobreNosotros.aspx.cs" Inherits="View_SobreNosotros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        section .contenido{
            height: 400px;
        }
        section h2 {
            text-align: center;
        }
        tr {
            height: 100px;
        }
        .mision {
            width: 100%;
        }
        img {
            width: 100%;
        }
        .img-sobre-nosotros {
            width: 70%;
        }
        .img {
            width: 40%;
        }
        .mision-vision {
            margin: 10px;
            padding: 30px;
            text-align: center;
        }
        .subtitulos {
            width: 10%;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
        <br />
        <h2>Misión y visión</h2>
        <br />
    </section>
    <section class="contenido">
        <table class="mision">
            <tr>
                <td rowspan="2"class="img">
                    <img alt="Hospital.png" class="img-sobre-nosotros" src="../Imagen/sobreNosotros.png" />
                </td>
                <td class="subtitulos">
                    <strong>Misión:</strong>
                </td>
                <td class="mision-vision">
                    Brais es una herramienta a dispocisión de los ciudadanos que quiere brindar la oportunidad a sus pacientes 
                    de sacar citas sin complicaciones.

                </td> 
            </tr>
            <tr>
                <td class="subtitulos">
                    <strong>Visión:</strong> 
                </td>
                <td class="mision-vision">
                    Para mayo de 2018 ser unos estudiantes que pasen el limpio el semestre.
                    Siendo reconocidos a nivel maestral.
                </td>
            </tr>
        </table>
    </section>
</asp:Content>

