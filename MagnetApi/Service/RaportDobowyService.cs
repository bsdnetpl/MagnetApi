using MagnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagnetApi.Service
    {
    public class RaportDobowyService : IRaportDobowyService
        {
        private readonly DbContext _context;

        public RaportDobowyService(DbContext context)
            {
            _context = context;
            }

        // Tworzenie raportu dobowego na podstawie tabeli Sprzedaz
        public async Task GenerateRaportDobowyAsync(string raportujacy, string gotowka)
            {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string currentTime = DateTime.Now.ToString("HH:mm:ss");

            var sprzedaze = await _context.Set<Sprzedaz>().Where(s => s.Data == currentDate).ToListAsync();

            if (!sprzedaze.Any()) throw new InvalidOperationException("Brak danych sprzedaży na aktualny dzień.");

            var raport = new RaportDobowy
                {
                Data = currentDate,
                Godzina = currentTime,
                Raportujacy = raportujacy,
                Gotowka = gotowka,
                Zysk = sprzedaze.Sum(s => s.Zarobek),
                UtargBrutto = sprzedaze.Sum(s => s.Cena * s.Ilosc),
                RoznicaVat = sprzedaze.Sum(s => s.RoznicaVat),
                Sva = sprzedaze.Where(s => s.StawkaVat == "A").Sum(s => (float)s.Ilosc),
                Svb = sprzedaze.Where(s => s.StawkaVat == "B").Sum(s => (float)s.Ilosc),
                Svc = sprzedaze.Where(s => s.StawkaVat == "C").Sum(s => (float)s.Ilosc),
                Svd = sprzedaze.Where(s => s.StawkaVat == "D").Sum(s => (float)s.Ilosc),
                Sve = sprzedaze.Where(s => s.StawkaVat == "E").Sum(s => (float)s.Ilosc),
                Svf = sprzedaze.Where(s => s.StawkaVat == "F").Sum(s => (float)s.Ilosc),
                Svg = sprzedaze.Where(s => s.StawkaVat == "G").Sum(s => (float)s.Ilosc)
                };

            _context.Set<RaportDobowy>().Add(raport);
            await _context.SaveChangesAsync();
            }

        // Usuń raport dobowy
        public async Task DeleteRaportDobowyAsync(int id)
            {
            var raport = await _context.Set<RaportDobowy>().FindAsync(id);
            if (raport == null) throw new InvalidOperationException("Raport nie istnieje");

            _context.Set<RaportDobowy>().Remove(raport);
            await _context.SaveChangesAsync();
            }

        // Pobierz wszystkie raporty dobowe
        public async Task<List<RaportDobowy>> GetAllRaportyDoboweAsync()
            {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            return await _context.Set<RaportDobowy>()
                .Where(r => DateTime.Parse(r.Data).Year == currentYear && DateTime.Parse(r.Data).Month == currentMonth)
              .ToListAsync();
            }
        }
    }
