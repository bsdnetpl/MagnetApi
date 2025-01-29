using MagnetApi.Models;
using MagnetApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagnetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BazaFvController : ControllerBase
    {
        private readonly IBazaFvService _bazaFvService;

        public BazaFvController(IBazaFvService bazaFvService)
            {
            _bazaFvService = bazaFvService;
            }

        // Pobierz wszystkie faktury
        [HttpGet]
        public async Task<ActionResult<List<BazaFv>>> GetAllFaktury()
            {
            var faktury = await _bazaFvService.GetAllFakturyAsync();
            return Ok(faktury);
            }

        // Pobierz fakturę po numerze
        [HttpGet("{numer}")]
        public async Task<ActionResult<BazaFv>> GetFakturaByNumer(string numer)
            {
            var faktura = await _bazaFvService.GetFakturaByNumerAsync(numer);
            if (faktura == null)
                {
                return NotFound("Faktura nie istnieje.");
                }
            return Ok(faktura);
            }

        // Dodaj nową fakturę
        [HttpPost]
        public async Task<ActionResult> AddFaktura([FromBody] BazaFv faktura)
            {
            try
                {
                await _bazaFvService.AddFakturaAsync(faktura);
                return Ok("Faktura została dodana.");
                }
            catch (Exception ex)
                {
                return BadRequest(ex.Message);
                }
            }

        // Aktualizuj fakturę
        [HttpPut("{numer}")]
        public async Task<ActionResult> UpdateFaktura(string numer, [FromBody] BazaFv faktura)
            {
            if (numer != faktura.Numer)
                {
                return BadRequest("Numer faktury w URL i w obiekcie muszą być takie same.");
                }

            try
                {
                await _bazaFvService.UpdateFakturaAsync(faktura);
                return Ok("Faktura została zaktualizowana.");
                }
            catch (InvalidOperationException ex)
                {
                return NotFound(ex.Message);
                }
            }

        // Usuń fakturę
        [HttpDelete("{numer}")]
        public async Task<ActionResult> DeleteFaktura(string numer)
            {
            try
                {
                await _bazaFvService.DeleteFakturaAsync(numer);
                return Ok("Faktura została usunięta.");
                }
            catch (InvalidOperationException ex)
                {
                return NotFound(ex.Message);
                }
            }
        [HttpGet("rok-miesiac/{year}/{month}")]
        public async Task<ActionResult<List<BazaFv>>> GetFakturyByYearMonth(int year, int month)
            {
            var faktury = await _bazaFvService.GetFakturyByYearMonthAsync(year, month);
            if (faktury == null || faktury.Count == 0)
                {
                return NotFound("Brak faktur dla podanego roku i miesiąca.");
                }
            return Ok(faktury);
            }
        }
}
