using AspNetMvcMonolithic.Models.DomainModels.ProductAggregates;

namespace AspNetMvcMonolithic.Models.Services.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> SelectAll();
        Task<Product> SelectById(int id);
        Task Insert(Product product);
        Task Delete(Product product);
        Task Update(Product product);
    }
}
