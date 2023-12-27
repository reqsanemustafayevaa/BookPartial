using Microsoft.AspNetCore.Mvc;
using project.business.Services.Interfaces;
using project.core.Models;

namespace finallproject.Areas.manage.Controllers
{
    [Area("manage")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<IActionResult> Index()
        {
            var authors =await _authorService.GetAllAsync();
            return View(authors);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            await _authorService.CreateAsync(author);
            return RedirectToAction("index");


        }
        public async Task<IActionResult> Update(int id)
        {
            var existauthor = await _authorService.GetByIdAsync(id);
            if(existauthor == null)
            {
                throw new NullReferenceException();
            }

            return View(existauthor);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(Author author)
        {
            var existauthor = await _authorService.GetByIdAsync(author.Id);
            if (!ModelState.IsValid)
            {
                return View(existauthor);
            }
            
            await _authorService.UpdateAsync(author);
            return RedirectToAction("index");
            
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _authorService.Delete(id);
            }
            catch (NullReferenceException) { }
            return RedirectToAction("index");

        }
       

    }
}
