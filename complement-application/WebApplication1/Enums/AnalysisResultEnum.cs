using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Enums;

public enum AnalysisResultEnum
{
    [Display(Name = "Positif")]
    Positive,
    [Display(Name = "Négatif")]
    Negative,
    [Display(Name = "Non contributif")]
    NonContributive
}