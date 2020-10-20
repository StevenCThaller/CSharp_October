using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AJAXItUp.Extensions;
using AJAXItUp.Models;

namespace AJAXItUp.Controllers     //be sure to use your own project's namespace!
{
    public class HomeController : Controller   
    {
        private Dachi SessionCheck()
        {
            Dachi MyDachi = HttpContext.Session.GetObjectFromJson<Dachi>("MyDachi");
            if(MyDachi == null)
            {
                MyDachi = new Dachi();
                HttpContext.Session.SetObjectAsJson("MyDachi", MyDachi);
            }
            return MyDachi;
        }


        //for each route this controller is to handle:
        [HttpGet("")]     //Http Method and the route
        public IActionResult Index() //When in doubt, use IActionResult
        {
            return View("Index"); //or whatever you want to return
        }

        [HttpGet("dachi/retrieve")]
        public JsonResult RetrieveDachi()
        {
            Dachi MyDachi = SessionCheck();
            return Json(MyDachi);
        }

        [HttpPost("feed")]
        public JsonResult FeedDachi()
        {
            Dachi MyDachi = SessionCheck();
            MyDachi.Feed();
            HttpContext.Session.SetObjectAsJson("MyDachi", MyDachi);
            return Json(MyDachi);
        }

        [HttpPost("play")]
        public JsonResult PlayDachi()
        {
            Dachi MyDachi = SessionCheck();
            MyDachi.Play();
            HttpContext.Session.SetObjectAsJson("MyDachi", MyDachi);
            return Json(MyDachi);
        }
        [HttpPost("work")]
        public JsonResult WorkDachi()
        {
            Dachi MyDachi = SessionCheck();
            MyDachi.Work();
            HttpContext.Session.SetObjectAsJson("MyDachi", MyDachi);
            return Json(MyDachi);
        }
        [HttpPost("sleep")]
        public JsonResult SleepDachi()
        {
            Dachi MyDachi = SessionCheck();
            MyDachi.Sleep();
            HttpContext.Session.SetObjectAsJson("MyDachi", MyDachi);
            return Json(MyDachi);
        }
        
        [HttpPost("reset")]
        public JsonResult ResetDachi()
        {
            HttpContext.Session.Clear();
            Dachi MyDachi = SessionCheck();
            return Json(MyDachi);
        }
    }
}