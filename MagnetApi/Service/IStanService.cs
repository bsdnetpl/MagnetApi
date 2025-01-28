using MagnetApi.Models;

namespace MagnetApi.Service
    {
    public interface IStanService
        {
        Task AddStanAsync(Stan stan);
        Task DeleteStanAsync(int id);
        Task EditStanAsync(Stan updatedStan);
        Task<List<Stan>> GetAllStanAsync();
        Task<List<Stan>> SearchStanAsync(string? nazwa = null, string? kodKreskowy = null, double? cena = null);
        }
    }