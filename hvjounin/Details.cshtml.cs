using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShinobiRanks1._0.Data;

namespace ShinobiRanks1._0.Pages.hvjounin
{
    public class DetailsModel : PageModel
    {
        private readonly ShinobiRanks1._0.Data.ApplicationDbContext _context;

        public DetailsModel(ShinobiRanks1._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public HVJounin HVJounin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HVJounin = await _context.HVJounin
                .Include(h => h.JVillages).FirstOrDefaultAsync(m => m.JID == id);

            if (HVJounin == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
