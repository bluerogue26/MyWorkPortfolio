using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCatalogV1.Models.Tables;
using Dapper;

namespace MovieCatalogV1.Data
{
    public class GenreRepository
    {
        public List<Genre> GetAll()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                return cn.Query<Genre>("GenreGetAll", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
