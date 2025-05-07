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
    public class PerfilBll
    {
        public static List<PerfilMod> Listar(out SalidaMod salida)
        {
            try
            {
                return PerfilDal.Listar(out salida);
            }
            catch (Exception e)   
            {
                salida = LogFll.RegistroException(e);
               return new List<PerfilMod>(); 
            }
        }
    }
}
