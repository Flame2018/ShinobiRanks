using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShinobiRanks1._0.Data;

namespace ShinobiRanks1._0.Pages.hvjounin
{
    public class EditModel : PageModel
    {
        private readonly ShinobiRanks1._0.Data.ApplicationDbContext _context;

        public EditModel(ShinobiRanks1._0.Data.ApplicationDbContext context)
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
           ViewData["HVID"] = new SelectList(_context.HVillage, "HVID", "HVID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HVJounin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HVJouninExists(HVJounin.JID))
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

        private bool HVJouninExists(int id)
        {
            return _context.HVJounin.Any(e => e.JID == id);
        }
    }
}
