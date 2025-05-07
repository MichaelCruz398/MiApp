using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Mod
{
    public class SalidaMod
    {
        public int Codigo { get; }

        public string Mensaje { get; }

        public SalidaMod(int codigo, string mensaje)
        {
            Codigo = codigo;
            Mensaje = mensaje;
        }
    }
}
