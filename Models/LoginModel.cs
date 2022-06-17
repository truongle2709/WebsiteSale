using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoginModel
    {
        [Key]
       
        [Required(ErrorMessage ="yêu cầu nhập tài khoản")]
        public string UserName { get; set; }
      
        [Required(ErrorMessage = "yêu cầu nhập mật khẩu")]
        public string Password { get; set; }
    }
}