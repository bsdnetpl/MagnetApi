using MagnetApi.DB;
using MagnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagnetApi.Service
    {
    public class WystawcaService
        {
        private readonly DBConnection _context;

        public WystawcaService(DBConnection context)
            {
            _context = context;
            }

        // Dodaj nowy rekord
        public async Task AddWystawcaAsync(Wystawca wystawca)
            {
            if (wystawca == null) throw new ArgumentNullException(nameof(wystawca));
            _context.Set<Wystawca>().Add(wystawca);
            await _context.SaveChangesAsync();
            }

        // Edytuj istniejący rekord
        public async Task EditWystawcaAsync(Wystawca updatedWystawca)
            {
            if (updatedWystawca == null) throw new ArgumentNullException(nameof(updatedWystawca));

            var existingWystawca = await _context.Set<Wystawca>().FindAsync(updatedWystawca.Id);
            if (existingWystawca == null) throw new InvalidOperationException("Wystawca not found");

            _context.Entry(existingWystawca).CurrentValues.SetValues(updatedWystawca);
            await _context.SaveChangesAsync();
            }

        // Usuń rekord
        public async Task DeleteWystawcaAsync(int id)
            {
            var wystawca = await _context.Set<Wystawca>().FindAsync(id);
            if (wystawca == null) throw new InvalidOperationException("Wystawca not found");

            _context.Set<Wystawca>().Remove(wystawca);
            await _context.SaveChangesAsync();
            }

        // Wyszukaj po nazwie, NIP lub numerze konta bankowego
        public async Task<List<Wystawca>> SearchWystawcaAsync(string? nazwa = null, string? nip = null, string? nrKontaBankowego = null)
            {
            var query = _context.Set<Wystawca>().AsQueryable();

            if (!string.IsNullOrEmpty(nazwa))
                {
                query = query.Where(w => EF.Functions.Like(w.Nazwa, $"%{nazwa}%"));
                }

            if (!string.IsNullOrEmpty(nip))
                {
                query = query.Where(w => EF.Functions.Like(w.Nip, $"%{nip}%"));
                }

            if (!string.IsNullOrEmpty(nrKontaBankowego))
                {
                query = query.Where(w => EF.Functions.Like(w.NrKontaBankowego, $"%{nrKontaBankowego}%"));
                }

            return await query.ToListAsync();
            }
        }
    }
