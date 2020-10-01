using Microsoft.AspNetCore.Mvc;

namespace ASPIntro.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet("name")]
        public ViewResult NameRoute()
        {
            return View("NameRoute");
        }

        [HttpGet("name/{MyName}")]
        public string DisplayParameterName(string MyName)
        {
            return $"According to the url, you are {MyName}";
        }
    }
}