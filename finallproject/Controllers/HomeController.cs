using finallproject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.core.Models;
using project.data.DAL;

namespace finallproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel()
            {
                Books = _context.Books.ToList(),
                Sliders = _context.Sliders.ToList(),
                FeaturedBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages).Where(x => x.IsFeatured == true).ToList(),
                NewBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages).Where(x => x.IsNew == true).ToList(),
                BestSellerBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages).Where(x => x.IsBestSeller == true).ToList(),
            };
            return View(model);
        }
    }
}