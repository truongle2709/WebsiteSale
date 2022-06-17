using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Admin.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage =" mời nhập username")]
        public string username { get; set; }
        [Required(ErrorMessage = " mời nhập password")]
        public string password { get; set; }
        public bool remember { get; set; }
    }
}