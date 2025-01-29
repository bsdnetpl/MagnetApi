using MagnetApi.Models;

namespace MagnetApi.Service
    {
    public interface IBazaFvService
        {
        Task AddFakturaAsync(BazaFv faktura);
        Task DeleteFakturaAsync(string numer);
        Task<List<BazaFv>> GetAllFakturyAsync();
        Task<BazaFv?> GetFakturaByNumerAsync(string numer);
        Task<List<BazaFv>> GetFakturyByYearMonthAsync(int year, int month);
        Task UpdateFakturaAsync(BazaFv faktura);
        }
    }