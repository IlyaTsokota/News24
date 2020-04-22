﻿using System.Web.Mvc;

namespace News24.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ViewResult Index()
        {
            // default view for my fail
            return View();
        }

        public ViewResult AccessDenied()
        {
            // view for code 403
            return View("AccessDenied");
        }

        public ViewResult NotFound()
        {
            //view for code 404
            return View("NotFound");
        }

        public ViewResult HttpError()
        {
            // all other errors
            return View("HttpError");
        }
    }
}