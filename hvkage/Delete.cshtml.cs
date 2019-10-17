using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShinobiRanks1._0.Data;

namespace ShinobiRanks1._0.Pages.hvkage
{
    public class DeleteModel : PageModel
    {
        private readonly ShinobiRanks1._0.Data.ApplicationDbContext _context;

        public DeleteModel(ShinobiRanks1._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HVKage HVKage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HVKage = await _context.HVKage
                .Include(h => h.KVillages).FirstOrDefaultAsync(m => m.KID == id);

            if (HVKage == null)
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

            HVKage = await _context.HVKage.FindAsync(id);

            if (HVKage != null)
            {
                _context.HVKage.Remove(HVKage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
