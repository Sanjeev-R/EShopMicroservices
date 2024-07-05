﻿using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        string Price)
        : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid id);
    internal class CreateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(
            CreateProductCommand command,
            CancellationToken cancellationToken)
        {
            // Create product entity from command object


            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
            };

            // Save to database.
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            // Return product id.
            return new CreateProductResult(product.Id);
        }
    }
}
