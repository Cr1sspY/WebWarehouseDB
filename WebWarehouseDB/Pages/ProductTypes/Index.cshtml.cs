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
    public class IndexModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public IndexModel(WebWarehouseDB.Data.WarehouseContext context)
        {
            _context = context;
        }

        public IList<ProductType> ProductType { get;set; }

        public async Task OnGetAsync()
        {
            ProductType = await _context.ProductTypes.ToListAsync();
        }
    }
}
