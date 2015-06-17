using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogV1.Models.Tables
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public int GenreID { get; set; }       
    }
}
