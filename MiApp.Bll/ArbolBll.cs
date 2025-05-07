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
    public class ArbolBll
    {
        public static List<ArbolMod> Listar(out SalidaMod salida)
        {
            try
            {
                return ArbolDal.Listar(out salida);
            }
            catch (Exception ex)
            {
                salida = LogFll.RegistroException(ex);
                return new List<ArbolMod>();
            }
        }
    }
}
