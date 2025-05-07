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
    public class ArbolDal
    {
        public static List<ArbolMod> Listar(out SalidaMod salida)
        {
            List<ArbolMod> arbol = new List<ArbolMod>();
            try
            {
                using (IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters parametros = ConexionFll.ObtenerParametros();
                    arbol = con.Query<ArbolMod>(
                        sql: @"arbol_L",
                        param: parametros,
                        commandType: CommandType.StoredProcedure).AsList();
                    salida = ConexionFll.ObtenerSalida(parametros);
                }
                return arbol;
            }
            catch (Exception ex)
            {
                salida = LogFll.RegistroException(ex);
                return arbol;
            }
        }
    }
}
