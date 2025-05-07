using MiApp.Mod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiApp.Fll
{
    public class TipoSqlFll
    {
        public static DataTable ObtenerEtapas(DocumentoMod documento)
        {
            DataTable tablaEtapa = new DataTable();
            tablaEtapa.Columns.Add("eta_codigo");
            tablaEtapa.Columns.Add("doc_codigo");
            foreach (EtapaMod etapa in documento.Etapas)
            {
                tablaEtapa.Rows.Add(etapa.Codigo, documento.Codigo);
            }
            return tablaEtapa;
        }

        public static DataTable ObtenerItems(DocumentoMod documento) 
        {
            DataTable tablaItem = new DataTable();
            tablaItem.Columns.Add("itm_correlativo");
            tablaItem.Columns.Add("itm_glosa");
            tablaItem.Columns.Add("itm_valor");
            tablaItem.Columns.Add("doc_codigo");
            foreach (ItemMod item in documento.Items)
            {
                tablaItem.Rows.Add(item.Correlativo, item.Glosa, item.Valor, documento.Codigo);
            }
            return tablaItem;
        }
        public static DataTable ObtenerItems(List<ItemMod> items, int documentoCodigo) 
        {
            DataTable tablaItem = new DataTable();
            tablaItem.Columns.Add("itm_correlativo");
            tablaItem.Columns.Add("itm_glosa");
            tablaItem.Columns.Add("itm_valor");
            tablaItem.Columns.Add("doc_codigo");
            foreach (ItemMod item in items)
            {
                tablaItem.Rows.Add(item.Correlativo, item.Glosa, item.Valor, documentoCodigo);
            }
            return tablaItem;
        }

    }
}
