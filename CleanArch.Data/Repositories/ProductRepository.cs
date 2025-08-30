using CleanArch.Application.Contracts;
using CleanArch.Domain.Entities;

namespace CleanArch.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = [];

    public Task AddAsync(Product product)
    {
        _products.Add(product);
        return Task.CompletedTask;
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult(_products.AsEnumerable());
    }

    public Task<bool> UpdateAsync(Product product)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct == null)
            return Task.FromResult(false);

        var index = _products.IndexOf(existingProduct);
        _products[index] = product;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return Task.FromResult(false);

        _products.Remove(product);
        return Task.FromResult(true);
    }
}
