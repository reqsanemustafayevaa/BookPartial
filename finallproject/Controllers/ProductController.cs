using finallproject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace finallproject.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       // public IActionResult SetSession(string name)
       // {
       //     HttpContext.Session.SetString("username", name);
       //     return Content("added to session");
       // }
       // public IActionResult GetSession()
       // {
       //    string name= HttpContext.Session.GetString("username");
       //     return Content(name);
       // }
       //public IActionResult RemoveSession()
       // {
       //     HttpContext.Session.Remove("username");
       //     return RedirectToAction("GetSession");
       // }
       // public IActionResult SetCookie(int id)
       // {
       //     List<int>ids = new List<int>(); 
       //     string idstr = HttpContext.Request.Cookies["UserId"];   
       //     if(idstr is not null)
       //     {
       //         ids=JsonConvert.DeserializeObject<List<int>>(idstr);
       //     }
       //     ids.Add(id);
            
       //      idstr=JsonConvert.SerializeObject(ids);
       //     HttpContext.Response.Cookies.Append("UserId", idstr);
       //     return Content("added to cookie");
       // }
       // public IActionResult GetCookie()
       // {
       //     List<int> ids = new List<int>();
       //     string idstr=HttpContext.Request.Cookies["UserId"];
       //     if(idstr is not null)
       //     {
       //         ids = JsonConvert.DeserializeObject<List<int>>(idstr);
       //     }
            
       //     return Json(ids);
       // }

        public IActionResult AddToBasket(int bookId)
        {
            List<BascetItemViewModel>bascetItemList = new List<BascetItemViewModel>();
            string Basketitemliststr = HttpContext.Request.Cookies["BasketItems"];
            if (Basketitemliststr != null)
            {
                bascetItemList = JsonConvert.DeserializeObject<List<BascetItemViewModel>>(Basketitemliststr);
                BascetItemViewModel bascetItem = new BascetItemViewModel()
                {
                    BookId = bookId,
                    Count = 1,
                };
                bascetItemList.Add(bascetItem);
            }
            else
            {
                BascetItemViewModel bascetItem = new BascetItemViewModel()
                {
                    BookId = bookId,
                    Count = 1,
                };
                bascetItemList.Add(bascetItem);
            }



            Basketitemliststr = JsonConvert.SerializeObject(bascetItemList);
            HttpContext.Response.Cookies.Append("BasketItems", Basketitemliststr);
            return RedirectToAction("index","home");
        }
        public IActionResult GetBascetItems()
        {
            List<BascetItemViewModel> basketItemList = new List<BascetItemViewModel>();
            string Basketitemliststr = HttpContext.Request.Cookies["basketItems"];


           if(Basketitemliststr != null)
            {
                basketItemList = JsonConvert.DeserializeObject<List<BascetItemViewModel>>(Basketitemliststr);

            }
           return Json(basketItemList);
        }
    }
}
