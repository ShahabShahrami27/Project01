using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;

namespace AspNetMvcMonolithic.ApplicationServices.Contracts
{
    public interface IProductApplicationService
    {
        Task<List<GetProductDto>> GetAllProduct();
        Task<GetProductDto> GetById(int id);
        Task Post(PostProductDto postProductDto);
        Task Delete(DeleteProductDto deleteProductDto);
        Task Put(PutProductDto putProductDto);
    }
}
