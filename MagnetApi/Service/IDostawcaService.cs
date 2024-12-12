using MagnetApi.Models;

namespace MagnetApi.Service
    {
    public interface IDostawcaService
        {
        Task AddDostawcaAsync(Dostawca dostawca);
        Task DeleteDostawcaAsync(int id);
        Task EditDostawcaAsync(Dostawca updatedDostawca);
        Task<List<Dostawca>> SearchDostawcaAsync(string? nazwaDostawcy = null, string? nrDostawcy = null);
        }
    }