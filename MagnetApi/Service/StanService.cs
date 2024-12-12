using MagnetApi.DB;
using MagnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagnetApi.Service
    {
    public class StanService : IStanService
        {
        private readonly DBConnection _context;

        public StanService(DBConnection context)
            {
            _context = context;
            }

        // Dodaj nowy rekord
        public async Task AddStanAsync(Stan stan)
            {
            if (stan == null) throw new ArgumentNullException(nameof(stan));
            _context.Set<Stan>().Add(stan);
            await _context.SaveChangesAsync();
            }

        // Edytuj istniejący rekord
        public async Task EditStanAsync(Stan updatedStan)
            {
            if (updatedStan == null) throw new ArgumentNullException(nameof(updatedStan));

            var existingStan = await _context.Set<Stan>().FindAsync(updatedStan.Id);
            if (existingStan == null) throw new InvalidOperationException("Stan not found");

            _context.Entry(existingStan).CurrentValues.SetValues(updatedStan);
            await _context.SaveChangesAsync();
            }

        // Usuń rekord
        public async Task DeleteStanAsync(int id)
            {
            var stan = await _context.Set<Stan>().FindAsync(id);
            if (stan == null) throw new InvalidOperationException("Stan not found");

            _context.Set<Stan>().Remove(stan);
            await _context.SaveChangesAsync();
            }

        // Wyszukaj po nazwie, kodzie kreskowym lub cenie
        public async Task<List<Stan>> SearchStanAsync(string? nazwa = null, string? kodKreskowy = null, double? cena = null)
            {
            var query = _context.Set<Stan>().AsQueryable();

            if (!string.IsNullOrEmpty(nazwa))
                {
                query = query.Where(s => EF.Functions.Like(s.Nazwa, $"%{nazwa}%"));
                }

            if (!string.IsNullOrEmpty(kodKreskowy))
                {
                query = query.Where(s => EF.Functions.Like(s.KodKreskowy, $"%{kodKreskowy}%"));
                }

            if (cena.HasValue)
                {
                query = query.Where(s => s.Cena == cena.Value);
                }

            return await query.ToListAsync();
            }
        }
    }
