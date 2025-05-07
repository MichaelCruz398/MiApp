using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Mod
{
    public class ModuloMod
    {
        public int Codigo { get; set; }
        public string Nombre { get; set;}
        public string Descripcion { get; set; }
        public string Icono { get; set; }
        public string UrlPrincipal { get; set; }
        public List<FormularioMod> Formularios { get; set; }

        public ModuloMod(int mdo_codigo, string mdo_nombre, string mdo_descripcion, string mdo_icono, string mdo_url_principal) 
        {
            Codigo = mdo_codigo;
            Nombre = mdo_nombre;
            Descripcion = mdo_descripcion;
            Icono = mdo_icono;
            UrlPrincipal = mdo_url_principal;
        }

        public ModuloMod(int codigo, string nombre, string descripcion, string icono, string urlPrincipal,
            List<FormularioMod> formularios) : this(codigo, nombre, descripcion, icono, urlPrincipal) 
        {
            Formularios = formularios;
        }
    }   
}
