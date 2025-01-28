using MagnetApi.Models;
using MagnetApi.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagnetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigins")] // Nazwa polityki CORS
    public class StanController : ControllerBase
    {
        private readonly IStanService _stanService;

        public StanController(IStanService stanService)
            {
            _stanService = stanService;
            }

        // Dodaj nowy rekord
        [HttpPost]
        public async Task<IActionResult> AddStan([FromBody] Stan stan)
            {
            if (stan == null)
                {
                return BadRequest("Stan cannot be null.");
                }

            await _stanService.AddStanAsync(stan);
            return CreatedAtAction(nameof(GetStanById), new { id = stan.Id }, stan);
            }

        // Pobierz rekord po ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStanById(int id)
            {
            var stan = await _stanService.SearchStanAsync(null, null, null);
            var result = stan.FirstOrDefault(s => s.Id == id);

            if (result == null)
                {
                return NotFound("Stan not found.");
                }

            return Ok(result);
            }

        // Edytuj istniejący rekord
        [HttpPut("{id}")]
        public async Task<IActionResult> EditStan(int id, [FromBody] Stan updatedStan)
            {
            if (updatedStan == null || updatedStan.Id != id)
                {
                return BadRequest("Invalid Stan data.");
                }

            try
                {
                await _stanService.EditStanAsync(updatedStan);
                return NoContent();
                }
            catch (InvalidOperationException ex)
                {
                return NotFound(ex.Message);
                }
            }

        // Usuń rekord
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStan(int id)
            {
            try
                {
                await _stanService.DeleteStanAsync(id);
                return NoContent();
                }
            catch (InvalidOperationException ex)
                {
                return NotFound(ex.Message);
                }
            }

        // Wyszukaj rekordy
        [HttpGet("search")]
        public async Task<IActionResult> SearchStan(
            [FromQuery] string? nazwa = null,
            [FromQuery] string? kodKreskowy = null,
            [FromQuery] double? cena = null)
            {
            var result = await _stanService.SearchStanAsync(nazwa, kodKreskowy, cena);
            return Ok(result);
            }

        [HttpGet]
        public async Task<IActionResult> GetAllStan()
            {
            var result = await _stanService.GetAllStanAsync();
            return Ok(result);
            }

        }
}
