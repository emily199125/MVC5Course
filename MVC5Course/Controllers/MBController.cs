using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
    {
        // GET: MB
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(MemberViewModel data)
        {
            return View();//沒改道
        }


        //[HttpPost] //佳
        //public ActionResult Index(string Name,string Birthday)
        //{
        //    return Content(Name +" " + Birthday);
        //}

        /*[HttpPost]//佳
        public ActionResult Index(FormCollection form)
        {
            return Content(form["Name"] + " " + form["Birthday"]);
        }*/

        //[HttpPost]//不建議
        //public ActionResult Index(int a )
        //{
        //    return  Content(Request.Form["Name"] + " " + Request.Form["Birthday"]);
        //}


    }
}