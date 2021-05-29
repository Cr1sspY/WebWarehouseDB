using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebWarehouseDB.Data;
using WebWarehouseDB.Models;

namespace WebWarehouseDB.Pages.Providers
{
    public class EditModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public EditModel(WebWarehouseDB.Data.WarehouseContext context)
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
           ViewData["SuppliedProduct1Id"] = new SelectList(_context.Products, "ProductId", "ProductId");
           ViewData["SuppliedProduct2Id"] = new SelectList(_context.Products, "ProductId", "ProductId");
           ViewData["SuppliedProduct3Id"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Provider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderExists(Provider.ProviderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProviderExists(long id)
        {
            return _context.Providers.Any(e => e.ProviderId == id);
        }
    }
}
