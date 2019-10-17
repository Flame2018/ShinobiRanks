using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShinobiRanks1._0.Data;

namespace ShinobiRanks1._0.Pages.hvscrolls
{
    public class DetailsModel : PageModel
    {
        private readonly ShinobiRanks1._0.Data.ApplicationDbContext _context;

        public DetailsModel(ShinobiRanks1._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public HVScrolls HVScrolls { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HVScrolls = await _context.HVScrolls
                .Include(h => h.Villages).FirstOrDefaultAsync(m => m.VSID == id);

            if (HVScrolls == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
