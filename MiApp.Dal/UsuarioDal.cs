using Dapper;
using MiApp.Fll;
using MiApp.Mod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Dal
{
    public class UsuarioDal
    {
        public static List<UsuarioMod> Listar(out SalidaMod salida) 
        {
            List<UsuarioMod> usuarios = new List<UsuarioMod>();
            try
            {
                DynamicParameters parametros = ConexionFll.ObtenerParametros();
                using(IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    usuarios = con.Query<UsuarioMod, PerfilMod, UsuarioMod>(
                        sql: @"Usuario_S",
                        param: parametros,
                        map: (UsuarioMod, PerfilMod) => { UsuarioMod.Perfil = PerfilMod; return UsuarioMod; },
                        splitOn: "PerfilCodigo",
                        commandType: CommandType.StoredProcedure).AsList();
                    salida = ConexionFll.ObtenerSalida(parametros);
                }
                return usuarios;
            }
            catch (Exception e)
            {
                salida = LogFll.RegistroException(e);
                return usuarios;
            }
        }
        public static void InsertarActualizar(UsuarioMod usuario, out SalidaMod salida)
        {   
            try
            {
                using(IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters parameters = ConexionFll.ObtenerParametros(new { codigo = usuario.Codigo, nombre = usuario.Nombre, perfilCodigo = usuario.Perfil.Codigo  });
                    con.Execute(
                        sql: @"Usuario_IU",
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                        );
                    salida = ConexionFll.ObtenerSalida(parameters);
                }
            }
            catch ( Exception e)
            {
                salida = LogFll.RegistroException(e);
            }   
        }

        public static void Eliminar(int codigo, out SalidaMod salida)
        {
            try
            { 
                using (IDbConnection db = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters parametros = ConexionFll.ObtenerParametros(new { Codigo = codigo });
                    db.Execute(
                        sql: @"Usuario_D",
                        param: parametros,
                        commandType: CommandType.StoredProcedure
                    );
                    salida = ConexionFll.ObtenerSalida(parametros);
                }
            }
            catch (Exception e)
            {
                salida = LogFll.RegistroException(e);
            }
        }
    }
}
