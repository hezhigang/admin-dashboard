using Microsoft.EntityFrameworkCore;
using admin_dashboard.Data;

namespace admin_dashboard.Models
{
        public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context == null || context.Categories == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Categories.Any())
                {
                    return;   // DB has been seeded
                }

                context.Categories.AddRange(
                new Category { Id = 1, Name = "Story Book" },
                new Category { Id = 2, Name = "Pictue Book" },
                new Category { Id = 3, Name = "Comic Book" }
                );

                context.Books.AddRange(
                                    new Book { Id = 1, CategoryId = 1, Title = "Big Joe's trailer truck", Sku = "20", Author = "Joe Mathieu", Description = "This is Big Joe. He is a truck driver. ...", Price = 4.25M, IsAvailable = true, Thumbnail = "img/big-joe-trailer-truck.jpeg" },
                new Book { Id = 2, CategoryId = 1, Title = "Moon Game", Sku = "1", Author = "Frank Asch", Description = "One day, Little Bird showed Bear a new game: hide and seek. ...", Price = 0.50M, IsAvailable = true, Thumbnail = "img/moon-game.jpeg" },
                new Book { Id = 3, CategoryId = 2, Title = "Starry, Starry Night", Sku = "3", Author = "Bill Scollon", Description = "Doc MacStuffins is excited. Her brother, Donny, is excited, too. They are going to watch a meteor shower! ...", Price = 4.50M, IsAvailable = true, Thumbnail = "img/starry-night.jpeg" },
                new Book { Id = 4, CategoryId = 3, Title = "Pete the Cat's Family Road Trip", Sku = "10", Author = "Kimberly & James Dean", Description = "Pete, Bob, Mom and Dad are going on a road trip across the United States! ...", Price = 5.99M, IsAvailable = true, Thumbnail = "img/pete-family-road-trip.jpeg" },
                new Book { Id = 5, CategoryId = 1, Title = "Frog and a very special day", Sku = "1", Author = "Max Velthuijs", Description = "Frog was having breakfast.", Price = 11.95M, IsAvailable = true, Thumbnail = "img/frog.jpeg" },
                new Book { Id = 6, CategoryId = 1, Title = "The snow champion", Sku = "1", Author = "Carol Pugano-Martin", Description = "It was morning on Birdwell Island. Everything was covered with snow. So was Clifford!", Price = 1.0M, IsAvailable = true, Thumbnail = "img/the-snow-champion.jpeg" },
                new Book { Id = 7, CategoryId = 2, Title = "Cuddle up, Goodnight", Sku = "1", Author = "Katie Cleminson", Description = "It's time to wake up ...", Price = 17.50M, IsAvailable = true, Thumbnail = "img/cuddle-up-goodnight.jpeg" }
                );

                context.SaveChanges();
            }
        }
    }
}