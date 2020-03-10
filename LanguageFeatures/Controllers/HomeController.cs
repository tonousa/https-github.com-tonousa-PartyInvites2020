using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to a URL";
        }

        public ViewResult AutoProperty()
        {
            Product myProduct = new Product();

            myProduct.Name = "Kayak";

            string productName = myProduct.Name;

            return View("Result",
                (object)String.Format("Product name: {0}", productName));
        }
    }
}