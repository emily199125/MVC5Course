using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class INDEXController : Controller
    {
        // GET: INDEX
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MemberProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberMemberProfile()
        {
            return View();
        }
    }
}