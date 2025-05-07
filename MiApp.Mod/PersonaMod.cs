using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Mod
{
    public class PersonaMod
    {
        public int Rut { get; set; }
        public char Dv { get; set; }
        public string Nombre { get; set; }
        public bool ClienteProveedor { get; set; }

        public PersonaMod(int per_rut)
        {
            Rut = per_rut;
        }

        public PersonaMod(int per_rut, char per_dv, string per_nombre, bool per_cliente_proveedor) : this(per_rut)
        {
            Dv= per_dv;
            Nombre= per_nombre;
            ClienteProveedor= per_cliente_proveedor;
        }
    }
}
