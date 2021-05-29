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
    public class IndexModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public IndexModel(WebWarehouseDB.Data.WarehouseContext context)
        {
            _context = context;
        }

        public IList<Warehouse> Warehouse { get;set; }

        public async Task OnGetAsync()
        {
            Warehouse = await _context.Warehouses
                .Include(w => w.Customer)
                .Include(w => w.Employee)
                .Include(w => w.Product)
                .Include(w => w.Provider).ToListAsync();
        }
    }
}
