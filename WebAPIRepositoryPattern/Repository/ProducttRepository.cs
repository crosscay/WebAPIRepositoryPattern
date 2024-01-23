using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebAPIRepositoryPattern.Models;
using WebAPIRepositoryPattern.Paging;

namespace WebAPIRepositoryPattern.Repository
{
    public class ProducttRepository : RepositoryBase<Product>, IProducttRepository
    {
        public ProducttRepository(ApplicationDBContext applicationDBContext):base(applicationDBContext)
        {

        }

        public async Task CreateProductt(Product product)
        {
            await AddAsync(product);
        }

        public async Task DeleteProductt(Product product, int id)
        {
            await DeleteAsync(product, id);
        }

        public async Task<Product> FindProductt(int id)
        {
            List<Product> query = await GetWhereAsync(e => e.Id == id);
            Product? resultado = query.FirstOrDefault();

            return resultado;
        }

        public async Task<List<Product>> GetProductss()
        {
            IEnumerable<Product> allQuery = await GetAllAsync();
            List<Product> resultado = allQuery.ToList();

            return resultado;
        }

        public async Task<Product> GetProductt(int id)
        {
            var query = FindbyCondition(e => e.Id == id);

            Product? resp = await query.FirstOrDefaultAsync();

            if (resp != null)
            {
                return resp;
            }

            return new Product();
        }

        public async Task UpdateProductt(Product product, int id)
        {
            await UpdateAsync(product, id);
        }
    }
}
