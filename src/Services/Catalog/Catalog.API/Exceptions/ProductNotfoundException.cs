namespace Catalog.API.Exceptions
{
    internal class ProductNotfoundException : Exception
    {
        public ProductNotfoundException(string message) : base(message)
        {
        }
    }
}