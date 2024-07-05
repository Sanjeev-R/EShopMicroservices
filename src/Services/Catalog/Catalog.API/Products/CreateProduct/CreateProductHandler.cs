using BuildingBlocks.CQRS;
using Catalog.API.Models;

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
    internal class CreateProductCommandHandler
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

            // Return product id.
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
