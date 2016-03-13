using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    [Authorize]//要求登入
    public class MemberController : Controller
    {
        [AllowAnonymous]//  Member  除了LOGIN這個我都要驗證
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login)
        {
            if (CheckLogin(login.Email, login.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(login.Email, false);//false 網頁關掉是否還有儲存資訊在瀏覽器
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("Password", "您輸入的帳號或密碼錯誤");
                return View();
            }


        }

        public bool CheckLogin(string username, string password)
        {
            return (username == "emm199125@gmail.com" && password == "123");//此處可進行資料庫比對查詢

        }

        public ActionResult Logout()
         {
             FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
         }
}
}