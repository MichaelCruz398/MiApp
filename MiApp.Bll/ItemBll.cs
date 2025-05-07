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
    public class ItemBll
    {
        public static List<ItemMod> Listar(int documentoCodigo, out SalidaMod salida)
        {
            try
            {
                return ItemDal.Listar(documentoCodigo, out salida);
            }
            catch (Exception ex)
            {
                salida = LogFll.RegistroException(ex);
                return new List<ItemMod>();
            }
        }

        public static void Inyectar(List<ItemMod> items, int documentoCodigo, out SalidaMod salida) 
        {
            try
            {
                ItemDal.Inyectar(items, documentoCodigo, out salida);
            }
            catch (Exception e)
            {
                salida = LogFll.RegistroException(e);
            }
        }
    }
}
