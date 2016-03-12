using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return PartialView("Index"); //只回傳HTML部分不仔入主版頁面
        }

        public ActionResult ContextTest()
        {
            return Content(" < script > alert('Redriecting ...');</ script > ",
                            "application/javascript", Encoding.UTF8); 
        }

        public ActionResult ActionTest()
        {
            return File(Server.MapPath("~/Content/alphago-logo.png"), "image/png","myReName.png");//路徑,檔案格式上網查contextType,重新儲存的名字
        }

        public ActionResult JsonTest()
        {
            var db = new FabricsEntities();
            db.Configuration.LazyLoadingEnabled = false; //關閉延遲載入
            var data = db.Product.Take(3);
           
            return Json(data,JsonRequestBehavior.AllowGet);

        }


        public ActionResult RedirecTest()
        {
            //轉址到>>  Product/Edit/1  
            return RedirectToAction("Edit", "Products", new { id = 1 });
        }
    }
}