using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MovieCatalogV1.Models.Queries;
using MovieCatalogV1.Models.Tables;
using Dapper;

namespace MovieCatalogV1.Data
{
    public class MovieRepository
    {
        public List<MovieListItem> GetMovieList()
        {
            List<MovieListItem> results = new List<MovieListItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("MovieGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var item = new MovieListItem();
                        item.MovieID = (int)dr["MovieID"];
                        item.GenreID = (int)dr["GenreID"];
                        item.Title = dr["Title"].ToString();
                        item.GenreName = dr["GenreName"].ToString();

                        if (dr["ReleaseYear"] != DBNull.Value)
                        {
                            item.ReleaseYear = (int)dr["ReleaseYear"];
                        }

                        results.Add(item);
                    }
                }
            }

            return results;
        }

        public Movie Get(int movieId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("MovieID", movieId);

                return cn.Query<Movie>("MovieGet", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void Update(Movie movie)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("MovieUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MovieID", movie.MovieID);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@GenreID", movie.GenreID);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveActor(int actorID, int movieID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("ActorID", actorID);
                p.Add("MovieID", movieID);

                cn.Execute("MovieDeleteActor", p, commandType: CommandType.StoredProcedure);
            }
        }


        public void AddActors(List<int> actorIds, int movieId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var actorId in actorIds)
                    {
                        var p = new DynamicParameters();
                        p.Add("ActorID", actorId);
                        p.Add("MovieID", movieId);

                        cn.Execute("MovieInsertActor", p, commandType: CommandType.StoredProcedure);
                    }

                    scope.Complete();
                }
            }
        }
    }
}

