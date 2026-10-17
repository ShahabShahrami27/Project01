using AspNetMvcMonolithic.ApplicationServices.Dtos.PersonDtos;
using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;

namespace AspNetMvcMonolithic.ApplicationServices.Contracts
{
    public interface IPersonApplicationService
    {
        Task<List<GetPersonDto>> GetAllPerson(); 
        Task<GetPersonDto> GetById(int id);
        Task Post(PostPersonDto postPersonDto);
        Task Delete(DeletePersonDto deletePersonDto);
        Task Put(PutPersonDto putPersonDto);
    }
}