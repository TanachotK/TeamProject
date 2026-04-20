using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeamProject.Pages;

public class IndexModel : PageModel
{
<<<<<<< HEAD
    // Persists across requests for the app's lifetime
    private static List<Models.FilmModels> _submissions = new();

=======
>>>>>>> main
    [BindProperty]
    public Models.FilmModels FilmData { get; set; } = new Models.FilmModels();
    public bool IsSubmitted { get; set; }

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
<<<<<<< HEAD
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
=======
            IsSubmitted = false; // Ensure that the submitted data is not displayed if validation fails
            return; // If the form data is not valid, return to the page and display validation errors
        }
        IsSubmitted = true;
    
        // Handle form submission, e.g., save to database or process data
        // For now, just leave it as is or add logic here
>>>>>>> main
    }

    public void OnPostReset()
    {
        FilmData = new Models.FilmModels(); // Reset the form data
        IsSubmitted = false; // Hide the submitted data
    }
    
}
