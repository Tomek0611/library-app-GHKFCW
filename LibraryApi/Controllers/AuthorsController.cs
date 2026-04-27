using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthorsController : ControllerBase
{
    private readonly AuthorService _service;
    private static bool IsValidMongoId(string id) =>
        Regex.IsMatch(id, @"^[a-fA-F0-9]{24}$");

    public AuthorsController(AuthorService service) => _service = service;

    /// <summary>Összes szerző lekérése</summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<Author>), 200)]
    public async Task<List<Author>> GetAll() => await _service.GetAllAsync();

    /// <summary>Keresés név vagy nemzetiség alapján</summary>
    /// <param name="name">Keresett név (opcionális)</param>
    /// <param name="nationality">Keresett nemzetiség (opcionális)</param>
    [HttpGet("search")]
    [ProducesResponseType(typeof(List<Author>), 200)]
    public async Task<ActionResult<List<Author>>> Search(
        [FromQuery] string? name,
        [FromQuery] string? nationality)
    {
        var authors = await _service.GetAllAsync();

        var result = authors.Where(a =>
            (string.IsNullOrEmpty(name) || a.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrEmpty(nationality) || a.Nationality.Contains(nationality, StringComparison.OrdinalIgnoreCase))
        ).ToList();

        return Ok(result);
    }

    /// <summary>Egy szerző lekérése ID alapján</summary>
    /// <param name="id">A szerző azonosítója</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Author), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<Author>> GetById(string id)
    {
        if (!IsValidMongoId(id))
            return BadRequest(new { message = "Érvénytelen ID formátum. A MongoDB ID 24 karakteres hex string." });

        var author = await _service.GetByIdAsync(id);
        if (author is null)
            return NotFound(new { message = $"A szerző nem található. ID: {id}" });
        return Ok(author);
    }

    /// <summary>Új szerző létrehozása</summary>
    /// <param name="author">A létrehozandó szerző adatai</param>
    [HttpPost]
    [ProducesResponseType(typeof(Author), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Author>> Create(Author author)
    {
        if (string.IsNullOrWhiteSpace(author.Name))
            return BadRequest(new { message = "A név megadása kötelező." });

        var created = await _service.CreateAsync(author);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>Szerző módosítása</summary>
    /// <param name="id">A szerző azonosítója</param>
    /// <param name="updated">A módosított szerző adatai</param>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(string id, Author updated)
    {
        if (!IsValidMongoId(id))
            return BadRequest(new { message = "Érvénytelen ID formátum. A MongoDB ID 24 karakteres hex string." });

        if (string.IsNullOrWhiteSpace(updated.Name))
            return BadRequest(new { message = "A név megadása kötelező." });

        var existing = await _service.GetByIdAsync(id);
        if (existing is null)
            return NotFound(new { message = $"A szerző nem található. ID: {id}" });

        updated.Id = id;
        await _service.UpdateAsync(id, updated);
        return NoContent();
    }

    /// <summary>Szerző törlése</summary>
    /// <param name="id">A szerző azonosítója</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(string id)
    {
        if (!IsValidMongoId(id))
            return BadRequest(new { message = "Érvénytelen ID formátum. A MongoDB ID 24 karakteres hex string." });

        var existing = await _service.GetByIdAsync(id);
        if (existing is null)
            return NotFound(new { message = $"A szerző nem található. ID: {id}" });

        await _service.DeleteAsync(id);
        return NoContent();
    }
}
