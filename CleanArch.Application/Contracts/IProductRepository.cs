using CleanArch.Domain.Entities;

namespace CleanArch.Application.Contracts;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<bool> UpdateAsync(Product product);
    Task<bool> DeleteAsync(Guid id);
}
