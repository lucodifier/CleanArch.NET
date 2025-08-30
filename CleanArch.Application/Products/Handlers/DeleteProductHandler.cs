using MediatR;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Contracts;

namespace CleanArch.Application.Products.Handlers;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repo;

    public DeleteProductHandler(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return await _repo.DeleteAsync(request.Id);
    }
}
