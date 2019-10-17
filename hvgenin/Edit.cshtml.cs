using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShinobiRanks1._0.Data;

namespace ShinobiRanks1._0.Pages.hvgenin
{
    public class EditModel : PageModel
    {
        private readonly ShinobiRanks1._0.Data.ApplicationDbContext _context;

        public EditModel(ShinobiRanks1._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HVGenin HVGenin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HVGenin = await _context.HVGenin
                .Include(h => h.GVillages).FirstOrDefaultAsync(m => m.GID == id);

            if (HVGenin == null)
            {
                return NotFound();
            }
           ViewData["HVID"] = new SelectList(_context.HVillage, "HVID", "HVID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HVGenin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HVGeninExists(HVGenin.GID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HVGeninExists(int id)
        {
            return _context.HVGenin.Any(e => e.GID == id);
        }
    }
}
