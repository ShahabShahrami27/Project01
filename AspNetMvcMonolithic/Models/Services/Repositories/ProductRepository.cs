using AspNetMvcMonolithic.Models.DomainModels.ProductAggregates;
using AspNetMvcMonolithic.Models.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcMonolithic.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectDbContext _applicationDbContext;

        #region [- Ctor -]
        public ProductRepository(ProjectDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #endregion

        #region [- SelectAll() -]
        public async Task<List<Product>> SelectAll()
        {
            try
            {
                return await _applicationDbContext.Product.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region [- SelectById() -]
        public async Task<Product> SelectById(int id)
        {
            try
            {
                return await _applicationDbContext.Product
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region [- Insert() -]
        public async Task Insert(Product product)
        {
            try
            {
                _applicationDbContext.Add(product);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region [- Delete() -]
        public async Task Delete(Product product)
        {
            try
            {
                _applicationDbContext.Remove(product);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region [- Update() -]
        public async Task Update(Product product)
        {

            try
            {
                _applicationDbContext.Update(product);

                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}