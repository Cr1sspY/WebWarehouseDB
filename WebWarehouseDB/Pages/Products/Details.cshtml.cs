using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWarehouseDB.Data;
using WebWarehouseDB.Models;

namespace WebWarehouseDB.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public DetailsModel(WebWarehouseDB.Data.WarehouseContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(p => p.Type).FirstOrDefaultAsync(m => m.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
