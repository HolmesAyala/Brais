<%@ Page Title="" Language="C#" MasterPageFile="~/View/Medico/MPMedico.master" AutoEventWireup="true" CodeFile="~/Controller/Medico/horario_medico.aspx.cs" Inherits="View_Medico_horario_medico" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" Runat="Server">
    <div style="height:50px">
        &nbsp;
    </div>
    <CR:CrystalReportSource ID="CR_horar_medic" runat="server">
        <Report FileName="~\View\Medico\Reportes\Reporte_horario.rpt">
        </Report>
    </CR:CrystalReportSource>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" />
</asp:Content>

