using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BasicoWebRazorCore.Data;
using BasicoWebRazorCore.Models;


namespace BasicoWebRazorCore
{ 
    public class GenreNamePageModel : PageModel
    {
        public SelectList GenreList { get; set; }

        public void GenreDropDownList(BasicoWebRazorCoreContext _context,
            object selectedGenre = null)
        {

            IQueryable<Genre> genreQuery = from g in _context.Genre
                                           orderby g.Name
                                           select g;
            GenreList = new SelectList( genreQuery.AsNoTracking(), "ID", "Name", selectedGenre);


        }
    }
}
