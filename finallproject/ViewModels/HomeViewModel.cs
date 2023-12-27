using project.core.Models;

namespace finallproject.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider>Sliders { get; set; }
        public List<Book> Books { get; set; }
        public List<Book> FeaturedBooks { get; set; }
        public List<Book> NewBooks { get; set; }
        public List<Book> BestSellerBooks { get; set; }
    }
}
