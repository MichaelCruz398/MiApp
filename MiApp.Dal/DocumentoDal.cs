using Dapper;
using MiApp.Fll;
using MiApp.Mod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Dal
{
    public class DocumentoDal
    {
        public static List<DocumentoMod> Listar(out SalidaMod salida)
        {
            List<DocumentoMod> documentos = new List<DocumentoMod>();
            try
            {       
                using(IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters parametros = ConexionFll.ObtenerParametros();
                    documentos = con.Query<DocumentoMod, PersonaMod, TipoDocumentoMod, DocumentoMod>(
                        sql: @"documento_L",
                        param: parametros,
                        map: (DocumentoMod, PersonaMod, TipoDocumentoMod) => { DocumentoMod.Persona = PersonaMod; DocumentoMod.TipoDocumento = TipoDocumentoMod; return DocumentoMod; },
                        splitOn: "per_rut , tpd_codigo",
                        commandType: CommandType.StoredProcedure).AsList();
                    salida = ConexionFll.ObtenerSalida(parametros);
                }
                return documentos;
            }
                catch (Exception e)
            {
                    salida  = LogFll.RegistroException(e);
                   return documentos;
            }
        }

        public static void Insertar(DocumentoMod documento, out SalidaMod salida)
        {
            try
            {
                using (IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters parametros = ConexionFll.ObtenerParametros(new
                    {


                        doc_codigo = documento.Codigo,
                        doc_glosa = documento.Glosa,
                        doc_fecha = documento.Fecha,
                        doc_fecha_minima = documento.FechaMinima,
                        doc_fecha_maxima = documento.FechaMaxima,
                        doc_referencia = documento.Referencia,
                        doc_descuento = documento.Descuento,
                        doc_clasificacion = documento.Clasificacion,
                        doc_marcado = documento.Marcado,
                        doc_total = documento.Total,
                        per_rut = documento.Persona.Rut,
                        tpd_codigo = documento.TipoDocumento.tpd_codigo
                    });
                    parametros.Add("@tipo_item", dbType: DbType.Object, value: TipoSqlFll.ObtenerItems(documento));
                    parametros.Add("@tipo_etapa_documento", dbType: DbType.Object, value: TipoSqlFll.ObtenerEtapas(documento));
                    con.Execute(
                        sql: "documento_I",
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

        public static void Eliminar(int codigo, out SalidaMod salida)
        {
            try
            {
                using (IDbConnection con = ConexionFll.ConectarPrueba())
                {
                    DynamicParameters parametros = ConexionFll.ObtenerParametros(new { Codigo = codigo });
                    con.Execute(
                        sql: @"documento_D",
                        param: parametros,
                        commandType: CommandType.StoredProcedure
                        );
                    salida = ConexionFll.ObtenerSalida(parametros);

                }
            }
            catch(Exception e)
            {
                salida = LogFll.RegistroException(e);
            }
        }
    }
}
