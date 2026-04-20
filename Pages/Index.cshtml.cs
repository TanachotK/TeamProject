using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeamProject.Pages;

public class IndexModel : PageModel
{
    // Persists across requests for the app's lifetime
    private static List<Models.FilmModels> _submissions = new();

    [BindProperty]
    public Models.FilmModels FilmData { get; set; } = new Models.FilmModels();

    // What the view loops over
    public List<Models.FilmModels> AllSubmissions { get; set; } = new();

    public void OnGet()
    {
        // Feed the list to the view on every GET
        AllSubmissions = _submissions;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            AllSubmissions = _submissions; // Keep list visible if validation fails
            return Page();
        }

        _submissions.Add(FilmData);
        return RedirectToPage(); // Triggers a fresh GET — kills the refresh problem
    }

    public IActionResult OnPostReset()
    {
        _submissions.Clear();
        return RedirectToPage();
    }
}
