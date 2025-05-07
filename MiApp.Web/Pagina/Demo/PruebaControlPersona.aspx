<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina/Inicio/Master.Master" AutoEventWireup="true" CodeBehind="PruebaControlPersona.aspx.cs" Inherits="MiApp.Web.Pagina.Demo.PruebaControlPersona" %>

<%@ Register Assembly="DevExpress.Web.v21.2, Version=21.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Src="~/ControlUsuario/ControlPersona.ascx" TagPrefix="cup" TagName="ControlPersona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/Pagina/Demo/PruebaControlPersona.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <dx:ASPxCallbackPanel ID="AcpPruebaControlPersona" ClientInstanceName="AcpPruebaControlPersona" runat="server" Width="100%">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxFormLayout ID="AflPruebaControlPersona" runat="server" ColCount="4" ColumnCount="4" SettingsAdaptivity-GridSettings-StretchLastItem="True">
                    <Items>
                        <dx:LayoutItem Caption="Tipo Documento" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxComboBox runat="server" ID="AcbTipoDocumento" ClientInstanceName="AcbTipoDocumento" 
                                        DataSourceID="OdsTipoDocumento" ValueType="System.Int32" ValueField="Codigo" TextField="Glosa">
                                    </dx:ASPxComboBox>
                                    
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Rut" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButtonEdit runat="server" ID="AbeRut" ClientInstanceName="AbeRut">
                                        <ClientSideEvents ButtonClick="function(s, e) { LlamarControlPersona(); }"/>
                                        <Buttons>
                                            <dx:EditButton>
                                                <Image IconID="dashboards_enablesearch_svg_16x16"></Image>
                                            </dx:EditButton>
                                        </Buttons>
                                    </dx:ASPxButtonEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Nombre" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox runat="server" ID="AtxNombre" ClientInstanceName="AtxNombre"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:EmptyLayoutItem ColSpan="1  "></dx:EmptyLayoutItem>
                    </Items>
                </dx:ASPxFormLayout>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
    <asp:ObjectDataSource runat="server" ID="OdsTipoDocumento" SelectMethod="Listar" TypeName="MiApp.Bll.DocumentoBll">
        <SelectParameters>
            <asp:Parameter Direction="Output" Name="salida" Type="Object"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>
     <cup:ControlPersona ID="CPersona" runat="server"/> 
</asp:Content>
