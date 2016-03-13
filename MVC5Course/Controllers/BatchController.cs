using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class BatchController : BaseController//繼承baseController (裡面的東西這邊也可以用)
    {
        //private FabricsEntities db = new FabricsEntities();

        //ProductRepository repo = RepositoryHelper.GetProductRepository();

        // GET: Products
        public ActionResult Index()
        {
            var data = repo.All().Take(5);
            return View(data);

        }

        [HttpPost]
        public ActionResult Index(IList<Product批次更新> data) //data這個名子要跟view的鳴子依樣data[i].Stock//public ActionResult Index(Product[] data)
        {

            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var product = repo.Find(item.ProductId);
                    product.Stock = item.Stock;
                    product.Price = item.Price;
                }
                repo.UnitOfWork.Commit();//全部改玩一次commit!
                return RedirectToAction("Index");
            }
            else
                return View(repo.All().Take(5));//原本在顯示一次
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var db = (FabricsEntities)repo.UnitOfWork.Context;
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
