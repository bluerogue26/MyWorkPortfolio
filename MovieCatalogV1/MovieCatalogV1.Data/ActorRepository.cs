using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCatalogV1.Models.Queries;
using MovieCatalogV1.Models.Tables;
using Dapper;

namespace MovieCatalogV1.Data
{
    public class ActorRepository
    {
        public List<Actor> GetActorsInMovie(int movieId)
        {
            List<Actor> results = new List<Actor>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("ActorGetInMovie", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MovieID", movieId);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var item = new Actor();
                        item.ActorID = (int)dr["ActorID"];
                        item.FirstName = dr["FirstName"].ToString();
                        item.LastName = dr["LastName"].ToString();

                        if (dr["DateOfBirth"] != DBNull.Value)
                        {
                            item.DateOfBirth = (DateTime)dr["DateOfBirth"];
                        }

                        results.Add(item);
                    }
                }
            }

            return results;
        }

        public List<Actor> GetActorsNotInMovie(int movieId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("MovieID", movieId);

                return cn.Query<Actor>("ActorGetNotInMovie", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
