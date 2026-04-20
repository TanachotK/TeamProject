namespace TeamProject.Models;

using System.ComponentModel.DataAnnotations;

public class FilmModels
{
    [Required(ErrorMessage = "Titel is required")]
    [StringLength(100, MinimumLength = 1)]
    public string Titel { get; set; } = string.Empty;

    [Required(ErrorMessage = "Genre is required")]
    public string Genre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Åldersgräns is required")]
    [Range(0, 18, ErrorMessage = "Åldersgräns must be between 0 and 18")]
    public int Åldersgräns { get; set; }

    [Required(ErrorMessage = "Recension is required")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Recension must be 10–1000 characters")]
    public string Recension { get; set; } = string.Empty;
}

