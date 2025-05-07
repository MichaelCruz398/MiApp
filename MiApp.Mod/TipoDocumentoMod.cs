using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Mod
{
    public class TipoDocumentoMod
    {
        public int tpd_codigo { get; set; }
        public string tpd_glosa { get; set; }
        public bool tpd_cargo_Abono { get; set; }

        public TipoDocumentoMod(int tpd_Codigo) 
        {
            tpd_codigo = tpd_Codigo;
        }

        public  TipoDocumentoMod(int tpd_Codigo, string tpd_Glosa, bool tpd_Cargo_abono) : this(tpd_Codigo)
        {
            tpd_glosa = tpd_Glosa;
            tpd_cargo_Abono = tpd_Cargo_abono;
        }   
    }
}
