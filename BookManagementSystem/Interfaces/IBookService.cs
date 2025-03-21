using BookManagementSystem.Dtos;

namespace BookManagementSystem.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooks();
        Task<BookDTO> CreateBook(BookDTO bookDTO);
    }
}
