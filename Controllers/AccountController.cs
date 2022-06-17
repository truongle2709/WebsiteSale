using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;
using WebApplication1.Models;
using WebApplication1.Common;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        Colorshop2Entities db = new Colorshop2Entities();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "email đã tồn tại");
                }
                else
                {
                    var user = new Account();
                    user.Username = model.UserName;
                    user.Password =MaHoa.MD5Hash(model.Password);
                    user.Email = model.Email;
                    user.Phone = model.Phone;
                    user.Address = model.Address;
                    user.Fullname = model.Fullname;
                    user.isAdmin = model.isAdmin;
                    dao.insert(user);
                    var check = dao.insert(user);
                    if (check>0)
                    {
                        ViewBag.Succsess="đăng kí tài khoản thành công";
                        return RedirectToAction("Index","SanPham");

                    }
                    else
                    {
                        ModelState.AddModelError("", "đăng kí không thành công");
                    }

                }
            }
           


            return View(model);
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var check = dao.Login(model.UserName, MaHoa.MD5Hash(model.Password));
                if (check == 1)
                {
                    var tk = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.ID = tk.Id;
                    userSession.UserName = tk.Username;
                    Session.Add(UserSession.User_Session, userSession);
                    return RedirectToAction("Index", "SanPham");
                }
                else if (check == 0)
                {
                    ModelState.AddModelError("", "tài khoản không tồn tại rồi, phải đăng kí đi thôi!!");
                }
                else if (check == -2)
                {
                    ModelState.AddModelError("", "mật khẩu không đúng rồi,thử lại nào!!");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng");

                }

            }

            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index","SanPham");
        }



    }
}