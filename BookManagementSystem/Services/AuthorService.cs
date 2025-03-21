using BookManagementSystem.Data;
using BookManagementSystem.Dtos;
using BookManagementSystem.Interfaces;
using BookManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Buscar autor por id y verificar si existe
        public async Task<bool> AuthorExists(int authorId)
        {
            return await _dbContext.Authors.AnyAsync(a => a.Id == authorId);
        }

        //Logica para crear un autor
        public async Task<AuthorDTO> CreateAuthor(AuthorDTO authorDTO)
        {
            var author = new Author
            {
                FullName = authorDTO.FullName,
                BirthDate = authorDTO.BirthDate,
                City = authorDTO.City,
                Email = authorDTO.Email
            };

            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();

            return authorDTO;
        }

        //Logica para listar todos los autores
        public async Task<List<AuthorDTO>> GetAllAuthors()
        {
            return await _dbContext.Authors
                .Select(a => new AuthorDTO
                {
                    FullName = a.FullName,
                    BirthDate = a.BirthDate,
                    City = a.City,
                    Email = a.Email,
                })
                .ToListAsync();
               
            
        }
    }
}
