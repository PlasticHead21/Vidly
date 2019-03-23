using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewsModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var movies = _context.Movie.ToList();
            return View(movies);
        }

        public ActionResult Details(int? id)
        {
            var movie = _context.Movie.Include(m => m.Genre).SingleOrDefault(m => m.ID == id);
            if (movie is null) return HttpNotFound();
            return View(movie);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres,

            };
            return View();
        }
    }
}