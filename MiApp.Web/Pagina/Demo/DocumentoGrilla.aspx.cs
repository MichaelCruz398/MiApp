using DevExpress.Spreadsheet;
using DevExpress.Web;
using DevExpress.WebUtils;
using DevExpress.XtraRichEdit.Commands;
using MiApp.Bll;
using MiApp.Fll;
using MiApp.Mod;
using MiApp.Web.Reporte;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MiApp.Web.Pagina.Demo
{
    public partial class DocumentoGrilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AcpDocumentoGrilla_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            try
            {
                if (e.Parameter.Split(',')[0].Equals("InyectaItems"))
                {
                    List<ItemMod> items = new List<ItemMod>();
                    CellRange rango = AsdItem.Document.Worksheets.ActiveWorksheet.GetUsedRange();
                    if (rango != null && rango.RowCount > 1)
                    {
                        for (int i = 1; i < rango.RowCount; i++)
                        {
                            items.Add(
                                new ItemMod(
                                    Convert.ToInt32(rango[i, 0].Value.NumericValue),
                                    rango[i, 1].Value.TextValue,
                                    Convert.ToDouble(rango[i, 2].Value.NumericValue)
                                ));
                        }
                        if (items.Count > 0)
                        {
                            int documentoCodigo = (int)AgvDocumentoGrilla.GetRowValues(AgvDocumentoGrilla.FocusedRowIndex, AgvDocumentoGrilla.KeyFieldName);
                            ItemBll.Inyectar(items, documentoCodigo, out SalidaMod salida);
                            if (salida.Codigo > 0)
                            {
                                AcpDocumentoGrilla.JSProperties["cpItemsInyectados"] = true;
                            }
                            VistaFll.AgregarSalida(AcpDocumentoGrilla, salida);
                        }
                        else
                        {
                            VistaFll.AgregarSalida(AcpDocumentoGrilla, new SalidaMod(0, "el documento no tiene Items."));
                        }
                    }
                    else
                    {
                        VistaFll.AgregarSalida(AcpDocumentoGrilla, new SalidaMod(0, "Cargue un documento."));
                    }
                }
            }
            catch (Exception ex)
            {
                VistaFll.AgregarSalida(AcpDocumentoGrilla, LogFll.RegistroException(ex));
            }
        }

        protected void OdsItems_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            SalidaMod salida;
            try
            {
                salida = e.OutputParameters["salida"] as SalidaMod;
            }
            catch (Exception ex)
            {
                salida = LogFll.RegistroException(ex);
            }
            VistaFll.AgregarSalida(AgvDocumentoGrilla, salida);
        }

        protected void OdsDocumentoGrilla_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            SalidaMod salida;
            try
            {
                salida = e.OutputParameters["salida"] as SalidaMod;
            }
            catch (Exception ex)
            {
                salida = LogFll.RegistroException(ex);
            }
            VistaFll.AgregarSalida(AgvDocumentoGrilla, salida);
        }

        protected void OdsEtapa_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            SalidaMod salida;
            try
            {
                salida = e.OutputParameters["salida"] as SalidaMod;
            }
            catch (Exception ex)
            {
                salida = LogFll.RegistroException(ex);
            }
            VistaFll.AgregarSalida(AgvDocumentoGrilla, salida);
        }

        protected void AgvItems_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["documentoCodigo"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void AgvEtapa_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["documentoCodigo"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }


        protected void OdsDocumentoGrilla_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            SalidaMod salida;
            try
            {
                salida = e.OutputParameters["salida"] as SalidaMod;
            }
            catch (Exception ex)
            {
                salida = LogFll.RegistroException(ex);
            }
            VistaFll.AgregarSalida(AgvDocumentoGrilla, salida);
        }

        protected void UplItem_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string ruta = null;
            try
            {
                if (e.UploadedFile.IsValid)
                {
                    FileInfo nombreArchivo = new FileInfo(e.UploadedFile.FileName);
                    ruta = HttpContext.Current.Server.MapPath("~/App_Data/") + nombreArchivo.Name;
                    e.UploadedFile.SaveAs(ruta);
                }
                Session["ruta"] = ruta;
            }
            catch (Exception ex)
            {
                Session["ruta"] = ruta;
                LogFll.RegistroException(ex);
            }
        }

        protected void AgvDocumentoGrilla_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
        {
            if (e.Item.Name.Equals("Print"))
            {
                List<DocumentoMod> documentos = (List<DocumentoMod>)OdsDocumentoGrilla.Select();
                foreach (DocumentoMod documento in documentos)
                {
                    documento.Items = ItemBll.Listar(documento.Codigo, out _);
                    documento.Etapas = EtapaBll.Listar(documento.Codigo, out _);
                }
                XtraDocumentoGrilla xtraDocumentoGrilla = new XtraDocumentoGrilla
                {
                    DataSource = documentos
                };
                xtraDocumentoGrilla.Parameters["titulo"].Value = "Documentos de grilla";
                xtraDocumentoGrilla.Parameters["usuario"].Value = "Michael";
                Session["reporte"] = xtraDocumentoGrilla;
                AgvDocumentoGrilla.JSProperties["cpImprimir"] = true;

            }
        }
        protected void AsdItem_Callback(object sender, CallbackEventArgsBase e)
        {
            if (Session["ruta"] != null)
            {
                string ruta = Session["ruta"].ToString();
                AsdItem.Document.History.Clear();
                AsdItem.Open(ruta);
            }
        }

        protected void AgvDocumentoGrilla_BeforeExport(object sender, ASPxGridBeforeExportEventArgs e)
        {
            AgvDocumentoGrilla.Columns[0].Visible = false;
            AgvDocumentoGrilla.Columns["Total"].Visible = false;
            AgvDocumentoGrilla.Columns["FechaMinima"].ExportCellStyle.HorizontalAlign = HorizontalAlign.Center;
            AgvDocumentoGrilla.Columns["FechaMinima"].ExportWidth = 300;
            AgvDocumentoGrilla.Columns["FechaMinima"].ExportCellStyle.BackColor = System.Drawing.Color.Red;
            AgvDocumentoGrilla.StylesExport.Header.BackColor = System.Drawing.Color.Blue;
        }
    }
}





