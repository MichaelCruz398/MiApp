using Dapper;
using MiApp.Mod;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Fll
{
    public class ConexionFll
    {
        public static SqlConnection ConectarPrueba()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["prueba"].ConnectionString);
        }  
        
        public static DynamicParameters ObtenerParametros(object parametrosEntrada = null)
        {
            DynamicParameters parameters = new DynamicParameters(parametrosEntrada);
            parameters.Add("@codigo_salida", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@mensaje_salida", dbType: DbType.String, direction: ParameterDirection.Output, size: 800);
            return parameters;
        }

        public static SalidaMod ObtenerSalida(DynamicParameters parametros)
        {
            SalidaMod salida = new SalidaMod(parametros.Get<int>("codigo_salida"), parametros.Get<string>("mensaje_salida"));
            if(salida.Codigo <= -1) 
            {
                return LogFll.RegistrarExceptionBaseDatos(salida);
            }
            else
            {
                return salida;
            }
        }
    }
}
