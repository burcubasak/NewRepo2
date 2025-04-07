using AuthorProject.DbContexts;
using AuthorProject.Dtos.Author;
using AuthorProject.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorProject.Services
{
    public class AuthorServices : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly MsSqlDbContext _dbContext;
        public AuthorServices(IMapper mapper, MsSqlDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<AuthorDto>> GetAllAsync()
        {
            var authors = await _dbContext.Authors.ToListAsync();
            return _mapper.Map<List<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetByIdAsync(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            if (author == null)
            {
                throw new Exception("Author not found");
            }
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<int> CreateAsync(CreateAuthorDto createAuthor)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Name == createAuthor.Name && x.Surname == createAuthor.Surname);
            if (author != null)
            {
                throw new Exception("Author already exists");
            }
            var newAuthor = _mapper.Map<Author>(createAuthor);
            await _dbContext.Authors.AddAsync(newAuthor);
            await _dbContext.SaveChangesAsync();
            return newAuthor.Id;
        }

        public async Task UpdateAsync(int id, UpdateAuthorDto updateAuthor)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            if (author == null)
            {
                throw new Exception("Author not found");
            }
            _mapper.Map(updateAuthor, author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            if (author == null)
            {
                throw new Exception("Author not found");
            }
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }
    }
}
