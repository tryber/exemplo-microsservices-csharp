namespace Catalog.Repository;
using Catalog.Models;

public class ProductRepository : IProductRepository
{
    private static List<Product> _products = new()
    {
        new()
        {
            Id = 1,
            Name = "Pegasus 39",
            Brand = "Nike",
            Price = 119.99M
        },
        new()
        {
            Id = 2,
            Name = "Vaporfly",
            Brand = "Nike",
            Price = 229.99M
        },
        new()
        {
            Id = 3,
            Name = "Ride 15",
            Brand = "Saucony",
            Price = 119.99M
        }
    };

    public List<Product> GetProducts() => _products;

    public bool DeleteProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product is not null)
        {
            return _products.Remove(product);
        }

        return false;
    }
}