<%@ Page Title="Vista Reporte" Language="C#" MasterPageFile="~/Pagina/Inicio/Master.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="MiApp.Web.Pagina.Varios.Reporte" %>

<%@ Register Assembly="DevExpress.XtraReports.v21.2.Web.WebForms, Version=21.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <dx:ASPxWebDocumentViewer ID="AwdReporte" runat="server"></dx:ASPxWebDocumentViewer>
</asp:Content>
