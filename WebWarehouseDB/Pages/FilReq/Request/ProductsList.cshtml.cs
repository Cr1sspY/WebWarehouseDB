using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWarehouseDB.Data;
using WebWarehouseDB.Models;

namespace WebWarehouseDB.Pages.FilReq.Request
{
    public class ProductsListModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public ProductsListModel(WebWarehouseDB.Data.WarehouseContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }
        public IList<ProductType> ProductTypes { get; set; }
        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
            ProductTypes = await _context.ProductTypes.ToListAsync();
        }
    }
}
