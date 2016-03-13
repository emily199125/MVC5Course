using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class 紀錄Action的執行時間Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //override 在執行ActionFilterAttribute之前先執行我的程式碼,在執行ActionFilterAttribute
            TimeSpan exectuionTime = TimeSpan.FromHours(1);
            filterContext.Controller.ViewBag.執行時間 = exectuionTime;
            base.OnActionExecuted(filterContext);//執行原本的
        }
    }

}