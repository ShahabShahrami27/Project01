using AspNetMvcMonolithic.ApplicationServices.Contracts;
using AspNetMvcMonolithic.ApplicationServices.Dtos;
using AspNetMvcMonolithic.Models.Services.Contracts;

namespace AspNetMvcMonolithic.ApplicationServices
{
    public class PersonApplicationService : IPersonApplicationService
    {
        #region [- Ctor -]
        private readonly IPersonRepository _personRepository;
        public PersonApplicationService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion
        #region [- Post() -]
        public async Task Post(PostPersonDto postPersonDto)
        {
            var person = new Models.DomainModels.PersonAggregates.Person()
            {
                FirstName = postPersonDto.FirstName,
                LastName = postPersonDto.LastName
            };
            await _personRepository.Insert(person);
        }

        #endregion
        #region [- GetAllPerson() -]
        public async Task<List<GetPersonDto>> GetAllPerson()
        {
            var persons = await _personRepository.SelectAll();

            var getPersonDtos = new List<GetPersonDto>();
            foreach (var item in persons)
            {
                var getPersonDto = new GetPersonDto()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                };
                getPersonDtos.Add(getPersonDto);
            }
            return getPersonDtos;
        }
        #endregion
        #region [- Delete() -]
        public async Task Delete(DeletePersonDto deletePersonDto)
        {
            var person = new Models.DomainModels.PersonAggregates.Person()
            {
                Id = deletePersonDto.Id
            };

            await _personRepository.Delete(person);
        }

        #endregion
        #region [- Edit() -]
        public async Task Edit(EditPersonDto editPersonDto)
        {
            var person = new Models.DomainModels.PersonAggregates.Person()
            {
                Id = editPersonDto.Id,
                FirstName = editPersonDto.FirstName,
                LastName = editPersonDto.LastName
            };

            await _personRepository.Update(person);
        }
        #endregion
        #region [- GetById() -]
        public async Task<GetPersonDto> GetById(int id)
        {
            var person = await _personRepository.SelectById(id);

            if (person == null)
            {
                return null;
            }

            var getPersonDto = new GetPersonDto()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };

            return getPersonDto;
        } 
        #endregion
    }
}

