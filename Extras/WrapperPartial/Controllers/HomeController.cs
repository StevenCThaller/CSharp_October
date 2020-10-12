using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WrapperPartial.Models;

namespace WrapperPartial.Controllers     //be sure to use your own project's namespace!
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
            IndexWrapper WMod = new IndexWrapper() 
            {
                MyStrings = new List<string>(){"Hello", "Darkness", "My", "Old", "Friend"}
            };

            
            return View("Index", WMod); //or whatever you want to return
        }

        [HttpPost("house/submit")]
        public IActionResult SubmitHouse(House FromForm)
        {
            return RedirectToAction("Index");
        }

        [HttpPost("trickortreater/submit")]
        public IActionResult SubmitTreater(TrickOrTreater FromForm)
        {
            return RedirectToAction("Index");
        }

        [HttpGet("trickortreater/edit")]
        public IActionResult EditTreater()
        {
            // fake logic for getting the thing we want to edit
            TrickOrTreater Billy = new TrickOrTreater()
            {
                Name="Billy",
                Costume="Woody",
                CandiesCollected=8
            };

            return View("EditTreater", Billy);
        }
    }
}