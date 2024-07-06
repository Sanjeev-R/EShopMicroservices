
namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid ProductId) : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsDeleted);
    public class DeleteProductHandler(IDocumentSession session)
        : IRequestHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(
            DeleteProductCommand request, CancellationToken cancellationToken)
        {
            session.Delete<Product>(request.ProductId);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }
    }
}
