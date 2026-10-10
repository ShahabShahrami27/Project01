using AspNetMvcMonolithic.ApplicationServices.Dtos;

namespace AspNetMvcMonolithic.ApplicationServices.Contracts
{
    public interface IPersonApplicationService
    {
        Task<List<GetPersonDto>> GetAllPerson(); 
        Task<GetPersonDto> GetById(int id);
        Task Post(PostPersonDto postPersonDto);
        Task Delete(DeletePersonDto deletePersonDto);
        Task Edit(EditPersonDto editPersonDto);
    }
}
