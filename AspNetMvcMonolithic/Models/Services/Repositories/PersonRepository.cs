using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;
using AspNetMvcMonolithic.Models.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcMonolithic.Models.Services.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ProjectDbContext _applicationDbContext;

        #region [- Ctor -]
        public PersonRepository(ProjectDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        #endregion

        #region [- SelectAll() -]
        public async Task<List<Person>> SelectAll()
        {
            try
            {
                return await _applicationDbContext.Person.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region [- SelectById() -]
        public async Task<Person> SelectById(int id)
        {
            try
            {
                return await _applicationDbContext.Person
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region [- Insert() -]
        public async Task Insert(Person person)
        {
            try
            {
                _applicationDbContext.Add(person);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region [- Delete() -]
        public async Task Delete(Person person)
        {
            try
            {
                _applicationDbContext.Remove(person);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region [- Update() -]
        public async Task Update(Person person)
        {
            try
            {
                _applicationDbContext.Update(person);

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