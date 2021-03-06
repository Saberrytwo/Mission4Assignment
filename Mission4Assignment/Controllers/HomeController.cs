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
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieEntry()
        {

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
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
