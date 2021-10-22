using MovieDbInf.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDbInf.Application.Model;

namespace MovieDbInf.Domain.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<List<Movie>> GetByDirector(int id);
        
        List<Movie> GetByParameters(MovieParameters parameters);

    }
}
