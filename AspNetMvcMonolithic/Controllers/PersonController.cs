using AspNetMvcMonolithic.ApplicationServices;
using AspNetMvcMonolithic.ApplicationServices.Contracts;
using AspNetMvcMonolithic.ApplicationServices.Dtos;
using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcMonolithic.Controllers
{
    public class PersonController : Controller
    {
        #region [- Ctor -]
        private readonly IPersonApplicationService _personApplicationService;
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

            var editPersonDto = new EditPersonDto()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };

            return View(editPersonDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditPersonDto editPersonDto)
        {
            if (ModelState.IsValid)
            {
                await _personApplicationService.Edit(editPersonDto);

                return RedirectToAction(nameof(Index));
            }

            return View(editPersonDto);
        }

        #endregion
        #region [- Details() -]
        public async Task<IActionResult> Details(int id)
        {
            var person = await _personApplicationService.GetById(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        } 
        #endregion
    }
}