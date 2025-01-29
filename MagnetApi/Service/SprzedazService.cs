using MagnetApi.DB;
using MagnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagnetApi.Service
    {
    public class SprzedazService : ISprzedazService
        {
        private readonly DBConnection _context;

        public SprzedazService(DBConnection context)
            {
            _context = context;
            }

        // Dodaj nową sprzedaż na podstawie danych z tabeli Stan
        public async Task AddSprzedazAsync(int stanId, double ilosc, string formaPlatnosci)
            {
            var stan = await _context.Set<Stan>().FindAsync(stanId);
            if (stan == null) throw new InvalidOperationException("Produkt nie istnieje w tabeli Stan");

            if (stan.Ilosc < ilosc) throw new InvalidOperationException("Brak wystarczającej ilości produktu na stanie");

            var sprzedaz = new Sprzedaz
                {
                Nazwa = stan.Nazwa,
                Cena = ilosc * stan.Cena,
                Ilosc = ilosc,
                Zarobek = ilosc * stan.Zarobek,
                Data = DateTime.Now.ToString("yyyy-MM-dd"),
                Czas = DateTime.Now.ToString("HH:mm:ss"),
                StawkaVat = stan.StawkaVat,
                CenaNetto = stan.CenaNetto,
                FormaPlatnosci = formaPlatnosci,
                DataZakupu = stan.DataZakupu,
                NumerFv = stan.NumerFv,
                KodProduktu = stan.KodProduktu,
                RoznicaVat = stan.RoznicaVat
                };

            _context.Set<Sprzedaz>().Add(sprzedaz);

            // Aktualizuj ilość w tabeli Stan
            stan.Ilosc -= ilosc;

            await _context.SaveChangesAsync();
            }

        // Usuń sprzedaż
        public async Task DeleteSprzedazAsync(int id)
            {
            var sprzedaz = await _context.Set<Sprzedaz>().FindAsync(id);
            if (sprzedaz == null) throw new InvalidOperationException("Sprzedaż nie istnieje");

            // Zwróć ilość do tabeli Stan
            var stan = await _context.Set<Stan>().FirstOrDefaultAsync(s => s.KodProduktu == sprzedaz.KodProduktu);
            if (stan != null)
                {
                stan.Ilosc += sprzedaz.Ilosc;
                }

            _context.Set<Sprzedaz>().Remove(sprzedaz);
            await _context.SaveChangesAsync();
            }

        // Pobierz wszystkie rekordy sprzedaży
        public async Task<List<Sprzedaz>> GetAllSprzedazAsync()
            {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            return await _context.Set<Sprzedaz>().Where(s => s.Data == currentDate).ToListAsync();
            }

        public async Task<List<Sprzedaz>> GetSprzedazByDataAsync(string data)
            {
            return await _context.Set<Sprzedaz>().Where(s => s.Data == data).ToListAsync();
            }
        }

    }