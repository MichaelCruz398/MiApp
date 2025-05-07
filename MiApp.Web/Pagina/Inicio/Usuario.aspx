<%@ Page Title="Usuario" Language="C#" MasterPageFile="~/Pagina/Inicio/Master.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="MiApp.Web.Pagina.Inicio.Usuario" %>

<%@ Register Assembly="DevExpress.Web.v21.2, Version=21.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/Pagina/Inicio/Usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
     <dx:ASPxCallbackPanel ID="AcpUsuario" runat="server" Width="100%">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxPanel ID="AplTitulo" ClientInstanceName="AplTitulo" runat="server" Width="100%">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <dx:ASPxLabel ID="AlbTitulo" runat="server" Text="Usuarios" Font-Bold="true"></dx:ASPxLabel>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
                <dx:ASPxGridView ID="AgvUsuario" ClientInstanceName="AgvUsuario" runat="server" DataSourceID="OdsUsuario" AutoGenerateColumns="false" KeyFieldName="Codigo" Width="100%"
                    OnStartRowEditing="AgvUsuario_StarRowEditing" OnToolbarItemClick="AgvUsuario_ToolbarItemClick">
                    <ClientSideEvents EndCallback="function(s, e) { EndCallbackAgvUsuario(s); }" ToolbarItemClick="function(s, e) { OnToolbarItemClick(s, e); }"></ClientSideEvents>
                    <SettingsExport FileName="salida" EnableClientSideExportAPI="True"></SettingsExport>
                    <SettingsPager Mode="ShowAllRecords"></SettingsPager>

                    <Settings ShowFilterRowMenu="True" ShowHeaderFilterButton="True" VerticalScrollBarMode="Auto" />

                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />

                    <EditFormLayoutProperties ColCount="4" ColumnCount="4">
                        <Items>
                            <dx:GridViewColumnLayoutItem ColumnName="Codigo" Name="Codigo" ColSpan="1" Visible="false"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="Nombre" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColumnName="Perfil.Codigo" ColSpan="1"></dx:GridViewColumnLayoutItem>
                            <dx:GridViewColumnLayoutItem ColSpan="2" ColumnSpan="2" HorizontalAlign="Right" VerticalAlign="Bottom" ShowCaption="False">
                                <Template>
                                    <dx:ASPxButton ID="AbnUsuarioGuardar" runat="server" Text="Guardar" AutoPostBack="false" UseSubmitBehavior="false" RenderMode="Secondary" Width="50%">
                                        <ClientSideEvents Click="function(s, e) { ConfirmarUsuarioGuardar(AgvUsuario); }" />
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="AbnUsuarioCancelar" runat="server" Text="Cancelar" AutoPostBack="false" UseSubmitBehavior="false" RenderMode="Danger" Width="50%">
                                        <ClientSideEvents Click="function(s, e) { ConfirmarUsuarioCancelar(AgvUsuario); }" />
                                    </dx:ASPxButton>
                                </Template>
                                <SpanRules>
                                    <dx:SpanRule BreakpointName="s" ColumnSpan="2" RowSpan="1" />
                                    <dx:SpanRule BreakpointName="m" ColumnSpan="1" RowSpan="1" />
                                    <dx:SpanRule BreakpointName="l" ColumnSpan="2" RowSpan="1" />
                                </SpanRules>
                            </dx:GridViewColumnLayoutItem>
                        </Items>
                        <SettingsAdaptivity>
                            <GridSettings>
                                <Breakpoints>
                                    <dx:LayoutBreakpoint Name="s" MaxWidth="768" ColumnCount="2" />
                                    <dx:LayoutBreakpoint Name="m" MaxWidth="992" ColumnCount="3" />
                                    <dx:LayoutBreakpoint Name="l" MaxWidth="1200" ColumnCount="4" />
                                </Breakpoints>
                            </GridSettings>
                        </SettingsAdaptivity>
                    </EditFormLayoutProperties>
                    <Columns>
                        <dx:GridViewDataSpinEditColumn FieldName="Codigo" VisibleIndex="0" Caption="Codigo" ReadOnly="true">
                            <PropertiesSpinEdit DisplayFormatString="g" NumberType="Integer">
                                <SpinButtons ClientVisible="false"></SpinButtons>
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataTextColumn FieldName="Nombre" VisibleIndex="1" Caption="Nombre">
                            <PropertiesTextEdit MaxLength="150">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Nombre requerido"></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="Perfil.Codigo" VisibleIndex="2" Caption="Pefil">
                            <PropertiesComboBox ValueType="System.Int32" DataSourceID="OdsPerfil" TextField="Glosa" ValueField="Codigo">
                                    <ValidationSettings>
                                        <RequiredField IsRequired="true" ErrorText="Perfil Requerido"/>
                                    </ValidationSettings>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                    </Columns>
                    <Toolbars>
                        <dx:GridViewToolbar>
                            <Items>
                                <dx:GridViewToolbarItem Command="New"></dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Command="Edit"></dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Name="Delete" Text="Eliminar" ToolTip="Eliminar">
                                    <Image IconID="xaf_action_delete_svg_16x16" />
                                </dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Command="Refresh"></dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Command="ExportToXlsx"></dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Name="Print" ToolTip=" Imprimir" Text=" Imprimir"
                                    NavigateUrl="../Varios/Reporte.aspx">
                                    <Image IconID="print_print_svg_16x16"></Image>
                                </dx:GridViewToolbarItem>
                            </Items>
                        </dx:GridViewToolbar>
                    </Toolbars>
                </dx:ASPxGridView>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
    <asp:ObjectDataSource ID="OdsUsuario" runat="server" SelectMethod="Listar" TypeName="MiApp.Bll.UsuarioBll" DeleteMethod="Eliminar" InsertMethod="InsertarActualizar" UpdateMethod="InsertarActualizar"
        OnInserting="OdsUsuario_IUing" OnUpdating="OdsUsuario_IUing" OnSelected="OdsUsuario_Selected" OnInserted="OdsUsuario_IUDed" OnDeleted="OdsUsuario_IUDed">
        <DeleteParameters>
            <asp:Parameter Name="Codigo" Type="Int32"></asp:Parameter>
            <asp:Parameter Direction="Output" Name="salida" Type="Object"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Codigo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Nombre" Type="String"></asp:Parameter>
            <asp:Parameter Name="perfil.Codigo" Type="Int32"></asp:Parameter>
            <asp:Parameter Direction="Output" Name="salida" Type="Object"></asp:Parameter>
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter Direction="Output" Name="salida" Type="Object"></asp:Parameter>
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Codigo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Nombre" Type="String"></asp:Parameter>
            <asp:Parameter Name="perfil.Codigo" Type="Int32"></asp:Parameter>
            <asp:Parameter Direction="Output" Name="salida" Type="Object"></asp:Parameter>
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsPerfil" runat="server" SelectMethod="Listar" TypeName="MiApp.Bll.PerfilBll" OnSelected="OdsPerfil_Selected">
        <SelectParameters>
            <asp:Parameter Direction="Output" Name="salida" Type="Object"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>
