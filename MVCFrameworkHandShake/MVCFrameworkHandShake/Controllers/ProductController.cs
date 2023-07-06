using MVCFrameworkHandShake.Context;
using MVCFrameworkHandShake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace MVCFrameworkHandShake.Controllers
{
    //Allow unauthrized access
    [AllowAnonymous]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var Prds = from p in context.Products
                           .Include(p=>p.Category)
                           .Include(p=>p.Supplier)
                           select p;
                ViewBag.Title = "Products";
                ViewBag.Prds = Prds.ToList();
            }
            return View();
        }

        // GET: Product/Details/5
        [OutputCache(Duration = 60)] // Cach The Output Data For 1 Min
        public ActionResult Details(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var product = context.Products
                           .Include(p => p.Category)
                           .Include(p => p.Supplier)
                           .FirstOrDefault(p => p.ProductId == id);
                ViewBag.Title = "Product";
                ViewBag.Product = product;
            }
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            //ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued
            using (NorthwindContext context = new NorthwindContext())
            {
                ViewBag.SupplierId = (from s in context.Suppliers
                                      select new ToSelect() { Id = s.SupplierId, Name = s.CompanyName })
                                      .ToList();//new SelectList(context.Categories, "CategoryId", "CategoryName");
                ViewBag.CategoryId = (from c in context.Categories
                                      select new ToSelect () { Id = c.CategoryId, Name = c.CategoryName })
                                      .ToList();//new SelectList(context.Suppliers, "SupplierId", "CompanyName");
            }

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued
                Product product = new Product()
                {
                    ProductName = collection["ProductName"],
                    SupplierId = collection["SupplierId"].AsInt(),
                    CategoryId = collection["CategoryId"].AsInt(),
                    QuantityPerUnit = collection["QuantityPerUnit"],
                    Discontinued = collection["Discontinued"].AsBool(),
                };
                using (NorthwindContext context = new NorthwindContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var product = context.Products
                           .Include(p => p.Category)
                           .Include(p => p.Supplier)
                           .FirstOrDefault(p => p.ProductId == id);
                ViewBag.Product = product;
                ViewBag.SupplierId = (from s in context.Suppliers
                                      select new ToSelect() { Id = s.SupplierId, Name = s.CompanyName })
                                      .ToList();
                ViewBag.CategoryId = (from c in context.Categories
                                      select new ToSelect() { Id = c.CategoryId, Name = c.CategoryName })
                                      .ToList();
            }
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                    Product prd = context.Products.Find(id);
                    if(!(prd == default && prd == null))
                    {
                        prd.ProductName = collection["ProductName"];
                        prd.SupplierId = collection["SupplierId"].AsInt();
                        prd.CategoryId = collection["CategoryId"].AsInt();
                        prd.QuantityPerUnit = collection["QuantityPerUnit"];
                        prd.UnitPrice = collection["UnitPrice"].AsDecimal();
                        prd.UnitsInStock = (short)collection["UnitsInStock"].AsInt();
                        prd.UnitsOnOrder = (short)collection["UnitsOnOrder"].AsInt();
                        prd.ReorderLevel = (short)collection["ReorderLevel"].AsInt();
                        prd.Discontinued = collection["Discontinued"].AsBool();
                        context.SaveChanges();
                    }
                }
                    
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var Prds = from p in context.Products
                           .Include(p => p.Category)
                           .Include(p => p.Supplier)
                           select p;
                ViewBag.product = Prds.FirstOrDefault(p => p.ProductId == id);
            }
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                    context.Products.Remove(context.Products.FirstOrDefault(p => p.ProductId == id));
                    context.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
