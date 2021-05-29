using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebWarehouseDB.Data;
using WebWarehouseDB.Models;

namespace WebWarehouseDB.Pages.Providers
{
    public class CreateModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public CreateModel(WebWarehouseDB.Data.WarehouseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SuppliedProduct1Id"] = new SelectList(_context.Products, "ProductId", "ProductId");
        ViewData["SuppliedProduct2Id"] = new SelectList(_context.Products, "ProductId", "ProductId");
        ViewData["SuppliedProduct3Id"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return Page();
        }

        [BindProperty]
        public Provider Provider { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Providers.Add(Provider);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
