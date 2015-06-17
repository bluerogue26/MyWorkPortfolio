using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCatalogV1.Models.Tables;

namespace MovieCatalogV1.UI.Models
{
    public class MovieEditVM
    {
        public Movie MovieToEdit { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public List<Actor> ActorsInMovie { get; set; }
        public List<SelectListItem> ActorsNotInMovie { get; set; }
        public List<int> SelectedActors { get; set; }
 
        public void CreateGenreList(List<Genre> genres)
        {
            Genres = new List<SelectListItem>();

            foreach (var g in genres)
            {
                Genres.Add(
                    new SelectListItem() { Text=g.GenreName, Value = g.GenreID.ToString()}
                    );
            }
        }

        public void CreateActorsNotInMovieList(List<Actor> actors)
        {
            ActorsNotInMovie = new List<SelectListItem>();

            foreach (var a in actors)
            {
                ActorsNotInMovie.Add(
                    new SelectListItem() {Text=string.Format("{0}, {1}", a.LastName, a.FirstName), Value=a.ActorID.ToString()});
            }
        }
    }
}