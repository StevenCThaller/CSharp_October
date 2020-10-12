using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            // Atlantic Soccer Conference
                // From the Teams side
                ViewBag.ASCTeams = _context.Teams
                    .Include(t => t.CurrLeague)
                    .Where(t => t.CurrLeague.Name == "Atlantic Soccer Conference");
                // From the League Side
                ViewBag.TeamsinASC = _context.Leagues
                    .Include(l => l.Teams)
                    .FirstOrDefault(l => l.Name == "Atlantic Soccer Conference");
            // Current players on the Boston Penguins
                // From the player side
                ViewBag.Penguins = _context.Players
                    .Include(p => p.CurrentTeam)
                    .Where(p => p.CurrentTeam.TeamName == "Penguins" && p.CurrentTeam.Location == "Boston");
                // From the team side
                ViewBag.PlayersOnPenguins = _context.Teams
                    .Include(t => t.CurrentPlayers)
                    .FirstOrDefault(t => t.TeamName == "Penguins" && t.Location == "Boston");
            // Current Players in the International Collegiate Baseball Conference
                // From the team
                ViewBag.TeamsInICBC = _context.Teams
                    .Include(t => t.CurrentPlayers)
                    .Include(t => t.CurrLeague)
                    .Where(t => t.CurrLeague.Name == "International Collegiate Baseball Conference");
                // From the players
                ViewBag.PlayersInICBC = _context.Players
                    .Include(p => p.CurrentTeam)
                    .ThenInclude(ct => ct.CurrLeague) // not necessarily indicative of a M2M relationship
                    .Where(p => p.CurrentTeam.CurrLeague.Name == "International Collegiate Baseball Conference");
                // Ok nvm I guess just use this?
                ViewBag.ICBCPlayers = _context.Players
                    .Include(p => p.CurrentTeam)
                    // .ThenInclude(ct => ct.CurrLeague) // OPTIONAL APPARENTLY
                    .Where(p => p.CurrentTeam.CurrLeague.Name == "International Collegiate Baseball Conference")
                    .ToList();
            // Current players in the American Conference of Amateur Football with last name "Lopez"
                // From the players
                ViewBag.Lopez = _context.Players
                    .Where(p => p.LastName == "Perez" && p.CurrentTeam.CurrLeague.Name == "International Collegiate Baseball Conference");
            // All football players
                ViewBag.Footyball = _context.Players
                    .Where(p => p.CurrentTeam.CurrLeague.Sport == "Football");
            // Teams with a Sophia
                ViewBag.SophiaTeams = _context.Teams
                    .Where(t => t.CurrentPlayers.Any(p => p.FirstName == "Sophia"));
                // Alternative: Query for all players and just use Select to return the list of teams only
                // ViewBag.SophiaTeams = _context.Players
                //     .Where(p => p.LastName == "Sophia" || p.FirstName == "Sophia")
                //     .Include(p => p.CurrentTeam)
                //     .Select(p => p.CurrentTeam)
                //     .ToList();
            // The same but leagues
                ViewBag.SophiaLeagues = _context.Leagues
                    .Where(l => l.Teams.Any(t => t.CurrentPlayers.Any(p => p.FirstName == "Sophia")));
            // last name "Flores" who DOESN'T (currently) play for the Washington Roughriders
                ViewBag.Flores = _context.Players
                    .Where(p => p.LastName == "Flores" && p.CurrentTeam.TeamName != "Roughriders" && p.CurrentTeam.Location != "Washington");
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}