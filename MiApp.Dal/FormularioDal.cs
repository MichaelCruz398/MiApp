using Dapper;
using MiApp.Fll;
using MiApp.Mod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Dal
{
    public class FormularioDal
    {
        public static List<FormularioMod> Listar(string url, out SalidaMod salida)
        {
            List<FormularioMod> formularios = new List<FormularioMod>();
            try
            {
                using (IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters parametros = ConexionFll.ObtenerParametros(new { frm_url = url});
                    formularios = con.Query<FormularioMod>(
                        sql: @"formulario_L",
                        param: parametros,
                        commandType: CommandType.StoredProcedure).AsList();
                    salida = ConexionFll.ObtenerSalida(parametros);
                }
                return formularios;
            }
            catch (Exception ex)
            {
                salida = LogFll.RegistroException(ex);
                return formularios;
            }
        }
    }
}
