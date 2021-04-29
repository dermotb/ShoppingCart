using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{
    public class ShopController : Controller
    {
        private readonly ItemContext _context;

        public ShopController(ItemContext context)
        {
            _context = context;
            try
            {
                _context.Database.EnsureCreated();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

/*
        private static List<Item> items
            = new List<Item>()
            {
                new Item(){Code="1234", Description="Dyson Hoover", Price=425},
                new Item(){Code="9999", Description="Case of Beer", Price=14.25},
                new Item(){Code="4425", Description="Nilfisk Hoover", Price=125.23},
                new Item(){Code="6658", Description="Cuddly Toy", Price=30}
            };
*/
        private static Cart cart = new Cart();

        // GET: ShopController
        public ActionResult Index()
        {
            ViewBag.TotalPrice = cart.CalculateTotal();
            return View(_context.Items);
        }

        // GET: ShopController/Details/5
        public ActionResult Add(string code)
        {
            Item itm = _context.Items.FirstOrDefault(p => p.Code == code);
            if (itm!=null)
            {
                cart.AddItem(itm);
            }
            return RedirectToAction("Index");
        }

    }
}
