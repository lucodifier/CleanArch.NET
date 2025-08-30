using MediatR;

namespace CleanArch.Application.Products.Commands;

public record DeleteProductCommand(Guid Id) : IRequest<bool>;
