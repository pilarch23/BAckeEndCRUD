using BackEndCRUD.Models;
namespace BackEndCRUD.Services.Contract
{
    public interface IMovieService
    {
        Task<List<Movie>> GetList();

        Task<Movie> Get(int idMovie);

        Task<Movie> Add(Movie modelo);

        Task<bool> Update(Movie modelo);

        Task<bool> Delete(Movie modelo);
    }
}
