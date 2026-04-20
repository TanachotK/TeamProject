using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeamProject.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public Models.FilmModels FilmData { get; set; } = new Models.FilmModels();

    public bool IsSubmitted { get; set; }

    public void OnGet()
{
    // This ensures the "Submitted Data" area is hidden when you first open the page
    IsSubmitted = false;

    // Optional: Initialize the object if you haven't already
    if (FilmData == null)
    {
        FilmData = new Models.FilmModels();
    }
}

     public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            IsSubmitted = false; // Ensure that the submitted data is not displayed if validation fails
            return Page(); // If the form data is not valid, return to the page and display validation errors
        }

        IsSubmitted = true;
        return Page();
    }

}
