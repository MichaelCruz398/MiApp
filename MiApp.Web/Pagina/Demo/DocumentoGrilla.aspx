 <%@ Page Title="Documentos Grilla" Language="C#" MasterPageFile="~/Pagina/Inicio/Master.Master" AutoEventWireup="true" CodeBehind="DocumentoGrilla.aspx.cs" Inherits="MiApp.Web.Pagina.Demo.DocumentoGrilla" %>

<%@ Register Assembly="DevExpress.Web.ASPxSpreadsheet.v21.2, Version=21.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpreadsheet" TagPrefix="dx"  %>

<%@ Register Assembly="DevExpress.Web.v21.2, Version=21.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/Pagina/Demo/DocumentoGrilla.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
      <dx:ASPxCallbackPanel ID="AcpDocumentoGrilla" ClientInstanceName="AcpDocumentoGrilla" runat="server" Width="100%"
        OnCallback="AcpDocumentoGrilla_Callback">
        <ClientSideEvents EndCallback="function(s, e) { EndCallbackAgvDocumentoGrilla(s); }" />
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxPanel ID="AplTitulo" ClientInstanceName="AplTitulo" runat="server" Width="100%">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <dx:ASPxLabel ID="AlbTitulo" runat="server" Text="Documentos Grilla" Font-Bold="true"></dx:ASPxLabel>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
                <dx:ASPxButton ID="AbnDesEnfocar" runat="server" Text="DesEnfocar" UseSubmitBehavior="false" AutoPostBack="false">
                    <ClientSideEvents Click="function(s, e) { DesEnfocar(); }" />
                </dx:ASPxButton>
                <dx:ASPxButton ID="AbnEliminar" runat="server" Text="Eliminar Desde Fuera" UseSubmitBehavior="false" AutoPostBack="false">
                    <ClientSideEvents Click="function(s, e) { EliminarDesdeFuera(); }" />
                </dx:ASPxButton>
                <dx:ASPxGridView ID="AgvDocumentoGrilla" ClientInstanceName="AgvDocumentoGrilla" runat="server"
                    AutoGenerateColumns="False" DataSourceID="OdsDocumentoGrilla"
                    KeyFieldName="Codigo" Width="100%" OnToolbarItemClick="AgvDocumentoGrilla_ToolbarItemClick"
                    OnBeforeExport="AgvDocumentoGrilla_BeforeExport">
                    <ClientSideEvents EndCallback="function(s, e) { EndCallbackAgvDocumentoGrilla(s); }"
                        CustomButtonClick="function(s, e) { LevantarPopUpInyectarItems(s, e)}"
                        ToolbarItemClick="function(s, e) { OnToolbarItemClick(s, e); }" />
                    <SettingsPager Mode="ShowAllRecords" />
                    <SettingsBehavior AllowFocusedRow="true" />
                    <SettingsDetail ShowDetailRow="true" ExportMode="All" />
                    <Settings ShowFilterRowMenu="True" ShowHeaderFilterButton="True" VerticalScrollBarMode="Auto" />
                    <SettingsExport EnableClientSideExportAPI="true" FileName="DocumentosGrilla" ExcelExportMode="WYSIWYG" />
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Codigo" VisibleIndex="0"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Glosa" VisibleIndex="1"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="Fecha" VisibleIndex="2"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="FechaMinima" VisibleIndex="3"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="FechaMaxima" VisibleIndex="4"></dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="Referencia" VisibleIndex="5"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Descuento" VisibleIndex="6"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Clasificacion" VisibleIndex="7"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn FieldName="Marcado" VisibleIndex="8"></dx:GridViewDataCheckColumn>
                        <dx:GridViewDataTextColumn FieldName="Total" VisibleIndex="9"></dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn ButtonRenderMode="Button" VisibleIndex="10">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="InyectarItems" Text="Inyectar Items"></dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                        </dx:GridViewCommandColumn>
                    </Columns>
                    <Templates>
                        <DetailRow>
                            <dx:ASPxPageControl ID="ApgDocumentoGrilla" runat="server" Width="100%" ActiveTabIndex="0">
                                <TabPages>
                                    <dx:TabPage Text="Items">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:ASPxGridView ID="AgvItems" runat="server" AutoGenerateColumns="False" Width="100%" DataSourceID="OdsItems"
                                                    OnBeforePerformDataSelect="AgvItems_BeforePerformDataSelect">
                                                    <Settings ShowFilterRowMenu="true" ShowHeaderFilterButton="true" />
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="Correlativo" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Glosa" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Valor" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                                    </Columns>
                                                </dx:ASPxGridView>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <dx:TabPage Text="Etapas">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:ASPxGridView ID="AgvEtapa" runat="server" AutoGenerateColumns="False" Width="100%" DataSourceID="OdsEtapa"
                                                    OnBeforePerformDataSelect="AgvEtapa_BeforePerformDataSelect">
                                                    <Settings ShowFilterRowMenu="true" ShowHeaderFilterButton="true" />
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="Codigo" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Glosa" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                                    </Columns>
                                                </dx:ASPxGridView>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                </TabPages>
                            </dx:ASPxPageControl>
                        </DetailRow>
                    </Templates>
                    <Toolbars>
                        <dx:GridViewToolbar>
                            <Items>
                                <dx:GridViewToolbarItem Command="ExportToXlsx"></dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Command="Refresh"></dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Name="Print" ToolTip="Imprimir" Text="Imprimir">
                                    <Image IconID="print_print_svg_16x16"></Image>
                                </dx:GridViewToolbarItem>
                            </Items>
                        </dx:GridViewToolbar>
                    </Toolbars>
                </dx:ASPxGridView>
                <dx:ASPxPopupControl ID="ApcItem" ClientInstanceName="ApcItem" runat="server" Width="500px" HeaderText="Items"
                    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AutoUpdatePosition="true" Modal="true" CloseAction="CloseButton">
                    <ContentCollection>
                        <dx:PopupControlContentControl runat="server">
                            <dx:ASPxUploadControl ID="UplItem" runat="server" UploadMode="Auto" OnFileUploadComplete="UplItem_FileUploadComplete" AutoStarUpload="true">
                                <ValidationSettings AllowedFileExtensions=".xls, .xlsx" DisableHttpHandlerValidation="true"></ValidationSettings>
                                <ClientSideEvents FileUploadComplete="function(s, e) { LlamarAsdItem(); }"></ClientSideEvents>
                            </dx:ASPxUploadControl>
                            <dx:ASPxButton ID="AbnInyectar" runat="server" Text="Inyectar Items" AutoPostBack="false" UseSubmitBehavior="false">
                                <ClientSideEvents Click="function(s, e) { InyectarDocumento();  }" />
                            </dx:ASPxButton>
                            <dx:ASPxSpreadsheet ID="AsdItem" ClientInstanceName="AsdItem" runat="server" ShowSheetTabs="false" ShowFormulaBar="false" RibbonMode="None" OnCallback="AsdItem_Callback"></dx:ASPxSpreadsheet>
                        </dx:PopupControlContentControl>
                    </ContentCollection>
                </dx:ASPxPopupControl>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
    <asp:ObjectDataSource ID="OdsDocumentoGrilla" runat="server" SelectMethod="Listar" TypeName="MiApp.Bll.DocumentoBll" DeleteMethod="Eliminar"
        OnSelected="OdsDocumentoGrilla_Selected" OnDeleted="OdsDocumentoGrilla_Deleted">
        <DeleteParameters>
            <asp:Parameter Name="codigo" Type="Int32"></asp:Parameter>
            <asp:Parameter Direction="Output" Name="salida" Type="Object"></asp:Parameter>
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter Direction="Output" Name="salida" Type="Object"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsItems" runat="server" SelectMethod="Listar" TypeName="MiApp.Bll.ItemBll" OnSelected="OdsItems_Selected">
        <SelectParameters>
            <asp:SessionParameter Name="documentoCodigo" SessionField="documentoCodigo" Type="Int32"></asp:SessionParameter>
            <asp:Parameter Direction="Output" Name="salida" Type="Object"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsEtapa" runat="server" SelectMethod="Listar" TypeName="MiApp.Bll.EtapaBll" OnSelected="OdsEtapa_Selected">
        <SelectParameters>
            <asp:SessionParameter Name="documentoCodigo" SessionField="documentoCodigo" Type="Int32"></asp:SessionParameter>
            <asp:Parameter Direction="Output" Name="salida" Type="Object"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>
