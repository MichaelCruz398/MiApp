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
    public class ModuloBll
    {
        public static List<ModuloMod> Listar(out SalidaMod salida)
        {
            try
            {
                return ModuloDal.Listar(out salida);
            }
            catch (Exception ex)  
            {
               salida = LogFll.RegistroException(ex);
                return new List<ModuloMod>();
            }
        }
    }
}
 