 using Dapper;
using MiApp.Fll;
using MiApp.Mod;
using System;
using System.Collections.Generic;
using System.Data;


namespace MiApp.Dal
{
    public class PerfilDal
    {
        public static List<PerfilMod> Listar(out SalidaMod salida)
        {
            List<PerfilMod> perfiles = new List<PerfilMod>();
            try
            {
                using (IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters parametros = ConexionFll.ObtenerParametros();
                    perfiles = con.Query<PerfilMod>(
                        sql: @"Perfil_L",
                        param: parametros,  
                        commandType: CommandType.StoredProcedure).AsList();
                    salida = ConexionFll.ObtenerSalida(parametros);
                }
                return perfiles;
            }
            catch (Exception e) 
            {
                salida = LogFll.RegistroException(e);
                return perfiles;

            }
        }
    }
}
