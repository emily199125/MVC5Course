using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public abstract class BaseController : Controller//abstract 抽象化
    {
        //[Authorize]  //權限控制
        protected override void HandleUnknownAction(string actionName)
        {

            this.Redirect("/").ExecuteResult(this.ControllerContext);//回到首頁
            //base.HandleUnknownAction(actionName); 
        }


        protected ProductRepository repo = RepositoryHelper.GetProductRepository();
        public ActionResult Debug()
         {
             return Content("DEBUG");
         }

}
}