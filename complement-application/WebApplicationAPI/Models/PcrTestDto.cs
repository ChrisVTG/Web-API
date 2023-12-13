using WebApplicationCommon.Enums;

namespace WebApplicationAPI.Models;

public class PcrTestDto
{
    /// <summary>
    /// Identifiant
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Référence unique
    /// </summary>
    public string SampleNumber { get; set; }
    
    /// <summary>
    /// Date de prélèvement
    /// </summary>
    public DateTime SamplingDate { get; set; }
    
    /// <summary>
    /// Date de réception
    /// </summary>
    public DateTime? ReceptionDate { get; set; }
    
    /// <summary>
    /// Date d'analyse
    /// </summary>
    public DateTime? AnalysisDate { get; set; }
    
    /// <summary>
    /// Identifiant de la personne ayant réalisé l'analyse
    /// </summary>
    public int? PerformerId { get; set; }
    
    /// <summary>
    /// Résultat de l'analyse
    /// </summary>
    public AnalysisResultEnum? AnalysisResult { get; set; }
    
    
    /// <summary>
    /// Commentaire éventuel
    /// </summary>
    public string? Comment { get; set; }
}