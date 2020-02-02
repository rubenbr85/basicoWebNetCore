﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly BasicoWebRazorCore.Data.BasicoWebRazorCoreContext _context;

        public DetailsModel(BasicoWebRazorCore.Data.BasicoWebRazorCoreContext context)
        {
            _context = context;
        }

        public Genre Genre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genre = await _context.Genre.FirstOrDefaultAsync(m => m.ID == id);

            if (Genre == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
