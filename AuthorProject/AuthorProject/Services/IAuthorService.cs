using AuthorProject.Dtos.Author;

namespace AuthorProject.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAsync();
        Task<AuthorDto> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateAuthorDto authorDto);
        Task UpdateAsync(int id, UpdateAuthorDto authorDto);
        Task DeleteAsync(int id);
    }
}
