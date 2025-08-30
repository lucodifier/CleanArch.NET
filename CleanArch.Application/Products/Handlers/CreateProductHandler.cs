using MediatR;
using CleanArch.Domain.Entities;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Contracts;

namespace CleanArch.Application.Products.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _repo;

    public CreateProductHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Price);
        await _repo.AddAsync(product);
        return product.Id;
    }
}
