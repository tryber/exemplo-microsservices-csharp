using Catalog.Models;

namespace Catalog.Repository;

public interface IProductRepository
{
    public bool DeleteProduct(int id);
    public List<Product> GetProducts();

}