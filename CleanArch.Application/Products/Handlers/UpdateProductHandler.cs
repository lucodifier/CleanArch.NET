using MediatR;
using CleanArch.Domain.Entities;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Contracts;

namespace CleanArch.Application.Products.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _repo;

    public UpdateProductHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var existingProduct = await _repo.GetByIdAsync(request.Id);
        if (existingProduct == null)
            return false;

        existingProduct.Update(request.Name, request.Price);
        return await _repo.UpdateAsync(existingProduct);
    }
}
