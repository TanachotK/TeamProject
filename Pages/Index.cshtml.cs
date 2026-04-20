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
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            IsSubmitted = false;
            return Page();
        }

        IsSubmitted = true;
        return Page(); // 
    }

    public IActionResult OnPostReset()
    {
        ModelState.Clear(); // 
        FilmData = new Models.FilmModels();
        IsSubmitted = false;

        return Page(); // 
    }
}