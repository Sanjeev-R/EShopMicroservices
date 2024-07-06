using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProduct
{
    public record GetProductResponse(IEnumerable<Product> Products);
    public class GetProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/products", async (ISender sender) =>
            {

                var result = await sender.Send(new GetProductQuery());
                var response = result.Adapt<GetProductResponse>();
                return Results.Ok(response);
            })
                .WithName("GetProducts")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get products")
                .WithDescription("Get products");
        }
    }
}
