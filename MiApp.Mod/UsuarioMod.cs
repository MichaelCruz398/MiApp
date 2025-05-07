using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Mod
{
    public class UsuarioMod
    {
       public int Codigo { get; set; }  
       public string Nombre { get; set;}

       public PerfilMod Perfil { get; set; }

       public UsuarioMod(int codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
        }

        public UsuarioMod(int codigo, string nombre, PerfilMod perfil) : this(codigo, nombre)
        {
            Perfil = perfil;
        }
    }
}
