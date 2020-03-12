using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;
using System.Text;

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

        public ViewResult CreateProduct()
        {
            Product myProduct = new Product
            {
                ProductID = 100, Name="lkjf",
                Description = "A boat ...",
                Price = 275M, Category = "Watersports"
            };

            return View("Result",
                (object)String.Format("Category: {0}", myProduct.Category));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };

            List<int> intList = new List<int> { 10, 20, 30, 40 };

            Dictionary<string, int> myDict = new Dictionary<string, int>
            {
                { "apple", 10}, {"orange", 20 }, {"plum", 30 }
            };

            return View("Result", (object)stringArray[1]);
        }

        public ViewResult UseExtension()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name="sefsd", Price=275M },
                    new Product {Name="nb567un", Price=48.2M },
                    new Product {Name="8in8", Price=19.20M },
                    new Product {Name="sefsnb8i8nb8bd", Price=34.23M },
                }
            };

            decimal cartTotal = cart.TotalPrices();

            return View("Result",
                (object)String.Format("total: {0:c}", cartTotal));
        }

        public ViewResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name="lakjsdf", Price=78M },
                    new Product {Name="lakjsdf", Price=78M },
                    new Product {Name="lakjsdf", Price=78M },
                    new Product {Name="lakjsdf", Price=78M }
                }
            };

            Product[] productArray =
            {
                    new Product {Name="lakjsdf", Price=78M },
                    new Product {Name="lakjsdf", Price=78M },
                    new Product {Name="lakjsdf", Price=78M },
                    new Product {Name="lakjsdf", Price=78M }
            };

            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = products.TotalPrices();

            return View("Result",
                (object)String.Format("Cart total: {0}, Array total: {1}",
                    cartTotal, arrayTotal));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name="ksjldkf", Category="Watersports", Price=275M },
                    new Product {Name = "Lifejacket", Category = "Watersports",
                       Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer",
                       Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer",
                       Price = 34.95M}
                }
            };

            //Func<Product, bool> categoryFilter = delegate (Product prod)
            //{
            //    return prod.Category == "Soccer";
            //};

            //Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";

            decimal total = 0;
            foreach (Product prod in products
                .Filter(prod => prod.Category == "Soccer" || prod.Price > 20))
            {
                total += prod.Price;
            }

            return View("Result", (object)String.Format("total: {0}", total));
        }

        public ViewResult FindProducts()
        {
            Product[] productArray =
            {
                    new Product {Name="lakjsdf", Price=78M },
                    new Product {Name="lakjsdf", Price=78M },
                    new Product {Name="lakjsdf", Price=78M },
                    new Product {Name="lakjsdf", Price=78M }
            };

            //var foundProducts = from match in productArray
            //                    orderby match.Price descending
            //                    select new { match.Name, match.Price };

            var foundProducts = productArray.OrderByDescending(e => e.Price)
                .Take(3)
                .Select(e => new { e.Name, e.Price });

            productArray[2] = new Product { Name = "Stadium", Price = 79600M };

            //int count = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var p in foundProducts)
            {
                sb.AppendFormat("Price: {0} ", p.Price);
                //if (++count == 3)
                //{
                //    break;
                //}
            }

            return View("Result", sb.ToString());
        }
    }
}