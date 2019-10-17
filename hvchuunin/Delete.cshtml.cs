using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShinobiRanks1._0.Data;

namespace ShinobiRanks1._0.Pages.hvchuunin
{
    public class DeleteModel : PageModel
    {
        private readonly ShinobiRanks1._0.Data.ApplicationDbContext _context;

        public DeleteModel(ShinobiRanks1._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HVChuunin HVChuunin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HVChuunin = await _context.HVChuunin
                .Include(h => h.CVillages).FirstOrDefaultAsync(m => m.CID == id);

            if (HVChuunin == null)
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

            HVChuunin = await _context.HVChuunin.FindAsync(id);

            if (HVChuunin != null)
            {
                _context.HVChuunin.Remove(HVChuunin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
