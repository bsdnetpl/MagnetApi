using MagnetApi.Models;
using MagnetApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagnetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DostawcaController : ControllerBase
    {
        private readonly IDostawcaService _dostawcaService;

        public DostawcaController(IDostawcaService dostawcaService)
            {
            _dostawcaService = dostawcaService;
            }

        // Dodaj nowego dostawcę
        [HttpPost]
        public async Task<IActionResult> AddDostawca([FromBody] Dostawca dostawca)
            {
            if (dostawca == null)
                return BadRequest("Niepoprawne dane dostawcy.");

            await _dostawcaService.AddDostawcaAsync(dostawca);
            return CreatedAtAction(nameof(GetDostawca), new { id = dostawca.Id }, dostawca);
            }

        // Pobierz dostawcę po ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDostawca(int id)
            {
            var dostawca = await _dostawcaService.SearchDostawcaAsync(null, id.ToString());
            if (dostawca == null || dostawca.Count == 0)
                return NotFound("Dostawca nie znaleziony.");

            return Ok(dostawca);
            }

        // Edytuj dostawcę
        [HttpPut]
        public async Task<IActionResult> EditDostawca([FromBody] Dostawca dostawca)
            {
            if (dostawca == null)
                return BadRequest("Niepoprawne dane dostawcy.");

            try
                {
                await _dostawcaService.EditDostawcaAsync(dostawca);
                return NoContent();
                }
            catch (InvalidOperationException ex)
                {
                return NotFound(ex.Message);
                }
            }

        // Usuń dostawcę
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDostawca(int id)
            {
            try
                {
                await _dostawcaService.DeleteDostawcaAsync(id);
                return NoContent();
                }
            catch (InvalidOperationException ex)
                {
                return NotFound(ex.Message);
                }
            }

        // Wyszukaj dostawcę po nazwie lub numerze
        [HttpGet("search")]
        public async Task<IActionResult> SearchDostawca([FromQuery] string? nazwa, [FromQuery] string? nr)
            {
            var dostawcy = await _dostawcaService.SearchDostawcaAsync(nazwa, nr);
            return Ok(dostawcy);
            }
        }
}
