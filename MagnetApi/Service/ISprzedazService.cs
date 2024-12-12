using MagnetApi.Models;

namespace MagnetApi.Service
    {
    public interface ISprzedazService
        {
        Task AddSprzedazAsync(int stanId, double ilosc, string formaPlatnosci);
        Task DeleteSprzedazAsync(int id);
        Task<List<Sprzedaz>> GetAllSprzedazAsync();
        }
    }