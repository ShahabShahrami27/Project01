using AspNetMvcMonolithic.ApplicationServices;
using AspNetMvcMonolithic.ApplicationServices.Contracts;
using AspNetMvcMonolithic.ApplicationServices.Dtos.PersonDtos;
using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcMonolithic.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonApplicationService _personApplicationService;

        #region [- Ctor -]
        public PersonController(IPersonApplicationService personApplicationService)
        {
            _personApplicationService = personApplicationService;
        }
        #endregion

        #region [- Index() -]
        public async Task<IActionResult> Index()
        {
            var result = await _personApplicationService.GetAllPerson();
            return View(result);
        }

        #endregion

        #region [- Create() -]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostPersonDto postPersonDto)
        {
            if (ModelState.IsValid)
            {
                await _personApplicationService.Post(postPersonDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(postPersonDto);
            }
        }

        #endregion

        #region [- Delete() -]
        public async Task<IActionResult> Delete(int id)
        {
            var deletePersonDto = new DeletePersonDto()
            {
                Id = id
            };

            await _personApplicationService.Delete(deletePersonDto);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region [- Edit() -]
        public async Task<IActionResult> Edit(int id)
        {
            var persons = await _personApplicationService.GetAllPerson();

            var person = persons.FirstOrDefault(x => x.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            var putPersonDto = new PutPersonDto()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };

            return View(putPersonDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PutPersonDto putPersonDto)
        {
            if (ModelState.IsValid)
            {
                await _personApplicationService.Put(putPersonDto);

                return RedirectToAction(nameof(Index));
            }

            return View(putPersonDto);
        }

        #endregion

        #region [- Details() -]
        public async Task<IActionResult> Details(GetPersonDto getPersonDto)
        {
            var person = await _personApplicationService.GetById(getPersonDto);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        } 
        #endregion

    }
}