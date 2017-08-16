using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.BussinessObject.Objects;
using WCF.BussinessController.BCL;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WEB_QLGD01.Models
{
    public class Login
    {
        const string LOGIN = "PermissionOfAccountObject";
        const string nameCookiesLogin = "tiep-hoang";

        public AccountObject GetAccount()
        {
            var r = GetPermission();
            if (r == null) return null;
            return r.Account;
        }

        public Models.Permission GetPermission()
        {
            return HttpContext.Current.Session[LOGIN] as Models.Permission;
        }

        public bool CheckLogin(UserLogin ob)
        {
            Logout();
            var acc = new AccountBCL().CheckLogin(new AccountObject() { Username = ob.Username, PassWord = ob.Password });
            if (acc != null)
            {
                if (ob.Remember) SetCookie(new UserLogin()
                {
                    Username = ob.Username,
                    Password = MaHoa(MaHoa(ob.Password))
                });
                HttpContext.Current.Session[LOGIN] = new Models.Permission(acc);
                return true;
            }
            return false;
        }

        public string MaHoa(string input)
        {
            string res = "";
            for (int i = 0; i < input.Length; i++)
            {
                res += ((int)input[i] + 69) + " ";
            }
            return res;
        }

        public string GiaiMa(string input)
        {
            string res = "";
            foreach (var item in input.Split(' '))
            {
                try
                {
                    res += (char)(int.Parse(item) - 69);
                }
                catch { }
            }
            return res;
        }

        public void Logout()
        {
            HttpContext.Current.Session.Clear();
        }

        public UserLogin GetUserObjectInCookie()
        {
            var ck = HttpContext.Current.Request.Cookies[nameCookiesLogin];
            if (ck == null) return null;
            string valueCookie = HttpContext.Current.Server.UrlDecode(ck.Value);
            var u = JsonConvert.DeserializeObject<UserLogin>(valueCookie);
            UserLogin user = new UserLogin()
            {
                Username = u.Username,
                Password = GiaiMa(GiaiMa(u.Password))
            };
            return user;
        }

        public void SetCookie(object obj)
        {
            var jsonUser = JsonConvert.SerializeObject(obj);
            string cookieValue = HttpContext.Current.Server.UrlEncode(jsonUser);
            HttpCookie cookie = new HttpCookie(nameCookiesLogin, cookieValue)
            {
                Expires = DateTime.Now.AddDays(10)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}