using BookManagementSystem.Data;
using BookManagementSystem.Dtos;
using BookManagementSystem.Exceptions;
using BookManagementSystem.Interfaces;
using BookManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystem.Services
{
    public class BookService : IBookService
    {
        //inyeccion de dependencias
        private readonly ApplicationDbContext _dbContext;
        private readonly IAuthorService _authorService;
        private const int MaxBookAllowed = 20; //cantidad de libros permitidos para agregr

        public BookService(ApplicationDbContext dbContext, IAuthorService authorService)
        {
            _dbContext = dbContext;
            _authorService = authorService;
        }
        public async Task<List<BookDTO>> GetAllBooks()
        {
            return await _dbContext.Books
                .Select(b => new BookDTO
                {
                    Title = b.Title,
                    Year = b.Year,
                    Genre = b.Genre,
                    PageCount = b.PageCount,
                    AuthorId = b.AuthorId
                })
                .ToListAsync();
        }

        public async Task<BookDTO> CreateBook(BookDTO bookDto)
        {
            //limite de libros - validacion
            var bookCount = await _dbContext.Books.CountAsync();
            if (bookCount > MaxBookAllowed) 
            {

                throw new MaxBooksExceededException("No es posible registrar el libro, alcanzó el máximo permitido");
            }

            //validacion si el author si existe
            if (!await _authorService.AuthorExists(bookDto.AuthorId)) 
            {
                throw new AuthorNotFoundException("El Autor No existe. Debe agregarlo primero");
            }

            var book = new Book
            {
                Title = bookDto.Title,
                Year = bookDto.Year,
                Genre = bookDto.Genre,
                PageCount = bookDto.PageCount,
                AuthorId = bookDto.AuthorId
            };

            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return bookDto;

        }
    }
}
