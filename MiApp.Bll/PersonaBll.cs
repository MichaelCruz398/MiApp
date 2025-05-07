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
    public class PersonaBll
    {
       public static List<PersonaMod> Listar(int tipoDocumento, out SalidaMod salida)
        {
            try
            {
                return PersonaDal.Listar(tipoDocumento, out salida);
            }
            catch (Exception e)
            {
                salida = LogFll.RegistroException(e);
                return new List<PersonaMod>();
            }
        }

    }
}
