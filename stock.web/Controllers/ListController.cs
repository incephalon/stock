using stock.web.Infrastructure;
using System.Collections.Generic;
using System.Web.Mvc;

namespace stock.web.Controllers
{
    public class ListController : Controller
    {
        //
        // GET: /List/

        public ActionResult Index()
        {

            var Names = new List<string>
                            {
                                "Aiden",
                                "Jackson",
                                "Ethan",
                                "Liam",
                                "Mason",
                                "Noah",
                                "Lucas",
                                "Jacob",
                                "Jayden",
                                "Jack",
                                "Logan",
                                "Ryan",
                                "Caleb",
                                "Benjamin"
                            };
        
            return View(Names);
        }

        [HttpPost]
        public JsonNetResult Greetings(string name)
        {
            return new JsonNetResult(string.Format("Hello {0}!", name));
        }

    }
}
