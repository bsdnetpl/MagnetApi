using MagnetApi.DB;
using MagnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagnetApi.Service
    {
    public class BazaFvService : IBazaFvService
        {
        private readonly DBConnection _context;

        public BazaFvService(DBConnection context)
            {
            _context = context;
            }

        // Pobierz wszystkie faktury
        public async Task<List<BazaFv>> GetAllFakturyAsync()
            {
            return await _context.Set<BazaFv>().ToListAsync();
            }

        // Pobierz fakturę po numerze
        public async Task<BazaFv?> GetFakturaByNumerAsync(string numer)
            {
            return await _context.Set<BazaFv>().FirstOrDefaultAsync(f => f.Numer == numer);
            }

        // Dodaj nową fakturę
        public async Task AddFakturaAsync(BazaFv faktura)
            {
            await _context.Set<BazaFv>().AddAsync(faktura);
            await _context.SaveChangesAsync();
            }

        // Aktualizuj istniejącą fakturę
        public async Task UpdateFakturaAsync(BazaFv faktura)
            {
            var existingFaktura = await _context.Set<BazaFv>().FirstOrDefaultAsync(f => f.Numer == faktura.Numer);
            if (existingFaktura == null)
                {
                throw new InvalidOperationException("Faktura nie istnieje.");
                }

            // Aktualizujemy wszystkie pola
            _context.Entry(existingFaktura).CurrentValues.SetValues(faktura);
            await _context.SaveChangesAsync();
            }

        // Usuń fakturę
        public async Task DeleteFakturaAsync(string numer)
            {
            var faktura = await _context.Set<BazaFv>().FirstOrDefaultAsync(f => f.Numer == numer);
            if (faktura == null)
                {
                throw new InvalidOperationException("Faktura nie istnieje.");
                }

            _context.Set<BazaFv>().Remove(faktura);
            await _context.SaveChangesAsync();
            }
        public async Task<List<BazaFv>> GetFakturyByYearMonthAsync(int year, int month)
            {
            return await _context.Set<BazaFv>()
                .Where(f => f.Data.StartsWith($"{year}-{month:D2}"))
                .ToListAsync();
            }
        }
    }
