using System.Web;
using System.Web.Mvc;
using CirneSports.LojaVirtual.Web.V2.HtmlHelpers;

namespace CirneSports.LojaVirtual.Web.V2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new InjectPageMetadataAttribute());
        }
    }
}
