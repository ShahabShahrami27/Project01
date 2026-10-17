
using AspNetMvcMonolithic.ApplicationServices;
using AspNetMvcMonolithic.ApplicationServices.Contracts;
using AspNetMvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using AspNetMvcMonolithic.Models;
using AspNetMvcMonolithic.Models.DomainModels.ProductAggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductController : Controller
{
    #region [- ctor -]
    private readonly IProductApplicationService _productApplicationService;
    public ProductController(IProductApplicationService productApplicationService)
    {
        _productApplicationService = productApplicationService;
    }
    #endregion
    #region [- Index -]
    public async Task<IActionResult> Index()
    {
        var result = await _productApplicationService.GetAllProduct();
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
    public async Task<IActionResult> Create(PostProductDto postProductDto)
    {
        if (ModelState.IsValid)
        {
            await _productApplicationService.Post(postProductDto);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View(postProductDto);
        }
    }
    #endregion
    #region [- Delete() -]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteProductDto = new DeleteProductDto()
        {
            Id = id
        };

        await _productApplicationService.Delete(deleteProductDto);

        return RedirectToAction(nameof(Index));
    }
    #endregion
    #region [- Edit() -]
    public async Task<IActionResult> Edit(int id)
    {
        var products = await _productApplicationService.GetAllProduct();

        var product = products.FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        var putProductDto = new PutProductDto()
        {
            Id = product.Id,
            Title = product.Title,
            UnitPrice = product.UnitPrice
        };

        return View(putProductDto);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(PutProductDto putProductDto)
    {
        if (ModelState.IsValid)
        {
            await _productApplicationService.Put(putProductDto);

            return RedirectToAction(nameof(Index));
        }

        return View(putProductDto);
    }
    #endregion
    #region [- Details() -]
    public async Task<IActionResult> Details(int id)
    {
        var product = await _productApplicationService.GetById(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    } 
    #endregion
}