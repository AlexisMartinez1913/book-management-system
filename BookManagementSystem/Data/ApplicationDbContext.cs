using BookManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //Crear Tablas de la base de datos
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        //Sembrar datos iniciales en las tablas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FullName = "Gabriel García Márquez",
                    BirthDate = new DateTime(1927, 3, 6),
                    City = "Aracataca",
                    Email = "gabriel@example.com"
                },
                new Author
                {
                    Id = 2,
                    FullName = "Paulo Coelho",
                    BirthDate = new DateTime(1947, 8, 24),
                    City = "Río De Janeiro",
                    Email = "paulo@example.com"
                }
            );

            //sembrar datos para books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Cien años de soledad",
                    Year = 1967,
                    Genre = "Realismo mágico",
                    PageCount = 417,
                    AuthorId = 1 // Relacion con Gabriel García Márquez
                },
                new Book
                {
                    Id = 2,
                    Title = "El Alquimista",
                    Year = 1988,
                    Genre = "Drama",
                    PageCount = 192,
                    AuthorId = 2 // relacion con paulo coelho
                }
            );
        }
    }
}
