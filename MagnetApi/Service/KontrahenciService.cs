using MagnetApi.DB;
using MagnetApi.Models;
using System;

namespace MagnetApi.Service
{
    public class KontrahenciService : IKontrahenciService
    {
        private readonly DBConnection _context;

        public KontrahenciService(DBConnection context)
        {
            _context = context;
        }

        // Dodawanie nowego kontrahenta
        public async Task AddKontrahentAsync(Kontrahenci kontrahent)
        {
            kontrahent.Skrot = GenerateSkrot(kontrahent.Nip, kontrahent.Nazwa);
            _context.Kontrahencis.Add(kontrahent);
            await _context.SaveChangesAsync();
        }

        // Edytowanie istniejącego kontrahenta
        public async Task EditKontrahentAsync(int id, Kontrahenci updatedKontrahent)
        {
            var kontrahent = await _context.Kontrahencis.FindAsync(id);
            if (kontrahent != null)
            {
                kontrahent.Nazwa = updatedKontrahent.Nazwa;
                kontrahent.Ulica = updatedKontrahent.Ulica;
                kontrahent.Miasto = updatedKontrahent.Miasto;
                kontrahent.Nip = updatedKontrahent.Nip;
                kontrahent.Telefon = updatedKontrahent.Telefon;
                kontrahent.Email = updatedKontrahent.Email;
                kontrahent.OstatniaFv = updatedKontrahent.OstatniaFv;
                kontrahent.Obrot = updatedKontrahent.Obrot;
                kontrahent.Reprezentant = updatedKontrahent.Reprezentant;
                kontrahent.Skrot = GenerateSkrot(updatedKontrahent.Nip, updatedKontrahent.Nazwa);
                kontrahent.Odbiorca = updatedKontrahent.Odbiorca;
                kontrahent.KodPocztowy = updatedKontrahent.KodPocztowy;
                kontrahent.NrDomu = updatedKontrahent.NrDomu;
                kontrahent.Wojewodztwo = updatedKontrahent.Wojewodztwo;
                kontrahent.Powiat = updatedKontrahent.Powiat;
                kontrahent.Gmina = updatedKontrahent.Gmina;

                await _context.SaveChangesAsync();
            }
        }

        // Kasowanie kontrahenta
        public async Task DeleteKontrahentAsync(int id)
        {
            var kontrahent = await _context.Kontrahencis.FindAsync(id);
            if (kontrahent != null)
            {
                _context.Kontrahencis.Remove(kontrahent);
                await _context.SaveChangesAsync();
            }
        }

        // Wyszukiwanie kontrahentów po NIP lub nazwie
        public async Task<IQueryable<Kontrahenci>> SearchKontrahenciAsync(string searchTerm)
        {
            var query = _context.Kontrahencis.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(k => k.Nip.Contains(searchTerm) || k.Nazwa.Contains(searchTerm));
            }

            return query;
        }

        // Generowanie skrótu na podstawie NIP i nazwy
        private string GenerateSkrot(string nip, string nazwa)
        {
            return (nip.Substring(0, 3) + nazwa.Substring(0, 3)).ToUpper(); // Skrot to pierwsze 3 litery NIP i pierwsze 3 litery nazwy
        }
    }
}
