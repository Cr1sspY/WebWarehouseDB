using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWarehouseDB.Data;
using WebWarehouseDB.Models;

namespace WebWarehouseDB.Pages.FilReq.Filter
{
    public class EmployeeFilterModel : PageModel
    {
        private readonly WebWarehouseDB.Data.WarehouseContext _context;

        public EmployeeFilterModel(WebWarehouseDB.Data.WarehouseContext context)
        {
            _context = context;
        }

        public IList<Employee> Employees { get; set; }
        public Position Position { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = _context.Positions.First(m => m.PositionId == id);

            if (Position == null)
            {
                return NotFound();
            }

            Employees = await _context.Employees
                .Include(e => e.Position).Where(m => m.PositionId == Position.PositionId).ToListAsync();

            return Page();
        }
    }
}
