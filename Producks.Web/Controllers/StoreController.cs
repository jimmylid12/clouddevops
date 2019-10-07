using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Producks.Data;

namespace Producks.Web.Controllers
{
    public class StoreController : Controller
    {

        private readonly StoreDb _context;

        public StoreController(StoreDb context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var model = await _context.Categories.ToListAsync();
            return View(model);

           



        }


        public async Task<IActionResult> ProductByCategory(int? id)
        {
            var model = await _context
                            .Products
                            .Where(p => p.CategoryId == id)
                            .ToListAsync();

            return View(model);
        }



        }
}