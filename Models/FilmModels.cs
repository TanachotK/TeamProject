using System.ComponentModel.DataAnnotations;

namespace TeamProject.Models;

public class FilmModels
{
    [Required(ErrorMessage = "Titel är obligatoriskt.")]
    [StringLength(100, ErrorMessage = "Titel får inte vara längre än 100 tecken.")]
    public string? Titel { get; set; }

    [Required(ErrorMessage = "Genre är obligatoriskt.")]
    [StringLength(50, ErrorMessage = "Genre får inte vara längre än 50 tecken.")]
    public string? Genre { get; set; }

    [Required(ErrorMessage = "Åldersgräns är obligatoriskt.")]
    [Range(0, 18, ErrorMessage = "Åldersgräns måste vara mellan 0 och 18.")]
    public string? Åldersgräns { get; set; }

    [StringLength(500, ErrorMessage = "Recension får inte vara längre än 500 tecken.")]
    public string? Recension { get; set; }
}


