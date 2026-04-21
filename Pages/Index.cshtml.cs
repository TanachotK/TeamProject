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
}

     public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            IsSubmitted = false; // Ensure that the submitted data is not displayed if validation fails
            return; // If the form data is not valid, return to the page and display validation errors
        }
        IsSubmitted = true;
    
        // Handle form submission, e.g., save to database or process data
        // For now, just leave it as is or add logic here
    }

    public void OnPostReset()
    {
        FilmData = new Models.FilmModels(); // Reset the form data
        IsSubmitted = false; // Hide the submitted data
    }
}
