using DevExpress.XtraPrinting.Caching;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using MiApp.Web.Reporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiApp.Web.Pagina.Varios
{
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (Session["reporte"] != null)
            {
               
                    var cachedReportSource = new CachedReportSourceWeb((XtraReport)Session["reporte"]);
                    AwdReporte.OpenReport(cachedReportSource);
            }
            
            
        }
    }
}