using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCatalogV1.Data;
using MovieCatalogV1.UI.Models;

namespace MovieCatalogV1.UI.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Edit(int id)
        {
            var model = new MovieEditVM();

            var movieRepo = new MovieRepository();
            var genreRepo = new GenreRepository();
            var actorRepo = new ActorRepository();

            model.MovieToEdit = movieRepo.Get(id);
            model.CreateGenreList(genreRepo.GetAll());
            model.CreateActorsNotInMovieList(actorRepo.GetActorsNotInMovie(id));
            model.ActorsInMovie = actorRepo.GetActorsInMovie(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MovieEditVM model)
        {
            var movieRepo = new MovieRepository();
            movieRepo.Update(model.MovieToEdit);

            return RedirectToAction("Edit", new {id = model.MovieToEdit.MovieID});
        }

        [HttpPost]
        public ActionResult DeleteActor(int ActorID, int MovieID)
        {
            var movieRepo = new MovieRepository();
            movieRepo.RemoveActor(ActorID, MovieID);

            return RedirectToAction("Edit", new { id = MovieID });
        }

        [HttpPost]
        public ActionResult AddActors(MovieEditVM model)
        {
            var movieRepo = new MovieRepository();
            movieRepo.AddActors(model.SelectedActors, model.MovieToEdit.MovieID);

            return RedirectToAction("Edit", new { id = model.MovieToEdit.MovieID });
        }
    }
}