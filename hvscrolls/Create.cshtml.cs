using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShinobiRanks1._0.Data;

namespace ShinobiRanks1._0.Pages.hvscrolls
{
    public class CreateModel : PageModel
    {
        private readonly ShinobiRanks1._0.Data.ApplicationDbContext _context;

        public CreateModel(ShinobiRanks1._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["HVID"] = new SelectList(_context.HVillage, "HVID", "HVID");
            return Page();
        }

        [BindProperty]
        public HVScrolls HVScrolls { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HVScrolls.Add(HVScrolls);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}