using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCatalogV1.Data;

namespace MovieCatalogV1.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var repo = new MovieRepository();

            var allMovies = repo.GetMovieList();

            return View(allMovies);
        }
    }
}