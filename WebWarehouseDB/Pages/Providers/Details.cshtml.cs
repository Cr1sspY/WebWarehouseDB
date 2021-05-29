using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWarehouseDB.Data;
using WebWarehouseDB.Models;

namespace WebWarehouseDB.Pages.Providers
{
    public class DetailsModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public DetailsModel(WebWarehouseDB.Data.WarehouseContext context)
        {
            _context = context;
        }

        public Provider Provider { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Provider = await _context.Providers
                .Include(p => p.SuppliedProduct1)
                .Include(p => p.SuppliedProduct2)
                .Include(p => p.SuppliedProduct3).FirstOrDefaultAsync(m => m.ProviderId == id);

            if (Provider == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
