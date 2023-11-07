using CheckoutSystem.Enums;
using CheckoutSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckoutSystem.DataAccess
{
    public class CheckoutSystemDbContext : DbContext
    {
        public CheckoutSystemDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Film> Films { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relationships
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Films) //1 user has many films
                .WithOne(f => f.Customer) // Each film belongs to one user
                .HasForeignKey(f => f.CustomerId) //Defining foreign key property
                .OnDelete(DeleteBehavior.SetNull); //Allows null in the foreign key

            //Seed
            //Users
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 1, Name = "Martin", LastName = "Lucena", Email = "martin@gmail.com", CustomerType = CustomCustomerType.Member });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 2, Name = "Malin", LastName = "Andersson", Email = "malin@gmail.com", CustomerType = CustomCustomerType.NotMember });

            //Films
            modelBuilder.Entity<Film>().HasData(new Film { Id = 1, CustomerId = 1, Titel = "Titanic", FilmMediaType = CustomMediaType.DVD, Price = 29 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 2, CustomerId = 1, Titel = "The Shawshank Redemption", FilmMediaType = CustomMediaType.BluRay, Price = 39 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 3, CustomerId = 2, Titel = "The Godfather", FilmMediaType = CustomMediaType.DVD, Price = 29 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 4, CustomerId = 2, Titel = "Pulp Fiction", FilmMediaType = CustomMediaType.BluRay, Price = 39 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 5, CustomerId = null, Titel = "The Dark Knight", FilmMediaType = CustomMediaType.DVD, Price = 29 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 6, CustomerId = null, Titel = "Forrest Gump", FilmMediaType = CustomMediaType.BluRay, Price = 39 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 7, CustomerId = null, Titel = "The Matrix", FilmMediaType = CustomMediaType.DVD, Price = 29 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 8, CustomerId = null, Titel = "Schindler's List", FilmMediaType = CustomMediaType.BluRay, Price = 39 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 9, CustomerId = null, Titel = "The Silence of the Lambs", FilmMediaType = CustomMediaType.DVD, Price = 29 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 10, CustomerId = null, Titel = "Fight Club", FilmMediaType = CustomMediaType.BluRay, Price = 39 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 11, CustomerId = null, Titel = "Gladiator", FilmMediaType = CustomMediaType.DVD, Price = 29 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 12, CustomerId = null, Titel = "The Lord of the Rings: The Fellowship of the Ring", FilmMediaType = CustomMediaType.BluRay, Price = 39 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 13, CustomerId = null, Titel = "Star Wars: Episode IV - A New Hope", FilmMediaType = CustomMediaType.DVD, Price = 29 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 14, CustomerId = null, Titel = "Inception", FilmMediaType = CustomMediaType.BluRay, Price = 39 });
            modelBuilder.Entity<Film>().HasData(new Film { Id = 15, CustomerId = null, Titel = "Interstellar", FilmMediaType = CustomMediaType.DVD, Price = 29 });
        }

    }
}
