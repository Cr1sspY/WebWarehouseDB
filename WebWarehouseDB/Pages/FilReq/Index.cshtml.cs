using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebWarehouseDB.Pages.FilReq
{
    public class IndexModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public IndexModel(WebWarehouseDB.Data.WarehouseContext context)
        {
            _context = context;
        }

        public List<SelectListItem> HRDep { get; set; }
        public List<SelectListItem> ProductsList { get; set; }
        public List<SelectListItem> ProvidersList { get; set; }
        public List<SelectListItem> CustomersList { get; set; }
        public List<SelectListItem> Orders { get; set; }

        public IActionResult OnGet()
        {
            HRDep = _context.Positions.Select(p =>
            new SelectListItem
            {
                Value = p.PositionId.ToString(),
                Text = p.Name
            }).ToList();

            ProductsList = _context.ProductTypes.Select(p =>
            new SelectListItem
            {
                Value = p.TypeId.ToString(),
                Text = p.Name
            }).ToList();

            ProvidersList = _context.Providers.Select(p =>
            new SelectListItem
            {
                Value = p.ProviderId.ToString(),
                Text = p.Name
            }).ToList();

            CustomersList = _context.Customers.Select(p =>
            new SelectListItem
            {
                Value = p.CustomerId.ToString(),
                Text = p.Name
            }).ToList();

            Orders = _context.Warehouses.Select(p =>
            new SelectListItem
            {
                Value = p.TypeOfDelivery.ToString(),
                Text = p.ProductId.ToString()
            }).ToList();

            return Page();
        }
    }
}
