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
            ViewBag.Categories = _blahContext.Categories.ToList(); //ViewBag is automatically passed around, so we don't have to send it to the view

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
        [HttpGet] //This lets us edit the movie entry, and then save the changes with the Post Edit method below
        public IActionResult Edit(int MovieId) //MovieId has to match the name of the thing we're passing through the route so it knows what to grab
        {
            ViewBag.Categories = _blahContext.Categories.ToList();

            var entry = _blahContext.Responses.Single(x => x.MovieId == MovieId);

            return View("MovieEntry", entry);

        }
        [HttpPost]
        public IActionResult Edit(MovieEntry blah) //This saves any edited changes from above
        {

            _blahContext.Update(blah);
            _blahContext.SaveChanges();

            return RedirectToAction("Index"); //Now going up to the waitlist action, and running through that code
        }
        [HttpGet]
        public IActionResult Delete (int MovieId) //Pulls up the movie record from above
        {
            var entry = _blahContext.Responses.Single(x => x.MovieId == MovieId);
            return View(entry);

        }
        [HttpPost]
        public IActionResult Delete (MovieEntry mv) //Actually deletes and saves the changes from above
        {
            _blahContext.Responses.Remove(mv);
            _blahContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
