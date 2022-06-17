using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ShoppingCart
    {
        // lấy giỏ hàng từ session, nếu chưa có sẽ tạo mới
        public static ShoppingCart Cart
        {
            get
            {
                var cart = HttpContext.Current.Session["Cart"] as ShoppingCart;
                if (cart==null)
                {
                    cart = new ShoppingCart();
                    HttpContext.Current.Session["Cart"] = cart;
                }
                return cart;
            }
        }
        //các mặt hàng trong giỏ
        public List<Product> Items = new List<Product>();
        //bỏ hàng vào giỏ hàng

        public void Add(int id)
        {
            try // tìm thấy giỏ hàng
            {
                var item = Items.Single(i => i.Id == id);
                    item.Quantity++;
            }
            catch // không tìm thấy giỏ hàng thì truy vấn csdl bỏ vòa giỏ hàng
            {
                var db = new Colorshop2Entities();
                var p = db.Products.Find(id);
                p.Quantity = 1;
                Items.Add(p);
                
            }
        }
        public void Remove(int id) // xóa từng sản phẩm
        {
            var item = Items.Single(i => i.Id == id);
            Items.Remove(item);
        }

        public void clearAll ()// xóa hết sản phẩm
        {
            Items.Clear();

        }
        public double TongTien
        {
            get
            {
                return Items.Sum(p => (double)p.Price * (double)p.Quantity);
            }
        }
        public int Count
        {
            get
            {
               return Items.Count;
            }
        }
        public void ThemVaoHoaDon(Invoice hoadon)
        {
            var db = new Colorshop2Entities();
                db.Invoices.Add(hoadon);
            foreach (var item in Items)
            {
                var detail = new InvoiceDetail
                {
                    Invoice = hoadon,
                    ProductId = item.Id,
                    UnitPrice = (int)item.Price,
                    Quantity = (int)item.Quantity

                };
                db.InvoiceDetails.Add(detail);
            }
            db.SaveChanges();
        }
    }
}