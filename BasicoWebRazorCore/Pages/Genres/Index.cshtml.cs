using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasicoWebRazorCore.Data;
using BasicoWebRazorCore.Models;

namespace BasicoWebRazorCore.Genres
{
    public class IndexModel : PageModel
    {
        private readonly BasicoWebRazorCore.Data.BasicoWebRazorCoreContext _context;

        public IndexModel(BasicoWebRazorCore.Data.BasicoWebRazorCoreContext context)
        {
            _context = context;
        }

        public IList<Genre> Genre { get;set; }

        public async Task OnGetAsync()
        {
            Genre = await _context.Genre.ToListAsync();
        }
    }
}
