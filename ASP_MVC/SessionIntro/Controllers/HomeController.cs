using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // import session
using SessionIntro.Models;

namespace SessionIntro.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpPost("submit")]
        public IActionResult FormSubmit(User FromForm)
        {
            if(ModelState.IsValid)
            {
                HttpContext.Session.SetString("FirstName",FromForm.FirstName);
                HttpContext.Session.SetString("LastName", FromForm.LastName);
                HttpContext.Session.SetInt32("Age", (int)FromForm.Age);
                return RedirectToAction("DisplayData");
            }
            else 
            {
                return Index();
            }
        }

        [HttpGet("display")]
        public IActionResult DisplayData()
        {
            int? AgeFromSession = HttpContext.Session.GetInt32("Age");
            if(AgeFromSession == null)
            {
                return RedirectToAction("Index");
            }


            User ToDisplay = new User();
            ToDisplay.FirstName = HttpContext.Session.GetString("FirstName");
            ToDisplay.LastName = HttpContext.Session.GetString("LastName");
            ToDisplay.Age = AgeFromSession;
            return View("DisplayData", ToDisplay);
        }

        [HttpGet("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}