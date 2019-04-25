using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        // this controller depends on the NorthwindRepository
        private INorthwindRepository repository;
        public ProductController(INorthwindRepository repo) => repository = repo;

        public IActionResult Category() => View(repository.Categories.OrderBy(c => c.CategoryName));

        public IActionResult Index(int id) => View(new ProductViewModel
        {
            Products = repository.Products
            .Where(p => p.Discontinued == false && p.CategoryId == id)
            .OrderBy(p => p.ProductName)
        });

        public IActionResult Discount() => View(repository.Discounts
            .Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now));
    }
}