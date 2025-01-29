using MagnetApi.Models;
using MagnetApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagnetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprzedazController : ControllerBase
    {
        private readonly ISprzedazService _sprzedazService;

        public SprzedazController(ISprzedazService sprzedazService)
            {
            _sprzedazService = sprzedazService;
            }

        /// <summary>
        /// Pobiera wszystkie rekordy sprzedaży dla bieżącej daty.
        /// </summary>
        [HttpGet("dzisiaj")]
        public async Task<ActionResult<List<Sprzedaz>>> GetAllSprzedazAsync()
            {
            var sprzedaz = await _sprzedazService.GetAllSprzedazAsync();
            return Ok(sprzedaz);
            }

        /// <summary>
        /// Pobiera sprzedaż dla określonej daty.
        /// </summary>
        [HttpGet("{data}")]
        public async Task<ActionResult<List<Sprzedaz>>> GetSprzedazByDataAsync(string data)
            {
            var sprzedaz = await _sprzedazService.GetSprzedazByDataAsync(data);
            if (sprzedaz == null || sprzedaz.Count == 0)
                {
                return NotFound("Brak danych sprzedaży dla podanej daty.");
                }
            return Ok(sprzedaz);
            }

        /// <summary>
        /// Dodaje nową sprzedaż na podstawie modelu `Sprzedaz`.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddSprzedazAsync([FromBody] Sprzedaz sprzedaz)
            {
            try
                {
                await _sprzedazService.AddSprzedazAsync(
                    sprzedaz.Id,
                    sprzedaz.Ilosc,
                    sprzedaz.FormaPlatnosci
                );
                return Ok("Sprzedaż została dodana.");
                }
            catch (InvalidOperationException ex)
                {
                return BadRequest(ex.Message);
                }
            }

        /// <summary>
        /// Usuwa sprzedaż na podstawie `id` i aktualizuje stan magazynowy.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSprzedazAsync(int id)
            {
            try
                {
                await _sprzedazService.DeleteSprzedazAsync(id);
                return Ok("Sprzedaż została usunięta.");
                }
            catch (InvalidOperationException ex)
                {
                return NotFound(ex.Message);
                }
            }
        }
}
