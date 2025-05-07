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
    public class EtapaDal
    {
        public static List<EtapaMod> Listar( out SalidaMod salida)
        {
            List<EtapaMod> etapas = new List<EtapaMod>();
            try
            {
                using (IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters parametros = ConexionFll.ObtenerParametros();
                    etapas = con.Query<EtapaMod>(
                         sql: @"etapa_L",
                         param: parametros,
                         commandType: CommandType.StoredProcedure).AsList();
                    salida = ConexionFll.ObtenerSalida(parametros);
                }
                return etapas;
            }
            catch (Exception ex)
            {
                salida = LogFll.RegistroException(ex);
                return etapas;
            }
        }


        public static List<EtapaMod> Listar(int documentoCodigo, out SalidaMod salida)
        {
            List<EtapaMod> etapas = new List<EtapaMod>();
            try
            {
                using (IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters parametros = ConexionFll.ObtenerParametros(new { doc_codigo = documentoCodigo});
                    etapas = con.Query<EtapaMod>(
                         sql: @"etapa_documento_L",
                         param: parametros,
                         commandType: CommandType.StoredProcedure).AsList();
                    salida = ConexionFll.ObtenerSalida(parametros);
                }
                return etapas;
            }
            catch (Exception ex)
            {
                salida = LogFll.RegistroException(ex);
                return etapas   ;
            }
        }
    }
}
