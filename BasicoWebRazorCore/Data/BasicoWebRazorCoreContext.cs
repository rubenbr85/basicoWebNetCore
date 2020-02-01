using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BasicoWebRazorCore.Models;

namespace BasicoWebRazorCore.Data
{
    public class BasicoWebRazorCoreContext : DbContext
    {
        public BasicoWebRazorCoreContext (DbContextOptions<BasicoWebRazorCoreContext> options)
            : base(options)
        {
        }

        public DbSet<BasicoWebRazorCore.Models.Movie> Movie { get; set; }
    }
}
