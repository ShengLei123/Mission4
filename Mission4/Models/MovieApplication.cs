using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieApplication: DbContext
    {
        public MovieApplication (DbContextOptions<MovieApplication> options): base (options)
        {

        }
        public DbSet<MovieResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieResponse>().HasData(
                new MovieResponse
                {
                    MovieID = 1,
                    Category = "Action/Adventure",
                    Title = "sasa sa",
                    Year = 2121,
                    Director = "dfds",
                    Rating = "G",
                    Edited = true
                },
                new MovieResponse
                {
                    MovieID = 2,
                    Category = "Action/Adventure",
                    Title = "sasawqw",
                    Year = 2433,
                    Director = "ewc edfw",
                    Rating = "PG-13",
                    Edited = false
                },
                new MovieResponse
                {
                    MovieID = 3,
                    Category = "Family",
                    Title = "some some",
                    Year = 2011,
                    Director = "some one",
                    Rating = "PG",
                    Edited = false
                }
            );
        }
    }
}
