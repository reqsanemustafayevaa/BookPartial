using Microsoft.AspNetCore.Mvc;
using project.business.Exceptions;
using project.business.Services.Interfaces;
using project.core.Models;

namespace finallproject.Areas.manage.Controllers
{
    [Area("manage")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        public async Task<IActionResult> Index()
        {
            var tags=await _tagService.GetAllAsync();
            return View(tags);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (tag == null)
            {
                return NotFound();
            }
            try
            {
               await _tagService.CreateAsync(tag);
            }
            catch(InvalidNullReferenceException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            return RedirectToAction("Index");   
        }
        public async Task<IActionResult> Update(int id)
        {
            var existtag=await _tagService.GetByIdAsync(id);
            if (existtag == null)
            {
                throw new NullReferenceException();
            }
            
            
            return View(existtag);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Tag tag)
        {
            
            if(!ModelState.IsValid)
            {
                return NotFound();
            }
            try
            {
                await _tagService.UpdateAsync(tag);
            }
            catch(InvalidNullReferenceException ex)
            {
                ModelState.AddModelError(ex.PropertyName,ex.Message);
                return View();
            }
            return RedirectToAction("index");

        }
        public async Task< IActionResult> Delete(int id)
        {
            try
            {
                await _tagService.DeleteAsync(id);
            }
            catch(InvalidNullReferenceException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            return RedirectToAction("index");
        }
    }
}
