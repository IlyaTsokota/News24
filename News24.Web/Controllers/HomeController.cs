using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News24.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public Exception About()
        {
            ViewBag.Message = "Your application description page.";

            return new HttpException(403, "Доступ запрещён!");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return HttpNotFound();
        }

        public int fail(int a, int b) => (a / b);

    }
}