using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShinobiRanks1._0.Data;

namespace ShinobiRanks1._0.Pages.hvscrolls
{
    [Authorize(Roles ="kage")]
    public class IndexModel : PageModel
    {
        private readonly ShinobiRanks1._0.Data.ApplicationDbContext _context;

        public IndexModel(ShinobiRanks1._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<HVScrolls> HVScrolls { get;set; }

        public async Task OnGetAsync()
        {
            HVScrolls = await _context.HVScrolls
                .Include(h => h.Villages).ToListAsync();
        }
    }
}
