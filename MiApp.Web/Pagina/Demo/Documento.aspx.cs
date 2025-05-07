 using MiApp.Bll;
using MiApp.Fll;
using MiApp.Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiApp.Web.Pagina.Demo
{
    public partial class Documento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       protected void AcbPersona_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            try
            { 
                if (!string.IsNullOrEmpty(e.Parameter))
                {
                    int tipoDocumento =  Convert.ToInt32(e.Parameter);
                    List<PersonaMod> personas = PersonaBll.Listar(tipoDocumento, out SalidaMod salida);
                    Session["Personas"] = personas;
                    AcbPersona.DataSource = personas;
                    AcbPersona.DataBind();  
                }
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        protected void AgvItems_Init(object sender, EventArgs e)
        {
            try
            {
                List<ItemMod> item = Session["items"] != null ? Session["items"] as List<ItemMod> : new List<ItemMod>();
                AgvItems.DataSource = item;
                AgvItems.DataBind();
            }
            catch (Exception ex)
            {
                VistaFll.AgregarSalida(AgvItems, LogFll.RegistroException(ex));
            }
        }

        protected void AgvItems_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                List<ItemMod> items = Session["items"] != null ? Session["items"] as List<ItemMod> : new List<ItemMod>();
                items.Add(new ItemMod(items.Count + 1, e.NewValues[0].ToString(), double.Parse(e.NewValues[1].ToString())));
                AgvItems.DataSource = items;
                Session["items"] = items;
                AgvItems.DataBind();
                AgvItems.CancelEdit();
                e.Cancel = true;
            }
            catch (Exception ex)
            { 
                VistaFll.AgregarSalida(AgvItems,LogFll.RegistroException(ex));
            }
            }

        protected void AgvItems_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                List<ItemMod> items = Session["items"] != null ? Session["items"] as List<ItemMod> : new List<ItemMod>();
                items.Find(x => x.Correlativo == int.Parse(e.Keys[0].ToString())).Glosa = e.NewValues[0].ToString();
                items.Find(x => x.Correlativo == int.Parse(e.Keys[0].ToString())).Valor = double.Parse(e.NewValues[1].ToString());
                AgvItems.DataSource = items;
                Session["items"] = items;
                AgvItems.DataBind();
                AgvItems.CancelEdit();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                VistaFll.AgregarSalida(AgvItems, LogFll.RegistroException(ex));
            }
        }

        protected void AgvItems_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                List<ItemMod> items = Session["items"] != null ? Session["items"] as List<ItemMod> : new List<ItemMod>();
                items.RemoveAll(x => x.Correlativo == int.Parse(e.Keys[0].ToString()));
                Session["items"] = items;
                AgvItems.DataSource = items;    
                AgvItems.DataBind();
                e.Cancel = true;    
            }
            catch (Exception ex)
            {
                VistaFll.AgregarSalida(AgvItems, LogFll.RegistroException(ex));
            }
        }

        protected void AcpDocumento_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            try
            {
                int codigo = 0;
                string glosa = AtxGlosa.Text;
                DateTime fecha = AdeEmision.Date;
                DateTime fechaMinima = AdeDesde.Date;       
                DateTime fechaMaxima = AdeHasta.Date;
                int referencia = Convert.ToInt32(AseReferencia.Number);
                Int16 descuento = Convert.ToInt16(AseDescuento.Number);
                string clasificacion = ArlClasificacion.SelectedItem.Value.ToString();
                bool marcado = AcxMarcado.Checked;
                double total = 0;
                PersonaMod persona = new PersonaMod(Convert.ToInt32(AcbPersona.SelectedItem.Value));
                TipoDocumentoMod tipoDocumento = new TipoDocumentoMod(Convert.ToInt32(AcbTipoDocumento.SelectedItem.Value));
                List<ItemMod> Items = (List<ItemMod>)Session["items"];
                List<EtapaMod> etapas = new List<EtapaMod>();
                foreach (string etapa in AtbEtapa.Value.ToString().Split(','))
                {
                    etapas.Add(new EtapaMod(Convert.ToInt32(etapa)));
                }
                DocumentoBll.Insertar(codigo, glosa, fecha, fechaMinima, fechaMaxima, referencia, descuento, clasificacion,
                    marcado, total, persona, tipoDocumento, etapas, Items, out SalidaMod salida);
                AcpDocumento.JSProperties["cpLimpiar"] = salida.Codigo >= 1;
                VistaFll.AgregarSalida(AcpDocumento, salida);
            }catch (Exception ex)   
            {
                VistaFll.AgregarSalida(AcpDocumento, LogFll.RegistroException(ex));
            }
            }

        protected void AcbPersona_Init(object sender, EventArgs e)
        {
            try
            {
                if (Session["personas"] != null)
                {
                    AcbPersona.DataSource = (List<PersonaMod>)Session["personas"];
                    AcbPersona.DataBind();
                }
            }
            catch (Exception ex) 
            {
                VistaFll.AgregarSalida(AcbPersona, LogFll.RegistroException(ex));
            }
        }
    }
}