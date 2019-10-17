using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShinobiRanks1._0.Data;

namespace ShinobiRanks1._0.Pages.hvchuunin
{
    public class EditModel : PageModel
    {
        private readonly ShinobiRanks1._0.Data.ApplicationDbContext _context;

        public EditModel(ShinobiRanks1._0.Data.ApplicationDbContext context)
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
           ViewData["HVID"] = new SelectList(_context.HVillage, "HVID", "HVID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HVChuunin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HVChuuninExists(HVChuunin.CID))
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

        private bool HVChuuninExists(int id)
        {
            return _context.HVChuunin.Any(e => e.CID == id);
        }
    }
}
