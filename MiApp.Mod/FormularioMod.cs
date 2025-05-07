using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Mod
{
    public class FormularioMod
    {

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }

        public FormularioMod(int frm_codigo, string frm_nombre, string frm_url)
        {
           Codigo = frm_codigo;
            Nombre = frm_nombre;
            Url = frm_url;
        }  
    }
}
