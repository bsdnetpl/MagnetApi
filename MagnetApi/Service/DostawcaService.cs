using MagnetApi.DB;
using MagnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagnetApi.Service
    {
    public class DostawcaService : IDostawcaService
        {
        private readonly DBConnection _context;

        public DostawcaService(DBConnection context)
            {
            _context = context;
            }

        // Dodaj nowy rekord
        public async Task AddDostawcaAsync(Dostawca dostawca)
            {
            if (dostawca == null) throw new ArgumentNullException(nameof(dostawca));
            _context.Set<Dostawca>().Add(dostawca);
            await _context.SaveChangesAsync();
            }

        // Edytuj istniejący rekord
        public async Task EditDostawcaAsync(Dostawca updatedDostawca)
            {
            if (updatedDostawca == null) throw new ArgumentNullException(nameof(updatedDostawca));

            var existingDostawca = await _context.Set<Dostawca>().FindAsync(updatedDostawca.Id);
            if (existingDostawca == null) throw new InvalidOperationException("Dostawca not found");

            _context.Entry(existingDostawca).CurrentValues.SetValues(updatedDostawca);
            await _context.SaveChangesAsync();
            }

        // Usuń rekord
        public async Task DeleteDostawcaAsync(int id)
            {
            var dostawca = await _context.Set<Dostawca>().FindAsync(id);
            if (dostawca == null) throw new InvalidOperationException("Dostawca not found");

            _context.Set<Dostawca>().Remove(dostawca);
            await _context.SaveChangesAsync();
            }

        // Wyszukaj po nazwie lub numerze dostawcy (NIP)
        public async Task<List<Dostawca>> SearchDostawcaAsync(string? nazwaDostawcy = null, string? nrDostawcy = null)
            {
            var query = _context.Set<Dostawca>().AsQueryable();

            if (!string.IsNullOrEmpty(nazwaDostawcy))
                {
                query = query.Where(d => EF.Functions.Like(d.NazwaDostawcy, $"%{nazwaDostawcy}%"));
                }

            if (!string.IsNullOrEmpty(nrDostawcy))
                {
                query = query.Where(d => EF.Functions.Like(d.NrDostawcy, $"%{nrDostawcy}%"));
                }

            return await query.ToListAsync();
            }
        }
    }
