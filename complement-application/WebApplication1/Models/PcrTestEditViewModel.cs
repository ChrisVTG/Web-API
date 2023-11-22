using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Enums;

namespace WebApplication1.Models;

public class PcrTestEditViewModel
{
    public int Id { get; set; }
    [Display(Name = "N° d'échantillon")]
    [StringLength(8, ErrorMessage = "Le n° d'échantillon doit faire entre 4 et 8 caractères maximum.", MinimumLength = 4)]
    [Required(ErrorMessage = "Le champ 'N° d'échantillon' est requis.")]
    public string SampleNumber { get; set; }
    public DateTime SamplingDate { get; set; }
    public DateTime? ReceptionDate { get; set; }
    public DateTime? AnalysisDate { get; set; }
    public int? PerformerId { get; set; }
    public AnalysisResultEnum? AnalysisResult { get; set; }
    public string? Comment { get; set; }
    public List<SelectListItem> SliPerformers { get; set; }
}