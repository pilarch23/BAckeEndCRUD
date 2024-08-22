using Microsoft.EntityFrameworkCore;
using BackEndCRUD.Models;
using BackEndCRUD.Services.Contract;

namespace BackEndCRUD.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private MoviesDbEjemploContext _dbContext;

        public MovieService(MoviesDbEjemploContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Movie>> GetList()
        {
            try
            {
                List<Movie> list = new List<Movie>();
                list = await _dbContext.Movies.Include(d => d.DirectorKeyNavigation).ToListAsync();
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Movie> Get(int idMovie)
        {
            try
            {
                Movie? found = new Movie();
                found = await _dbContext.Movies.Include(d => d.DirectorKeyNavigation)
                    .Where(e => e.IdMovies == idMovie).FirstOrDefaultAsync();

                return found;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Movie> Add(Movie modelo)
        {
            try
            {
                _dbContext.Movies.Add(modelo);
                await _dbContext.SaveChangesAsync();

                return modelo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(Movie modelo)
        {
            try
            {
                _dbContext.Movies.Update(modelo);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(Movie modelo)
        {
            try
            {
                _dbContext.Movies.Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
