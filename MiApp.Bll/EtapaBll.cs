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
    public class EtapaBll
    {
        public static List<EtapaMod> Listar(out SalidaMod salida) 
        { 
           try
            {
                return EtapaDal.Listar(out salida);
            }
            catch(Exception e)  
            { 
                salida= LogFll.RegistroException(e);
                return new List<EtapaMod>();
            }
        }

        public static List<EtapaMod> Listar(int documentoCodigo, out SalidaMod salida)
        {
            try
            {
                return EtapaDal.Listar(documentoCodigo, out salida);
            }
            catch(Exception e)
            {
                salida = LogFll.RegistroException(e); 
                return new List<EtapaMod>();
            }
        }
    }
}
