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
    public class ModuloDal
    {
        public static List<ModuloMod> Listar(out SalidaMod salida) 
        {
            List<ModuloMod> modulos = new List<ModuloMod>();
            try
            {
                using (IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters parametros = ConexionFll.ObtenerParametros();
                    modulos = con.Query<ModuloMod>(
                        sql: @"modulo_L",
                        param: parametros,
                        commandType: CommandType.StoredProcedure).AsList();
                    salida = ConexionFll.ObtenerSalida(parametros);
                }
                return modulos;
            }
            catch (Exception ex)
            {
                salida = LogFll.RegistroException(ex);
                return modulos;
            }
        }
    }
}
