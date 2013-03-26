using ClosedXML.Excel;
using stock.web.Infrastructure;
using System.Collections.Generic;
using System.Web.Mvc;

namespace stock.web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}