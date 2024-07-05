namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        string Price);

    public class CreateProductEndpoint
    {

    }
}
