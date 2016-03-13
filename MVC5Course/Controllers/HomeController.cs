﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [紀錄Action的執行時間]
    public class HomeController : Controller
    {
        [共用的ViewBag資料共享於部分HomeController動作方法Attribute]
        public ActionResult Index()
        {
            return View();
        }
        [共用的ViewBag資料共享於部分HomeController動作方法Attribute]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult TEST()
        {
            return View();
        }

        [HandleError(ExceptionType = typeof(ArgumentException), View = "ErrorTest")]
        [HandleError(ExceptionType = typeof(SqlException), View = "ErrorSql")] //顯示SQL的錯誤
        public ActionResult ErrorTest(string e)
        {
            if(e=="1")
             throw new Exception("Error 1");
            if(e=="2")
                throw new ArgumentException("Error 2");
            return Content("No Error");

        }

        public ActionResult RazorTest()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5 };
            return PartialView(data);
        }
    }
}