using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EntityIntro.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EntityIntro.Controllers
{
    public class GhostController : Controller
    {
        private MyContext _context;

        public GhostController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("ghosts")]
        public IActionResult GhostDashboard()
        {
            List<Ghost> AllGhosts = _context.Ghosts
                .Include(g => g.GhostHasEvidence)
                .ThenInclude(ghe => ghe.Evidence)
                .ToList();

            return View("GhostDashboard", AllGhosts);
        }

        [HttpGet("addevidence/{GhostId}")]
        public IActionResult AddEvidenceToGhost(int GhostId)
        {
            ViewBag.Ghost = _context.Ghosts
                .Include(g => g.GhostHasEvidence)
                .ThenInclude(ghe => ghe.Evidence)
                .FirstOrDefault(g => g.GhostId == GhostId);

            ViewBag.Evidence = _context.Evidence
                .Include(e => e.GhostHasEvidence)
                .Where(e => !e.GhostHasEvidence.Any(ghe => ghe.GhostId == GhostId))
                .ToList();
            return View("AddEvidenceToGhost");
        }

        [HttpPost("submitevidence/{GhostId}")]
        public IActionResult SubmitEvidence(int GhostId, GhostHasEvidence GHE)
        {
            if(_context.GhostsHaveEvidence.Any(g => g.GhostId == GhostId && g.EvidenceId == GHE.EvidenceId))
            {
                return RedirectToAction("GhostDashboard");
            }
            GHE.GhostId = GhostId;
            _context.Add(GHE);
            _context.SaveChanges();
            return RedirectToAction("GhostDashboard");
        }

    }
}