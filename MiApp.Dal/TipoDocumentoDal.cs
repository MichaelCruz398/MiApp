using Dapper;
using MiApp.Fll;
using MiApp.Mod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Dal
{
    public class TipoDocumentoDal
    {
        public static List<TipoDocumentoMod> Listar(out SalidaMod salida)
        {
            List<TipoDocumentoMod> perfiles = new List<TipoDocumentoMod>();
            try
            {
                using (IDbConnection con = ConexionFll.ConectarPrueba()) 
                {
                    DynamicParameters parametros = ConexionFll.ObtenerParametros();
                    perfiles = con.Query<TipoDocumentoMod>(
                         sql: @"tipo_documento_L",
                         param: parametros,
                         commandType: CommandType.StoredProcedure).ToList();
                    salida = ConexionFll.ObtenerSalida(parametros);
                }
                return perfiles;
            }
            catch (Exception ex) 
            {
                    salida = LogFll.RegistroException(ex);
                    return perfiles;
            }
        }
    }
}
