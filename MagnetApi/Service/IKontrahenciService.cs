using MagnetApi.Models;

namespace MagnetApi.Service
{
    public interface IKontrahenciService
    {
        Task AddKontrahentAsync(Kontrahenci kontrahent);
        Task DeleteKontrahentAsync(int id);
        Task EditKontrahentAsync(int id, Kontrahenci updatedKontrahent);
        Task<IQueryable<Kontrahenci>> SearchKontrahenciAsync(string searchTerm);
    }
}