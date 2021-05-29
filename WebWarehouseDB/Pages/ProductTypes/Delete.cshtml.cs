using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWarehouseDB.Data;
using WebWarehouseDB.Models;

namespace WebWarehouseDB.Pages.ProductTypes
{
    public class DeleteModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public DeleteModel(WebWarehouseDB.Data.WarehouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductType ProductType { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductType = await _context.ProductTypes.FirstOrDefaultAsync(m => m.TypeId == id);

            if (ProductType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductType = await _context.ProductTypes.FindAsync(id);

            if (ProductType != null)
            {
                _context.ProductTypes.Remove(ProductType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
