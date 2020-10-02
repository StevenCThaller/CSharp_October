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
        public ViewResult DisplayParameterName(string MyName)
        {
            return View("DisplayParameterName");
        }

        [HttpGet("form")]
        public ViewResult MyForm()
        {
            return View("MyForm");
        }

        [HttpPost("formsubmit")]
        public ViewResult DisplayFormData(string name, int age)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            return View("DisplayFormData");
        }

        [HttpGet("gosomewhereelse")]
        public IActionResult GoElsewhere()
        {
            return Redirect("/somewhereelse"); // when returning a Redirect, we must pass in the URL we are redirecting to
            return RedirectToAction("Elsewhere"); // when returning a RedirectToAction, we pass in the METHOD name

            // If we are using RedirectToAction to redirect to a method whose url contains a route parameter
            // return RedirectToAction("MethodName", new { parameterName: parameterValue });
        }

        [HttpGet("somewhereelse")]
        public ViewResult Elsewhere()
        {
            return View("Elsewhere");
        }
    }
}