using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class UserDAO
    {
        Colorshop2Entities db = new Colorshop2Entities();
        public bool CheckUserName(string username)
        {
            return db.Accounts.Count(x => x.Username == username) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Accounts.Count(x => x.Email == email) > 0;
        }
        public Account GetById(string userName)
        {
            return db.Accounts.SingleOrDefault(x => x.Username == userName);
        }
        public int insert(Account TKEF)
        {
            db.Accounts.Add(TKEF);
            db.SaveChanges();
            return TKEF.Id;
        }
        public int Login(string username, string password)
        {
            var res = db.Accounts.SingleOrDefault(x => x.Username == username && x.Password == password);
            if (res == null)
            {
                return 0;
            }
            else
            {
                if (res.Password == password)
                {
                    return 1;

                }
                else
                    return -2;
            }
        }
    }
}