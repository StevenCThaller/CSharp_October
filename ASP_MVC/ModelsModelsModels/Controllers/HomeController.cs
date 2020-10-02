using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ModelsModelsModels.Models;

namespace ModelsModelsModels.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            string MyMessage = "Bacon ipsum dolor amet doner corned beef biltong, shankle ham hamburger chicken ham hock meatloaf porchetta kevin. Boudin burgdoggen t-bone pastrami spare ribs, swine shank turducken frankfurter hamburger. Chicken drumstick turkey pork leberkas bresaola tongue. Andouille hamburger meatball sirloin swine. Sirloin venison burgdoggen, ribeye drumstick salami pork shoulder frankfurter. Chuck pork cupim turducken pastrami short ribs biltong chicken, sausage buffalo meatloaf t-bone beef ribs. Drumstick bresaola meatball, pork loin kevin pig tri-tip chicken t-bone spare ribs shankle tail."; 
            return View("Index", MyMessage);
        }

        [HttpGet("numbers")]
        public IActionResult Numbers()
        {
            int[] Numbers = { 1,2,3,4,5 };
            return View("Numbers", Numbers);
        }

        [HttpGet("user")]
        public IActionResult OneUser()
        {
            User MyUser = new User()
            {
                FirstName = "Cody",
                LastName = "Thaller"
            };

            return View("OneUser", MyUser);
        }

        [HttpGet("users")]
        public IActionResult Users()
        {
            List<User> AllUsers = new List<User>();
            AllUsers.Add(new User(){FirstName = "Bill", LastName = "Gates", Email = "test@test.test"});
            AllUsers.Add(new User(){FirstName = "Steve", LastName = "Jobs", Email = "test@test.test"});
            AllUsers.Add(new User(){FirstName = "Steve", LastName = "Wozniak", Email = "test@test.test"});

            return View("Users", AllUsers);
        }

        [HttpGet("allthethings")]
        public IActionResult MultipleObjects()
        {
            List<User> AllUsers = new List<User>();
            AllUsers.Add(new User(){FirstName = "Bill", LastName = "Gates", Email = "test@test.test"});
            AllUsers.Add(new User(){FirstName = "Steve", LastName = "Jobs", Email = "test@test.test"});
            AllUsers.Add(new User(){FirstName = "Steve", LastName = "Wozniak", Email = "test@test.test"});

            MultipleObjectsWrapper WMod = new MultipleObjectsWrapper()
            {
                MyMessage = "Bacon ipsum dolor amet doner corned beef biltong, shankle ham hamburger chicken ham hock meatloaf porchetta kevin. Boudin burgdoggen t-bone pastrami spare ribs, swine shank turducken frankfurter hamburger. Chicken drumstick turkey pork leberkas bresaola tongue. Andouille hamburger meatball sirloin swine. Sirloin venison burgdoggen, ribeye drumstick salami pork shoulder frankfurter. Chuck pork cupim turducken pastrami short ribs biltong chicken, sausage buffalo meatloaf t-bone beef ribs. Drumstick bresaola meatball, pork loin kevin pig tri-tip chicken t-bone spare ribs shankle tail.",
                MyNumber = 24,
                MyUsers = AllUsers
            };
            return View("MultipleObjects", WMod);
        }

        [HttpGet("userform")]
        public IActionResult NewUser()
        {
            // make query to database
            // store data in viewbag and render it on the page
            return View("NewUser");
        }

        [HttpPost("submituser")]
        public IActionResult CreateUser(User FromForm)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("NewUser");
            }
            else 
            {
                return NewUser();
            }
        }
    }
}