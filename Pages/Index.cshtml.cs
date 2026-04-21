using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamProject.Data;

namespace TeamProject.Pages;

public class IndexModel : PageModel
{
    private readonly FilmRepository _repository;

    public IndexModel(FilmRepository repository)
    {
        _repository = repository;
    }

    [BindProperty]
    public Models.FilmModels FilmData { get; set; } = new();
    public List<Models.FilmModels> Films { get; set; } = new();

    public void OnGet()
    {
        Films = _repository.GetAllFilms();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            Films = _repository.GetAllFilms();
            return Page();
        }

        _repository.AddFilm(FilmData);
        return RedirectToPage();
    }
}
