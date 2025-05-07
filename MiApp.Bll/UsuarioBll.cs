using MiApp.Dal;
using MiApp.Fll;
using MiApp.Mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Bll
{
    public class UsuarioBll
    {
        public static List<UsuarioMod> Listar(out SalidaMod salida)
        {
            try
            {
                return UsuarioDal.Listar(out salida);
            }
            catch (Exception e)
            {
                salida = LogFll.RegistroException(e);
                return new List<UsuarioMod>();
            }
            
        }

        public static void InsertarActualizar(int codigo, string nombre, int perfilCodigo, out SalidaMod salida )
        {
            try
            {
                UsuarioMod usuario = new UsuarioMod(codigo, nombre, new PerfilMod(perfilCodigo));
                UsuarioDal.InsertarActualizar(usuario, out salida);
            }
            catch(Exception e)
            {
                salida = LogFll.RegistroException(e);
            }
        }
        public static void Eliminar(int Codigo, out SalidaMod salida)
        {
            try
            {
                UsuarioDal.Eliminar(Codigo, out salida);  
            }
            catch(Exception e)
            {
                salida = LogFll.RegistroException(e);
            }
        }
    }
}
