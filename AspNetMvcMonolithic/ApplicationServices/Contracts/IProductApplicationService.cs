using AspNetMvcMonolithic.ApplicationServices.Dtos;

namespace AspNetMvcMonolithic.ApplicationServices.Contracts
{
    public interface IProductApplicationService
    {
        Task<List<GetProductDto>> GetAllProduct();
        Task<GetProductDto> GetById(int id);
        Task Post(PostProductDto postProductDto);
        Task Delete(DeleteProductDto deleteProductDto);
        Task Edit(EditProductDto editProductDto);
    }
}
