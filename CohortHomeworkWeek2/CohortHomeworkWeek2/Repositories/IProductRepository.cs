using CohortHomeworkWeek2.Models;

namespace CohortHomeworkWeek2.Repositories


{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(string? name = null);
        Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
