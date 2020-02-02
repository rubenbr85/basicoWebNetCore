using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BasicoWebRazorCore.Data;
using BasicoWebRazorCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Genre> genreQuery = from g in _context.Genre
                                            orderby g.Name
                                            select g;

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            int idGenre;
            if (!string.IsNullOrEmpty(MovieGenre) && int.TryParse(MovieGenre,out idGenre))
            {
                movies = movies.Where(x => x.GenreID == idGenre);
            }
            Genres = new SelectList(await genreQuery.ToListAsync(),"ID","Name");
            Movie = await movies.ToListAsync();
        }
    }
}
