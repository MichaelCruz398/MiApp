using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Mod
{
    public class ArbolMod
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public string Padre { get; set; }

        public ArbolMod(string codigo, string nombre, string url, string padre)
        {
            Codigo = codigo;
            Nombre = nombre;
            Url = url;
            Padre = padre;
        }
    }
}
