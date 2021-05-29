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
    public class DeleteModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public DeleteModel(WebWarehouseDB.Data.WarehouseContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Provider = await _context.Providers.FindAsync(id);

            if (Provider != null)
            {
                _context.Providers.Remove(Provider);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
