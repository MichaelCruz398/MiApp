using Dapper;
using MiApp.Fll;
using MiApp.Mod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Dal
{
    public class ItemDal
    {
        public static List<ItemMod> Listar(int documentoCodigo, out SalidaMod salida) 
        {
            List<ItemMod > items = new List<ItemMod>();
            try
            {
                using (IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters parametros = ConexionFll.ObtenerParametros(new { doc_codigo = documentoCodigo });
                    items = con.Query<ItemMod>(
                        sql: @"item_L",
                        param: parametros,
                        commandType: CommandType.StoredProcedure).AsList();
                    salida = ConexionFll.ObtenerSalida(parametros);
                }
                return items;   
            }
            catch (Exception e)
            {
                salida = LogFll.RegistroException(e);
                return items;
            }
        }

        public static void Inyectar(List<ItemMod> items, int documentoCodigo, out SalidaMod salida) 
        {
            try
            {
                using (IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters documentos = ConexionFll.ObtenerParametros();
                    documentos.Add("@tipo_item", dbType: DbType.Object, value: TipoSqlFll.ObtenerItems(items, documentoCodigo));
                    con.Execute(
                        sql: @"item_I",
                        param: documentos,
                        commandType: CommandType.StoredProcedure
                        );
                    salida = ConexionFll.ObtenerSalida(documentos);
                }
            }
            catch (Exception ex) 
            {
                salida = LogFll.RegistroException(ex);
            }
        }
    }
}
