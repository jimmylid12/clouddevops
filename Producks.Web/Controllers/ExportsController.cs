﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Producks.Data;
using Producks.Web.Models;

namespace Producks.Web.Controllers
{
    [ApiController]
    public class ExportsController : ControllerBase
    {
        private readonly StoreDb _context;

        public ExportsController(StoreDb context)
        {
            _context = context;
        }

        // GET: api/Brands
        [HttpGet("api/Brands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _context.Brands
                                       .Select(b => new BrandDto
                                       {
                                           Id = b.Id,
                                           Name = b.Name,
                                           Active = b.Active
                                       })
                                       .ToListAsync();
            return Ok(brands);
        }

        // GET: api/Catergories
        [HttpGet("api/Categories")]
        public async Task<IActionResult> GetCatergories()
        {
            var categories = await _context.Categories
                                       .Select(c => new CategoryDto
                                       {
                                           Id = c.Id,
                                           Name = c.Name,
                                           Active = c.Active,
                                           Description = c.Description
                                       })
                                       .ToListAsync();
            return Ok(categories);
        }

        // GET: api/Catergories
        [HttpGet("api/products/{id?}")]
        public async Task<IActionResult> GetProducts(int? id)
        {
            var products = await _context.Products.Where(p => id == p.CategoryId)
                                      .Select(p => new ProductDto
                                       {
                                           Id = p.Id,
                                           Name =p.Name,
                                           Active = p.Active,

                                         Price = p.Price,
                                         CategoryId = p.CategoryId
                                       })
                                       .ToListAsync();
            return Ok(products);
        }


    }

   
}
