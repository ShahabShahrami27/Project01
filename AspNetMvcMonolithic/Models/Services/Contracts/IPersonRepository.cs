using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;

namespace AspNetMvcMonolithic.Models.Services.Contracts
{
    public interface IPersonRepository
    {
        Task<List<Person>> SelectAll();
        Task<Person> SelectById(int id);
        Task Insert(Person person);
        Task Delete(Person person);
        Task Update(Person person);
    }
}
