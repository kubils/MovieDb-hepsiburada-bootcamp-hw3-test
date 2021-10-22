using Microsoft.EntityFrameworkCore;
using MovieDbInf.Domain.Entities;
using MovieDbInf.Domain.Repositories;
using MovieDbInf.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDbInf.Application.Model;

namespace MovieDbInf.Infrastructure.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private DbSet<Movie> _dbSet;
        
        public MovieRepository(MovieDbInfContext movieDbContext) : base(movieDbContext)
        {
            _dbSet = movieDbContext.Set<Movie>();
        }

        public async Task<List<Movie>> GetByDirector(int id)
        {
           return await _dbSet.Where(x => x.DirectorId == id).ToListAsync();

        }

        public List<Movie> GetByParameters(MovieParameters parameters)
        {
            var query = _dbSet.Where(x => x.ReleaseDate < parameters.MaxPublishYear
                                          && x.ReleaseDate >= parameters.MinPublisYear
                                          && (parameters.Title != null ? x.Title.Contains(parameters.Title) : true))
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize).ToList();
            return query;
        }
    }
}
