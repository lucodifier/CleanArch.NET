using MediatR;

namespace CleanArch.Application.Products.Commands;

public record CreateProductCommand(string Name, decimal Price) : IRequest<Guid>;
