namespace Catalog.API.Products.GetProductById
{
    public record GetProductByCategoryResponse(IEnumerable<Product> Product);
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/product/category/{category}", async (string category, ISender send) =>
            {
                var result = await send.Send(new GetProductByCategoryQuery(category));
                var response = result.Adapt<GetProductByCategoryResponse>();
                return Results.Ok(response);
            })
        .WithName("GetProductByCat")
        .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Cat")
        .WithDescription("Get Product By Cat");
        }
    }
}
