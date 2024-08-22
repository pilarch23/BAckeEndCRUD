using Microsoft.EntityFrameworkCore;
using BackEndCRUD.Models;
using BackEndCRUD.Services.Contract;

namespace BackEndCRUD.Services.Implementation
{
    public class DirectorService : IDirectorService
    {
        private MoviesDbEjemploContext _dbContext;

        public DirectorService(MoviesDbEjemploContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Director>> GetList()
        {
            try
            {
                List<Director> list = new List<Director>();
                list = await _dbContext.Directors.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Director> GetDirector(int idDirector)
        {
            try
            {
                Director? found = new Director();
                found = await _dbContext.Directors
                            .Where(e => e.IdDirector == idDirector).FirstOrDefaultAsync();

                return found;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Director> Add(Director modelo)
        {
            try
            {
                _dbContext.Directors.Add(modelo);
                await _dbContext.SaveChangesAsync();

                return modelo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateDirector(Director modelo)
        {
            try
            {
                _dbContext.Directors.Update(modelo);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteDirector(Director modelo)
        {
            try
            {
                _dbContext.Directors.Remove(modelo);
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