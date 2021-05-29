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
    public class HRDepModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public HRDepModel(WebWarehouseDB.Data.WarehouseContext context)
        {
            _context = context;
        }

        public IList<Employee> Employees { get; set; }
        public IList<Position> Positions { get; set; }
        public async Task OnGetAsync()
        {
            Employees = await _context.Employees.ToListAsync();
            Positions = await _context.Positions.ToListAsync();
        }
    }
}
