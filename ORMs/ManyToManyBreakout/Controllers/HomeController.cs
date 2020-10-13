using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ManyToManyBreakout.Models;

namespace ManyToManyBreakout.Controllers     //be sure to use your own project's namespace!
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
                AllColors = _context.Colors
                    .Include(c => c.UsersWhoLike)
                    .ThenInclude(u => u.User)
                    .ToList(),
                AllUsers = _context.Users
                    .Include(u => u.ColorsLiked)
                    .ThenInclude(c => c.Color)
                    .ToList()
            };
            ViewBag.AllColors = WMod.AllColors;
            ViewBag.AllUsers = WMod.AllUsers;
            return View("Index", WMod); //or whatever you want to return
        }

        [HttpPost("user")]
        public IActionResult CreateUser(User FromForm)
        {
            _context.Add(FromForm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost("color")]
        public IActionResult CreateColor(Color FromForm)
        {
            _context.Add(FromForm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost("like")]
        public IActionResult LikeColor(UserLikesColor FromForm)
        {
            // If user id was coming from session and not the form
            // I would attach that here prior to adding it to the database
            _context.Add(FromForm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("delete/{UserId}/{ColorId}")]
        public IActionResult DeleteLike(int UserId, int ColorId)
        {
            // Pull the association object from the database that indicates the
            // many to many relationship between a given user and a given color
            UserLikesColor ToRemove = _context.UsersLikeColors.FirstOrDefault(ulc => ulc.UserId == UserId && ulc.ColorId == ColorId);
            // Remove it from the database
            _context.Remove(ToRemove);
            // And save our changes
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
