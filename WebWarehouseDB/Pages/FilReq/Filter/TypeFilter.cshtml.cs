using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWarehouseDB.Data;
using WebWarehouseDB.Models;

namespace WebWarehouseDB.Pages.FilReq.Filter
{
    public class TypeFilterModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public TypeFilterModel(WebWarehouseDB.Data.WarehouseContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }
        public ProductType ProductType { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductType = _context.ProductTypes.First(m => m.TypeId == id);

            if (ProductType == null)
            {
                return NotFound();
            }

            Products = await _context.Products.Where(m => m.TypeId == ProductType.TypeId).ToListAsync();

            return Page();
        }
    }
}
