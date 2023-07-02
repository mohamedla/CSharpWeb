using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Products.Context;
using Products.Models;

namespace Products.Pages.Prds
{
    public class CatSelect
    {
        public int Id { get; set; }
        public string Name { get; set;}
    }
    public class IndexModel : PageModel
    {
        private readonly Products.Context.NorthwindContext _context;

        public IndexModel(Products.Context.NorthwindContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public List<CatSelect> Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SearchCat { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                //Product = await _context.Products
                //.Include(p => p.Category)
                //.Include(p => p.Supplier).ToListAsync();

                var CategoriesLst = from c in _context.Categories
                                    select new CatSelect { Id =c.CategoryId , Name = c.CategoryName};

                var products = from p in _context.Products
                           .Include(p => p.Category)
                           .Include(p => p.Supplier)
                               select p;
                if (!string.IsNullOrEmpty(SearchString))
                    products = from p in products
                               where p.ProductName.Contains(SearchString)
                               select p;
                if (SearchCat > 0)
                    products = from p in products
                               where p.Category.CategoryId == SearchCat
                               select p;

                Categories = await CategoriesLst.ToListAsync();
                Product = await products.ToListAsync();
            }
        }
    }
}
