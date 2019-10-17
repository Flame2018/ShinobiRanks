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
    public class DeleteModel : PageModel
    {
        private readonly ShinobiRanks1._0.Data.ApplicationDbContext _context;

        public DeleteModel(ShinobiRanks1._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HVJounin = await _context.HVJounin.FindAsync(id);

            if (HVJounin != null)
            {
                _context.HVJounin.Remove(HVJounin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
