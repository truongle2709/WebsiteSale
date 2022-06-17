using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using PagedList;

namespace WebApplication1.Controllers
{
    public class SanPhamController : Controller
    {
        Colorshop2Entities db = new Colorshop2Entities();
        // GET: SanPham
        public ActionResult Index()
        {
            var list = db.Products.ToList();
            return View(list);
        }
        public  ActionResult DanhSachSanPham( int? page,string sortOrder, int categoryID = 0 ,int min = int.MinValue, int max = int.MaxValue)
        {
            if (categoryID != 0)
            {
                var category = db.Categories.Find(categoryID);
                var model1 = category.Products.ToList();
                return View(model1);
            }

                 ViewBag.Min = min;
                    ViewBag.Max = max;
                ViewBag.CurentSorr = sortOrder;
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
               
                ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";
                var model2 = (from s in db.Products select s).OrderBy(s => s.Productname);
                    model2 = (IOrderedQueryable<Product>)model2.Where(x => x.Price >= min && x.Price <= max);
                switch (sortOrder)
                {
                    case "name_desc":
                        model2 = model2.OrderByDescending(s => s.Productname);
                        break;
                    case "Price":
                        model2 = model2.OrderBy(s => s.Price);
                        break;
                    case "Price_desc":
                        model2 = model2.OrderByDescending(s => s.Price);
                        break;
                    default:
                        model2 = model2.OrderBy(s => s.Productname);
                        break;
                }

                if (page == null) page = 1;
                int pageSize = 16;
                int pageNumber = (page ?? 1);

                return View(model2.ToPagedList(pageNumber, pageSize));   
        }

        public ActionResult ProductCategory(int categoryID = 0)
        {
            if (categoryID != 0)
            {
                var category = db.Categories.Find(categoryID);
                var model1 = category.Products.ToList();
                return View(model1);
            }

            var model = db.Products.ToList();
            return View(model);
        }

        public int pageSize = 16;
        public ActionResult DanhSachSanPham1(string txtSearch, string sortOrder, int? page, int min = int.MinValue, int max = int.MaxValue)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";
            var model2 = (from s in db.Products select s);
            ViewBag.CurentSorr = sortOrder;
            ViewBag.txtMin = min;
            ViewBag.txtMax = max;

            model2 = (IOrderedQueryable<Product>)model2.Where(x => x.Price >= min && x.Price <= max);

            switch (sortOrder)
            {
                case "name_desc":
                    model2 = model2.OrderByDescending(s => s.Productname);
                    break;
                case "Price":
                    model2 = model2.OrderBy(s => s.Price);
                    break;
                case "Price_desc":
                    model2 = model2.OrderByDescending(s => s.Price);
                    break;
               
            }

            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            int start = (int)(page - 1) * pageSize;

            ViewBag.pageCurrent = page;
            int totalPage = model2.Count();
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);
            ViewBag.numSize = numSize;
            ViewBag.posts = model2.OrderBy(x => x.Productname).Skip(start).Take(pageSize);
            return View();
        }







        public ActionResult CategoryMenu()
        {
            var model = db.Categories;
            return PartialView("_Category",model);
        }
        public ActionResult ChiTietSanPham(int id)
        {
            var model = db.Products.Where(n =>n.Id==id).FirstOrDefault();
            return View(model);
        }
        public ActionResult PromotionProduct()
        {
            return View();
        }
    }
}