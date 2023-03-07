using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment3.Models;

namespace Assignment3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Assignment3.Models.Movie> Movie { get; set; }
        public DbSet<Assignment3.Models.Actor> Actor { get; set; }
        public DbSet<Assignment3.Models.MovieActor> MovieActor { get; set; }
        public DbSet<Assignment3.Models.MovieTweets> MovieTweets { get; set; }
        public DbSet<Assignment3.Models.ActorTweets> ActorTweets { get; set; }
    }
}