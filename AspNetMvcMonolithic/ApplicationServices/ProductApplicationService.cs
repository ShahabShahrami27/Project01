using AspNetMvcMonolithic.ApplicationServices.Contracts;
using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using AspNetMvcMonolithic.Models.DomainModels.ProductAggregates;
using AspNetMvcMonolithic.Models.Services.Contracts;
using AspNetMvcMonolithic.Models.Services.Repositories;

namespace AspNetMvcMonolithic.ApplicationServices
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductRepository _productRepository;

        #region [- Ctor -]
        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region [- GetAllProduct() -]
        public async Task<List<GetProductDto>> GetAllProduct()
        {
            var Products = await _productRepository.SelectAll();

            var getProductDtos = new List<GetProductDto>();
            foreach (var item in Products)
            {
                var getProductDto = new GetProductDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    UnitPrice = item.UnitPrice,
                };
                getProductDtos.Add(getProductDto);
            }
            return getProductDtos;

        }
        #endregion

        #region [- Post() -]
        public async Task Post(PostProductDto postProductDto)
        {
            var product = new Models.DomainModels.ProductAggregates.Product()
            {
                Title = postProductDto.Title,
                UnitPrice = postProductDto.UnitPrice,
            };
            await _productRepository.Insert(product);
        }
        #endregion

        #region [- Delete() -]
        public async Task Delete(DeleteProductDto deleteProductDto)
        {
            var product = new Models.DomainModels.ProductAggregates.Product()
            {
                Id = deleteProductDto.Id
            };

            await _productRepository.Delete(product);
        }
        #endregion

        #region [- Put() -]
        public async Task Put(PutProductDto putProductDto)
        {

            var product = new Models.DomainModels.ProductAggregates.Product()
            {
                Id = putProductDto.Id,
                Title = putProductDto.Title,
                UnitPrice = putProductDto.UnitPrice
            };

            await _productRepository.Update(product);
        }
        #endregion

        #region [- GetById() -]
        public async Task<GetProductDto> GetById(GetProductDto getProductDto)
        {

            var product = await _productRepository.SelectById(getProductDto.Id);

            if (product == null)
            {
                return null;
            }

            var result = new GetProductDto()
            {
                Id = product.Id,
                Title = product.Title,
                UnitPrice = product.UnitPrice
            };

            return result;
        } 
        #endregion

    }
}