using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWarehouseDB.Data;
using WebWarehouseDB.Models;

namespace WebWarehouseDB.Pages.Warehouses
{
    public class DetailsModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public DetailsModel(WebWarehouseDB.Data.WarehouseContext context)
        {
            _context = context;
        }

        public Warehouse Warehouse { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Warehouse = await _context.Warehouses
                .Include(w => w.Customer)
                .Include(w => w.Employee)
                .Include(w => w.Product)
                .Include(w => w.Provider).FirstOrDefaultAsync(m => m.WarehouseId == id);

            if (Warehouse == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
