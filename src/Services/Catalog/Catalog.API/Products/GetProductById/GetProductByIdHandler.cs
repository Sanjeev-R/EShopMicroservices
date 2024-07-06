using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id)
        : IQuery<GetProductByIdResult>;

    public record GetProductByIdResult(Product Product);

    internal class GetProductByIdHandler(IDocumentSession session)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id);
            return product is null
                ? throw new ProductNotfoundException($"Product with id {query.Id} not found")
                : new GetProductByIdResult(product);
        }
    }
}
