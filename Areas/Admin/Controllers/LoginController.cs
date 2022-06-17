using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Admin.Model;
using WebApplication1.Common;
using WebApplication1.DAO;
using WebApplication1.Models;


namespace WebApplication1.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(Model.LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var check = dao.Login(user.username, MaHoa.MD5Hash(user.password));
                if (check == 1)
                {
                    var tk = dao.GetById(user.username);
                    var userSession = new UserLogin();
                    userSession.ID = tk.Id;
                    userSession.UserName = tk.Username;
                    Session.Add(UserSession.User_Session, userSession);
                    return RedirectToAction("Index", "Home");
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
    }
}