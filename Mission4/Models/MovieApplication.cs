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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId=1, CategoryName= "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );
            mb.Entity<MovieResponse>().HasData(
                new MovieResponse
                {
                    MovieID = 1,
                    CategoryId = 1,
                    Title = "sasa sa",
                    Year = 2121,
                    Director = "dfds",
                    Rating = "G",
                    Edited = true
                },
                new MovieResponse
                {
                    MovieID = 2,
                    CategoryId = 2,
                    Title = "sasawqw",
                    Year = 2433,
                    Director = "ewc edfw",
                    Rating = "PG-13",
                    Edited = false
                },
                new MovieResponse
                {
                    MovieID = 3,
                    CategoryId = 3,
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
