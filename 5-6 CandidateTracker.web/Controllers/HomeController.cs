using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _5_6_CandidateTracker.web.Models;
using _5_6_CandidateTracker.data;
using Microsoft.Extensions.Configuration;

namespace _5_6_CandidateTracker.web.Controllers
{
    public class HomeController : Controller
    {
        private string _connString;
        public HomeController(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("ConStr");
        }
       
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCandidate(Candidate candidate)
        {
            CandidateRepository rep = new CandidateRepository(_connString);
            rep.AddCandidate(candidate);
            return Redirect("/home/viewpending");
        }

        public IActionResult ViewPending()
        {
            CandidateRepository rep = new CandidateRepository(_connString);
            IEnumerable<Candidate> candidates = rep.GetPendingCandidates();
            return View(candidates);
        }

        [HttpPost]
        public IActionResult ChangeStatus(bool confirm, int id)
        {
            CandidateRepository rep = new CandidateRepository(_connString);
            rep.ConfirmCandidate(id, confirm);
            var counts = new 
            {
                Pending = rep.GetPendingCandidates().Count(),
                Confirmed = rep.GetConfirmedCandidates().Count(),
                Declined = rep.GetDeclinedCandidates().Count()
            };
            return Json(counts);
        }

        public IActionResult ViewCandidate(int id)
        {
            CandidateRepository rep = new CandidateRepository(_connString);
            Candidate candidate = rep.GetCandidate(id);
            return View(candidate);
        }

        public IActionResult ViewConfirmed()
        {
            CandidateRepository rep = new CandidateRepository(_connString);
            IEnumerable<Candidate> candidates = rep.GetConfirmedCandidates();
            return View(candidates);
        }
        
        public IActionResult ViewDeclined()
        {
            CandidateRepository rep = new CandidateRepository(_connString);
            IEnumerable<Candidate> candidates = rep.GetDeclinedCandidates();
            return View(candidates);
        }

    }
}
