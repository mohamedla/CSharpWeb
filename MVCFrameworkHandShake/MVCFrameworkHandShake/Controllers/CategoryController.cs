using Microsoft.Ajax.Utilities;
using MVCFrameworkHandShake.Context;
using MVCFrameworkHandShake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFrameworkHandShake.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            List<Category> Categories;
            using (NorthwindContext context = new NorthwindContext())
            {
                Categories = (from c in context.Categories
                           select c).ToList();
                ViewBag.Title = "Categories";
            }
            return View(Categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            Category category;
            using (NorthwindContext context = new NorthwindContext())
            {
                category = (from c in context.Categories
                               select c)
                           .FirstOrDefault(c => c.CategoryId == id);
                ViewBag.Title = category.CategoryName;
            }
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category collection)
        {
            Category category;
            try
            {
                //category = new Category()
                //{
                //    CategoryName = collection["CategoryName"],
                //    Description = collection["Description"]
                //};
                // TODO: Add insert logic here
                using (NorthwindContext context = new NorthwindContext())
                {
                    context.Categories.Add(collection);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                category = new Category();
                return View(category);
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category category;
            using (NorthwindContext context = new NorthwindContext())
            {
                category = (from c in context.Categories
                            select c)
                           .FirstOrDefault(c => c.CategoryId == id);
                ViewBag.Title = category.CategoryName;
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Category category;
            try
            {
                
                using (NorthwindContext context = new NorthwindContext())
                {
                    category = (from c in context.Categories
                                select c)
                               .FirstOrDefault(c => c.CategoryId == id);
                    category.CategoryName = collection["CategoryName"];
                    category.Description = collection["Description"];

                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                category= new Category();
                return View(category);
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            Category category;
            using (NorthwindContext context = new NorthwindContext())
            {
                category = (from c in context.Categories
                            select c)
                           .FirstOrDefault(c => c.CategoryId == id);
                ViewBag.Title = category.CategoryName;
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Category category;
            try
            {
                using (NorthwindContext context = new NorthwindContext())
                {
                    context.Categories.Remove(context.Categories.Find(id));
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                category = new Category();
                return View(category);
            }
        }
    }
}
