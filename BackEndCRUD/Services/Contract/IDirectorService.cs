using BackEndCRUD.Models;

namespace BackEndCRUD.Services.Contract
{
    public interface IDirectorService
    {
        Task<List<Director>> GetList();
        Task<Director> GetDirector(int idDirector);

        Task<Director> Add(Director modelo);

        Task<bool> UpdateDirector(Director modelo);

        Task<bool> DeleteDirector(Director modelo);
    }
}