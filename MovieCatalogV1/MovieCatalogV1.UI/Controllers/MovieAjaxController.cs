using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieCatalogV1.Data;
using MovieCatalogV1.UI.Models;

namespace MovieCatalogV1.UI.Controllers
{
    public class MovieAjaxController : Controller
    {
        // GET: MovieAjax
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
        public ActionResult AddActors(int id, List<int> SelectedActorIds)
        {
            var movieRepo = new MovieRepository();

            movieRepo.AddActors(SelectedActorIds, id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult GetActorsInMovie(int id)
        {
            var actorRepo = new ActorRepository();
            var model = actorRepo.GetActorsInMovie(id);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetActorsNotInMovie(int id)
        {
            var actorRepo = new ActorRepository();
            var model = actorRepo.GetActorsNotInMovie(id);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteActor(int id, int ActorID)
        {
            var movieRepo = new MovieRepository();

            movieRepo.RemoveActor(ActorID, id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}