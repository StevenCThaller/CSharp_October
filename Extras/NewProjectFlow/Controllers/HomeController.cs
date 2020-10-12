using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NewProjectFlow.Models;

namespace YourNamespace.Controllers     //be sure to use your own project's namespace!
{
    public class HomeController : Controller   
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        //for each route this controller is to handle:
        [HttpGet("")]     //Http Method and the route
        public IActionResult Index() //When in doubt, use IActionResult
        {
            return View("Index"); //or whatever you want to return
        }

        // [HttpGet("action/{UserId}/{OtherId}/{SomethingElse}")]
        // public IActionResult MyAction(int UserId){}
    }
}