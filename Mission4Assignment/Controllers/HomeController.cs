using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission4Assignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Underscore to indicate that it's a private variable
        private MovieEntryContext _blahContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieEntryContext randomName)
        {
            _logger = logger;
            _blahContext = randomName;
        }

        public IActionResult Index()
        {
            var entries = _blahContext.Responses.OrderBy(x => x.Year).ToList();
            return View(entries);
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieEntry()
        {
            ViewBag.Categories = _blahContext.Categories.ToList(); //ViewBag is automatically passed around, so we don't have to send it to the view


            return View();
        }

        [HttpPost]
        public IActionResult MovieEntry(MovieEntry en)
        { //Need the below so that it will save all the changes to the database. I wanted to display the database, but the TAs said it was too far ahead
            if (ModelState.IsValid)
            {
                _blahContext.Add(en);
                _blahContext.SaveChanges();
                return View("EntryCon", en);
            }
            else
            {
                return View(en);
            }
            
        }
        [HttpGet]
        public IActionResult Edit(int MovieId) //Has to match the name of the thing we're passing through the route so it knows what to grab
        {
            ViewBag.Majors = _blahContext.Categories.ToList();

            var entry = _blahContext.Responses.Single(x => x.MovieId == MovieId);

            return View("MovieEntry", entry);

        }
        [HttpPost]
        public IActionResult Edit(MovieEntry blah) //Doesn't matter what it's called
        {

            _blahContext.Update(blah);
            _blahContext.SaveChanges();

            return RedirectToAction("Index"); //Now going up to the waitlist action, and running through that code
        }
    }
}
