using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        Colorshop2Entities db = new Colorshop2Entities();
       public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(int id)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ShoppingCart.Cart.Add(id);
                return RedirectToAction("Index", "SanPham");
            }
            
        }
        public ActionResult Delete(int id)
        {
            ShoppingCart.Cart.Remove(id);
            return RedirectToAction("Index");

        }
        public ActionResult Update()
        {
            foreach (var item in ShoppingCart.Cart.Items)
            {
                item.Quantity = int.Parse(Request[item.Id.ToString()]);
            }
            return RedirectToAction("Index");

        }
        public ActionResult Clear()
        {
            ShoppingCart.Cart.clearAll();
            return RedirectToAction("Index");
        }


    }
}