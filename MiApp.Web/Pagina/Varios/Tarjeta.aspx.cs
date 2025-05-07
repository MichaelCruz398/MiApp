using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiApp.Web.Pagina.Varios
{
    public partial class Tarjeta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AcwTarjeta_SelectionChanged(object sender, EventArgs e)
        {
            ASPxWebControl.RedirectOnCallback(AcwTarjeta.GetSelectedFieldValues("UrlPrincipal")[0].ToString());
        }
    }
}