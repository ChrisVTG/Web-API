using System.ComponentModel.DataAnnotations;

namespace WebApplicationCommon.Enums;

public enum AnalysisResultEnum
{
    [Display(Name = "Positif")]
    Positive,
    [Display(Name = "Négatif")]
    Negative,
    [Display(Name = "Non contributif")]
    NonContributive
}