using MyDubai.Core.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyDubai.Web.Controllers
{
    public class AccountController : Controller
    {
        private MyDubaiDataContext db = new MyDubaiDataContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(String username, String password)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            
            if (user == null)
            {
                return Json("Failed");
            }

            FormsAuthentication.SetAuthCookie(JsonConvert.SerializeObject(user), true);
            return Json("Success");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect(Url.Action("login"));
        }
    }
}