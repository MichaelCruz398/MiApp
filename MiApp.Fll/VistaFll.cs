using DevExpress.Web;
using MiApp.Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace MiApp.Fll
{
    public class VistaFll
    {
        public static void AgregarSalida(object control, SalidaMod salida)
        {
            Type type = control.GetType();
            if (type.Name.Equals("ASPxGridView"))
            {
                ASPxGridView gridView = (ASPxGridView)control;
                gridView.JSProperties["cpCodigo"] = salida.Codigo;
                gridView.JSProperties["cpMensaje"] = salida.Mensaje;    
            }
            else if (type.Name.Equals("ASPxCallbacpanel"))
            {
                ASPxCallbackPanel callbackPanel = (ASPxCallbackPanel)control;
                callbackPanel.JSProperties["cpCodigo"] = salida.Codigo;
                callbackPanel.JSProperties["cpMensajes"] = salida.Mensaje;
            }
        }
        public static void NormalizarLlave(ObjectDataSourceMethodEventArgs e)
        {
            int largo = e.InputParameters.Count;
            string[] llaves = new string[largo];
            object[] valores = new object[largo];
            e.InputParameters.Keys.CopyTo(llaves, 0);
            e.InputParameters.Values.CopyTo(valores, 0);
            e.InputParameters.Clear();
            for (int i = 0; i < largo; i++)
            {
                e.InputParameters.Insert(i, llaves[i].Replace(".", string.Empty), valores[i]);
            }
        }
    }
}
