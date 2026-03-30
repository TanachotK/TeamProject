using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TeamProject.Pages;

public class IndexModel : PageModel
{
    public Models.FilmModels FilmData { get; set; } = new Models.FilmModels();
    public void OnGet()
    {

    }
}
