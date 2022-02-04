using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        
        private MovieApplication blahContext { get; set; }

        public HomeController(MovieApplication someName)
        {
            blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcast()
        {
            return View("MyPodcast");
        }
        [HttpGet]
        public IActionResult EnterAMovie()
        {
            ViewBag.Categories = blahContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult EnterAMovie(MovieResponse mr)
        {
            if (ModelState.IsValid)
            {
                blahContext.Add(mr);
                blahContext.SaveChanges();
                return View("Confirmation", mr);
            }
            else
            {
                return View(mr);
            }

        }
        [HttpGet]
        public IActionResult ViewMovies()
        {
            var applications = blahContext.Responses
                .Include(x => x.Category)
                .ToList();
            return View(applications);
        }
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = blahContext.Categories.ToList();
            var application = blahContext.Responses.Single(x=> x.MovieID == movieid);
            return View("EnterAMovie",application);
        }
        [HttpPost]
        public IActionResult Edit(MovieResponse mr)
        {
            blahContext.Update(mr);
            blahContext.SaveChanges();
            return RedirectToAction("ViewMovies");
        }
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var application = blahContext.Responses.Single(x => x.MovieID == movieid);
            return View(application);
        }
        [HttpPost]
        public IActionResult Delete(MovieResponse mr)
        {
            blahContext.Responses.Remove(mr);
            blahContext.SaveChanges();

            return RedirectToAction("ViewMovies");
        }
    }
}
