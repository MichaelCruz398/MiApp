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
    public class FormularioBll
    {
        public static List<FormularioMod> Listar(string url, out SalidaMod salida)
        {
            try
            {
                return FormularioDal.Listar(url, out salida);
            }
            catch (Exception ex)
            {
                salida = LogFll.RegistroException(ex);
                return new List<FormularioMod>();
            }
        }
    }
}
