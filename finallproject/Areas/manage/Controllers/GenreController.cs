using Microsoft.AspNetCore.Mvc;
using project.business.Exceptions;
using project.business.Services.Interfaces;
using project.core.Models;

namespace finallproject.Areas.manage.Controllers
{
    [Area("manage")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public async Task<IActionResult> Index()
        {
            var genres=await _genreService.GetAllAsync();
            return View(genres);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre);
            }
            try
            {
                await _genreService.CreateAsync(genre);
            }
            catch (InvalidNullReferenceException ex)
            {
                ModelState.AddModelError(ex.PropertyName,ex.Message);
                return View();

            }
            catch(Exception ex)
            {

            }
            return RedirectToAction("Index");

            
        }
        public async Task<IActionResult> Update(int id)
        {
            var entity=await _genreService.GetByIdAsync(id);
            if (entity == null)
            {
                return View();
            }
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Genre genre)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
               await _genreService.UpdateAsync(genre);
            }
            catch (InvalidNullReferenceException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            var existgenre=await _genreService.GetByIdAsync(id);
            if(existgenre == null)
            {
                return NotFound();
            }
            await _genreService.Delete(id);
            return RedirectToAction("index");
        }
    }
}
