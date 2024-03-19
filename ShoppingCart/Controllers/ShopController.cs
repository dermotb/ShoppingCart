using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ShoppingCart.Models;
using System.Diagnostics;
using System.Globalization;

namespace ShoppingCart.Controllers
{
    public class ShopController : Controller
    {
        private static List<Item> products
            = new List<Item>()
            {
                new Item(){Code="ABC123", Description="Cuddly Toy", Price=5.95},
                new Item(){Code="AB23XY", Description="Alarm Clock", Price=15.23},
                new Item(){Code="XYZ556", Description="Laptop", Price=1052.10},
                new Item(){Code="53KZC", Description="Keyboard", Price=25.75 }

            };

        private static Cart myCart = new Cart();
        
        // GET: ShopController
        public ActionResult Index()
        {
            ViewBag.TotalPrice = myCart.CalculateTotalPrice();
            return View(products);
        }


        public ActionResult Add (string code)
        {
            try
            {
                Item found = products.FirstOrDefault(p => p.Code.ToUpper(CultureInfo.CurrentCulture) == code.ToUpper(CultureInfo.CurrentCulture));
                if (found != null)
                {
                    myCart.AddItem(found);
                }
            }
            catch
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            return RedirectToAction("Index");
        }


    }
}
