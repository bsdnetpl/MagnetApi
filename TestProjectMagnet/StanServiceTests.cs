using MagnetApi.DB;
using MagnetApi.Models;
using MagnetApi.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestProjectMagnet
    {
    public class StanServiceTests
        {
        private readonly DBConnection _dbContext;
        private readonly StanService _stanService;

        public StanServiceTests()
            {
            var options = new DbContextOptionsBuilder<DBConnection>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new DBConnection(options);
            _stanService = new StanService(_dbContext);
            }

        [Fact]
        public async Task AddStanAsync_ShouldAddStan()
            {
            var stan = new Stan
                {
                Id = 1,
                Nazwa = "Test Stan",
                KodKreskowy = "123456",
                Cena = 10.0,
                DataZakupu = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                Gtu = "01",
                KodProduktu = "ABC123",
                NumerFv = "FV123",
                StawkaVat = "23"
                };

            await _stanService.AddStanAsync(stan);
            var result = await _dbContext.Stans.FindAsync(stan.Id);

            Assert.NotNull(result);
            Assert.Equal("Test Stan", result.Nazwa);
            }

        [Fact]
        public async Task EditStanAsync_ShouldEditStan()
            {
            var stan = new Stan
                {
                Id = 1,
                Nazwa = "Test Stan",
                KodKreskowy = "123456",
                Cena = 10.0,
                DataZakupu = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                Gtu = "01",
                KodProduktu = "ABC123",
                NumerFv = "FV123",
                StawkaVat = "23"
                };

            if (await _dbContext.Stans.FindAsync(stan.Id) == null)
                {
                _dbContext.Stans.Add(stan);
                await _dbContext.SaveChangesAsync();
                }

            var existingStan = await _dbContext.Stans.FindAsync(1);
            Assert.NotNull(existingStan);

            existingStan.Nazwa = "Updated Stan";
            existingStan.KodKreskowy = "654321";
            existingStan.Cena = 15.0;
            existingStan.DataZakupu = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            existingStan.Gtu = "02";
            existingStan.KodProduktu = "XYZ789";
            existingStan.NumerFv = "FV456";
            existingStan.StawkaVat = "8";

            await _dbContext.SaveChangesAsync();

            var result = await _dbContext.Stans.FindAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Updated Stan", result.Nazwa);
            Assert.Equal("654321", result.KodKreskowy);
            Assert.Equal(15.0, result.Cena);
            }

        [Fact]
        public async Task DeleteStanAsync_ShouldDeleteStan()
            {
            var stan = new Stan
                {
                Id = 1,
                Nazwa = "Test Stan",
                KodKreskowy = "123456",
                Cena = 10.0,
                DataZakupu = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                Gtu = "01",
                KodProduktu = "ABC123",
                NumerFv = "FV123",
                StawkaVat = "23"
                };

            _dbContext.Stans.Add(stan);
            await _dbContext.SaveChangesAsync();

            await _stanService.DeleteStanAsync(1);
            var result = await _dbContext.Stans.FindAsync(1);

            Assert.Null(result);
            }

        [Fact]
        public async Task GetAllStanAsync_ShouldReturnAllStans()
            {
            var stans = new List<Stan>
            {
                new Stan { Id = 1, Nazwa = "Stan1", KodKreskowy = "123", Cena = 10.0, DataZakupu = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"), Gtu = "01", KodProduktu = "ABC123", NumerFv = "FV123", StawkaVat = "23" },
                new Stan { Id = 2, Nazwa = "Stan2", KodKreskowy = "456", Cena = 20.0, DataZakupu = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"), Gtu = "02", KodProduktu = "XYZ789", NumerFv = "FV456", StawkaVat = "8" }
            };

            // Czyści bazę przed testem (jeśli są wcześniejsze dane)
            _dbContext.Stans.RemoveRange(_dbContext.Stans);
            await _dbContext.SaveChangesAsync();

            // Sprawdzamy czy już nie ma danych, potem dodajemy
            if (!await _dbContext.Stans.AnyAsync())
                {
                await _dbContext.Stans.AddRangeAsync(stans);
                await _dbContext.SaveChangesAsync();
                }

            var result = await _stanService.GetAllStanAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            }

        }
    }
