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


        public JsonNetResult GetStocksData(string sheet, string xcolumn, string ycolumn)
        {
            string path = Server.MapPath("~/stockdata.xlsx");
            var wb = new XLWorkbook(path, XLEventTracking.Disabled);
            var ws = wb.Worksheet(sheet);

            var firstRow = ws.FirstRowUsed();
            var row = firstRow.RowBelow();

            var result = new List<dynamic>();

            while (!row.Cell(xcolumn).IsEmpty() || !row.Cell(ycolumn).IsEmpty())
            {
                var x = row.Cell(xcolumn).Value;
                var y = row.Cell(ycolumn).Value;

                result.Add(new { x = x, y = y });
                row = row.RowBelow();
            }

            return new JsonNetResult(result);
        }
    }
}