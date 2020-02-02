﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BasicoWebRazorCore.Data;
using System;
using System.Linq;

namespace BasicoWebRazorCore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BasicoWebRazorCoreContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BasicoWebRazorCoreContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }


                context.Genre.AddRange(
                    new Genre
                    {
                        Name = "Terror"
                    },
                    new Genre
                    {
                        Name = "Action"
                    },
                    new Genre
                    {
                        Name = "Love"
                    }
                 );
                    
               context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating="PG-3"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating="PG-13"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating="PG-13"
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating="PG-18"
                    }
                );


                context.SaveChanges();
            }
        }
    }
}
