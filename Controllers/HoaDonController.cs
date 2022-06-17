using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HoaDonController : Controller
    {
        Colorshop2Entities db = new Colorshop2Entities();
        
        // GET: HoaDon
        public ActionResult Checkout()
        {
           
            var model = new Invoice();
            model.AccountId = model.AccountId;
            model.Code = "";
            model.ShippingPhone = "";
            model.IssuedDate = DateTime.Now;
            model.ShippingAddress = "";
            model.Total = (int)ShoppingCart.Cart.TongTien;

            return View(model);
        }
        [HttpPost]
        public ActionResult Checkout(Invoice oder)
        {
            ShoppingCart.Cart.ThemVaoHoaDon(oder);
            ShoppingCart.Cart.clearAll();
            return View();
        }
    }
}