using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;

namespace WebApplication17.Controllers;

[Authorize]
public class MoviesController : Controller
{
    private readonly AppDbContext _context;

    public MoviesController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string search, string genre, string sortBy, bool descending = false)
    {
        ViewData["CurrentSearch"] = search;
        ViewData["CurrentGenre"] = genre;
        ViewData["CurrentSort"] = sortBy;
        ViewData["IsDescending"] = descending;

        var query = _context.Movies.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(m => m.Title.Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(genre))
        {
            query = query.Where(m => m.Genre.ToLower() == genre.ToLower());
        }

        query = sortBy?.ToLower() switch
        {
            "title" => descending ? query.OrderByDescending(m => m.Title) : query.OrderBy(m => m.Title),
            "year" => descending ? query.OrderByDescending(m => m.ReleaseYear) : query.OrderBy(m => m.ReleaseYear),
            "rating" => descending ? query.OrderByDescending(m => m.Rating) : query.OrderBy(m => m.Rating),
            _ => query.OrderBy(m => m.Id)
        };

        var movies = await query.ToListAsync();
        return View(movies);
    }

    public async Task<IActionResult> Details(int id)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null)
        {
            return NotFound("Фільм не знайдено.");
        }

        return View(movie);
    }
}