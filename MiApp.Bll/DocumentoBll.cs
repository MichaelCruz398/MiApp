using MiApp.Dal;
using MiApp.Fll;
using MiApp.Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Bll
{
    public class DocumentoBll
    {

        public static List<DocumentoMod> Listar(out SalidaMod salida)
        {
            try
            {
                return DocumentoDal.Listar(out salida);
            }
            catch (Exception ex) 
            {
                salida = LogFll.RegistroException(ex);
                return new List<DocumentoMod>();
            }
        }


        public static void Insertar(int codigo, string glosa, DateTime fecha,
            DateTime fechaMinima, DateTime fechaMaxima, int referencia,
            Int16 descuento, string clasificacion, bool marcado, double total,
            PersonaMod persona, TipoDocumentoMod tipoDocumento,
            List<EtapaMod> etapas, List<ItemMod> items, out SalidaMod salida)
        {
            try
            {
                DocumentoMod documento = new DocumentoMod(codigo, glosa, fecha, fechaMinima, fechaMaxima, referencia, descuento, clasificacion, marcado, total,
                    persona, tipoDocumento, etapas, items);
                DocumentoDal.Insertar(documento, out salida);
            }
            catch (Exception e) 
            {
                salida = LogFll.RegistroException(e);
            }
        }
        public static void Eliminar(int Codigo, out SalidaMod salida)
        {
            try
            {
                DocumentoDal.Eliminar(Codigo, out salida);
            }
            catch (Exception e)
            {
                salida = LogFll.RegistroException(e) ;
            }
        }
    }
}
