using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC5Course.Models;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        // GET: EF
        FabricsEntities db = new FabricsEntities();
        public ActionResult Index(bool? IsActive, string keyword)
        {
            //var db = new FabricsEntities();
            var product=new Product()
            {
                ProductName = "BMWW",
                Price =3,
                Stock = 1,
                Active = true
            };
            db.Product.Add(product);

              
            var pkey= product.ProductId;
            //var data = db.Product.ToList();

            var data = db.Product.OrderByDescending(p => p.ProductId).AsQueryable();
            if (IsActive.HasValue)
            {
                data = data.Where(p => p.Active.HasValue ? p.Active.Value == IsActive.Value : false);
            }
            if (!String.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.ProductName.Contains(keyword));
            }
            return View(data);
        }

        public ActionResult Detail(int id)
        {
            var data = db.Product.FirstOrDefault(p => p.ProductId == id);

            return View(data);
        }

        public ActionResult Delete(int id)
        {

            var product = db.Product.Find(id);
            //db.Product.Remove(product);
            db.OrderLine.RemoveRange(product.OrderLine);
            db.Product.Remove(product);

            //foreach (var ol in product.OrderLine.ToList())
             //{
                // db.OrderLine.Remove(ol);
              //}
              db.SaveChanges();

            //return View();
            return RedirectToAction("Index");
        }

        public ActionResult QueryPlan(int num=10)
        {          
            var data = db.Product.Include(t => t.OrderLine).OrderBy(p => p.ProductId).AsQueryable();
            //var data = db.Database.SqlQuery<Product>(@"
            //                             SELECT * 
            //                             FROM dbo.Product p 
            //                             WHERE p.ProductId < @p0", num);
            return View(data);
        }

    }
}