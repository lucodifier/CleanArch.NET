using MediatR;

namespace CleanArch.Application.Products.Commands;

public record UpdateProductCommand(Guid Id, string Name, decimal Price) : IRequest<bool>;
