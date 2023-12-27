using Microsoft.AspNetCore.Mvc;
using project.business.Exceptions;
using project.business.Services.Interfaces;
using project.core.Models;

namespace finallproject.Areas.manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {

        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public async Task<IActionResult> Index()
        {
            var sliders = await _sliderService.GetAllAsync();
            return View(sliders);
        }
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return NotFound();
            try
            {
                await _sliderService.CreatAsync(slider);

            }
            catch (InvalidContentTypeExceptions ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidImageFileException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (Exception) { }

            return RedirectToAction("index");

        }
        public async Task<IActionResult> Update(int id)
        {
            if (id == null) return View();
            Slider wantedSlider = await _sliderService.GetAsync(id);

            if (wantedSlider == null) return NotFound();

            return View(wantedSlider);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                await _sliderService.UpdateAsync(slider);
            }
            catch (InvalidContentTypeExceptions ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (InvalidImageFileException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (NullReferenceException) { }



            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sliderService.DeleteAsync(id);

            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("index");

        }
        
       
       

    }
}
