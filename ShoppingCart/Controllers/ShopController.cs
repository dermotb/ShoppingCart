using Humanizer;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ItemsContext _context;

        public ShopController(ItemsContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        private static Cart myCart = new Cart();
        
        // GET: ShopController
        public ActionResult Index()
        {
            ViewBag.TotalPrice = myCart.CalculateTotalPrice();
            return View(_context.products);
        }


        public ActionResult Add (string code)
        {
            try
            {
                Item found = _context.products.FirstOrDefault(p => p.Code.ToUpper() == code.ToUpper());
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

        [Authorize(Roles = "Administrator, PowerUser")]
        public ActionResult AddProducts()
        {
            return RedirectToAction("Index", "ItemsDB");
        }

    }
}
