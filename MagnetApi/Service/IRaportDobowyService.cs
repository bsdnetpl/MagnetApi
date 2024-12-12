using MagnetApi.Models;

namespace MagnetApi.Service
    {
    public interface IRaportDobowyService
        {
        Task DeleteRaportDobowyAsync(int id);
        Task GenerateRaportDobowyAsync(string raportujacy, string gotowka);
        Task<List<RaportDobowy>> GetAllRaportyDoboweAsync();
        }
    }