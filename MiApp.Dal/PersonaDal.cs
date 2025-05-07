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
    public class PersonaDal
    {
        public static List<PersonaMod> Listar(int tipoDocumento, out SalidaMod salida)
        {
            List<PersonaMod> perfiles = new List<PersonaMod>();
            try
            {
                using (IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters parametros = ConexionFll.ObtenerParametros(new { tpd_codigo = tipoDocumento });
                    perfiles = con.Query<PersonaMod>(
                         sql: @"persona_L",
                         param: parametros,
                         commandType: CommandType.StoredProcedure).AsList();
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
