using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Mod
{
    public class DocumentoMod
    {
        public int Codigo { get; set; }
        public string Glosa { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaMinima { get; set; }
        public DateTime FechaMaxima { get; set; }
        public int  Referencia { get; set; }
        public Int16 Descuento { get; set; }
        public string Clasificacion { get; set; }
        public bool  Marcado { get; set; }
        public double Total { get; set; }
        public PersonaMod Persona { get; set; }
        public TipoDocumentoMod TipoDocumento { get; set;}
        public List<EtapaMod> Etapas { get; set; }
        public List<ItemMod> Items { get; set; }


        public DocumentoMod(int doc_codigo, string doc_glosa, DateTime doc_fecha,
            DateTime doc_fecha_Minima, DateTime doc_fecha_Maxima, int doc_referencia, 
            Int16 doc_descuento, string doc_clasificacion, bool doc_marcado, double doc_total)
        { 
            Codigo = doc_codigo;
            Glosa = doc_glosa;
            Fecha = doc_fecha;
            FechaMinima = doc_fecha_Minima;
            FechaMaxima = doc_fecha_Maxima;
            Referencia = doc_referencia;    
            Descuento = doc_descuento;
            Clasificacion = doc_clasificacion;
            Marcado = doc_marcado;
            Total = doc_total;

        }

        public DocumentoMod(int codigo, string glosa, DateTime fecha,
            DateTime fechaMinima, DateTime fechaMaxima, int referencia,
            Int16 descuento, string clasificacion, bool marcado, double total,
            PersonaMod persona, TipoDocumentoMod tipoDocumento, List<EtapaMod> etapas, List<ItemMod> items)
            : this(codigo, glosa, fecha, fechaMaxima, fechaMinima, referencia,
                   descuento, clasificacion, marcado, total) 
        {
            Persona = persona;
            TipoDocumento = tipoDocumento;
            Etapas = etapas;
            Items = items;
        }   
    }
}
