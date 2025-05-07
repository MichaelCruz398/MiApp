 using DevExpress.Office.Utils;
using MiApp.Fll;
using MiApp.Mod;
using MiApp.Web.Reporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiApp.Web.Pagina.Inicio
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void OdsUsuario_IUing(object sender, ObjectDataSourceMethodEventArgs e)
        {
            try
            {
                VistaFll.NormalizarLlave(e);
            }
            catch (Exception ex)
            {
                SalidaMod salida = LogFll.RegistroException(ex);
                VistaFll.AgregarSalida(AgvUsuario, salida);
            }
        }

        protected void OdsUsuario_Selected(object sender, ObjectDataSourceStatusEventArgs e)
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
            if (salida.Codigo <= 0) 
            {
                VistaFll.AgregarSalida(AgvUsuario, salida);
            }
        }
        protected void OdsUsuario_IUDed(object sender, ObjectDataSourceStatusEventArgs e)
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
            VistaFll.AgregarSalida(AgvUsuario, salida);

        }

        protected void AgvUsuario_StarRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            AgvUsuario.EditFormLayoutProperties.Items[3].ColumnSpan = 1;
            AgvUsuario.EditFormLayoutProperties.FindItemOrGroupByName("Codigo").Visible = true;
            AgvUsuario.DataBind();
        }

        protected void AgvUsuario_ToolbarItemClick(object source, DevExpress.Web.Data.ASPxGridViewToolbarItemClickEventArgs e)
        {
            if (e.Item.Name.Equals("Print"))
            {
                XtraUsuario xtraUsuario = new XtraUsuario
                {
                    DataSource = (List<UsuarioMod>)OdsUsuario.Select()
                };
                AgvUsuario.JSProperties["cpImprimir"] = true;
                Session["reporte"] = xtraUsuario;
            }
         
        }

        protected void OdsPerfil_Selected(object sender, ObjectDataSourceStatusEventArgs e)
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
            if (salida.Codigo <= 0)
            {
                VistaFll.AgregarSalida(AgvUsuario, salida);
            }
        }
    }
}