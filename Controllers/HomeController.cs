using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        Colorshop2Entities db = new Colorshop2Entities();
        public ActionResult Index()
        {
            var list = db.Products.ToList();
            return View(list);
        }

        
    }
}