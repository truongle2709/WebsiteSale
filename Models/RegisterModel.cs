using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RegisterModel
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="bạn chưa nhập username")]
       
        public string UserName { get; set; }
        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "bạn chưa nhập password")]
        [StringLength(maximumLength:16, MinimumLength =6,ErrorMessage ="độ dài mật khẩu ít nhất 6 kí tư ." )]
        [ RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,16}$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Xác nhận mật khẩu không đúng")]
        [Required(ErrorMessage = "bạn chưa nhập xác nhận mật khẩu")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,16}$")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "bạn chưa nhập email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string Address { get; set; }

        public string Fullname { get; set; }

        public bool isAdmin { get; set; }

        //public string Avartar { get; set; }

        //public bool status { get; set; }





    }
}