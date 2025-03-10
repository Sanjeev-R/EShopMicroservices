﻿namespace Catalog.API.Products.GetProduct
{
    public record GetProductQuery() : IQuery<GetProductResult>;

    public record GetProductResult(IEnumerable<Product> Products);
    public class GetProducsQueryHandler(IDocumentSession session) : IQueryHandler<GetProductQuery, GetProductResult>
    {


        public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductResult(products);
        }
    }
}
