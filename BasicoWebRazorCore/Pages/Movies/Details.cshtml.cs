using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasicoWebRazorCore.Data;
using BasicoWebRazorCore.Models;

namespace BasicoWebRazorCore
{
    public class DetailsModel : PageModel
    {
        private readonly BasicoWebRazorCore.Data.BasicoWebRazorCoreContext _context;

        public DetailsModel(BasicoWebRazorCore.Data.BasicoWebRazorCoreContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.Include(g =>g.Genre).FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
