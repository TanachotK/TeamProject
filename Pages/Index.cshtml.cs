using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeamProject.Pages;

public class IndexModel : PageModel
{
    public Models.FilmModels FilmData { get; set; } = new Models.FilmModels();

    public void OnGet()
    {

    }

    public void OnPost()
    {
        // Handle form submission, e.g., save to database or process data
        // For now, just leave it as is or add logic here
    }
}
