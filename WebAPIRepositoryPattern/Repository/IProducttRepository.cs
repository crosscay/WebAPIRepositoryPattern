using WebAPIRepositoryPattern.Models;
using WebAPIRepositoryPattern.Paging;

namespace WebAPIRepositoryPattern.Repository
{
    public interface IProducttRepository:IRepositoryBase<Product>
    {
        Task<List<Product>> GetProductss();
        Task<Product> GetProductt(int id);
        Task<Product> FindProductt(int id);
        Task CreateProductt(Product product);
        Task UpdateProductt(Product product, int id);
        Task DeleteProductt(Product product, int id);
    }
}
