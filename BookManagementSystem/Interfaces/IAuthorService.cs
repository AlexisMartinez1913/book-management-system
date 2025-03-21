using BookManagementSystem.Dtos;

namespace BookManagementSystem.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAllAuthors();
        Task<AuthorDTO> CreateAuthor(AuthorDTO authorDTO);
        Task<bool> AuthorExists(int authorId);
    }
}
