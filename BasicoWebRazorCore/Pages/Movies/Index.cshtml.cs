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
    public class IndexModel : PageModel
    {
        private readonly BasicoWebRazorCore.Data.BasicoWebRazorCoreContext _context;

        public IndexModel(BasicoWebRazorCore.Data.BasicoWebRazorCoreContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
