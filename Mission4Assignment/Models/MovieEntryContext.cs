using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4Assignment.Models
{
    public class MovieEntryContext :DbContext

    {
        public MovieEntryContext (DbContextOptions<MovieEntryContext> options) : base(options)
        {
            //leave blank for now
        }

        public DbSet<MovieEntry> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)  //as long as its in the chain/inherited its ok
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Animated"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Space"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Pensive"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Who Knows?"
                }
                );
            mb.Entity<MovieEntry>().HasData( //This seeds the database with some initial entries
                new MovieEntry
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "How to Train Your Dragon",
                    Year = 2010,
                    Director = "IDK",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Nah",
                    Notes = "Favorite Movie Ever"

                },
                new MovieEntry
                {
                    MovieId = 2,
                    CategoryId = 2,
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Nah",
                    Notes = "Top 5"

                },
                new MovieEntry
                {
                    MovieId = 3,
                    CategoryId = 3,
                    Title = "Manchester by the Sea",
                    Year = 2016,
                    Director = "Kenneth Logernan",
                    Rating = "R",
                    Edited = false,
                    LentTo = "Nah",
                    Notes = "Promising"

                }

                );
        }
       

    }
}
