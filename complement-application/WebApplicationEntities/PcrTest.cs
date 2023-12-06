using WebApplicationCommon.Enums;

namespace WebApplicationEntities;

public class PcrTest
{
    public int Id { get; set; }
    public string SampleNumber { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime SamplingDate { get; set; }
    public DateTime? ReceptionDate { get; set; }
    public DateTime? AnalysisDate { get; set; }
    // public string? Performer { get; set; }
    public int? PerformerId { get; set; }
    public User? Performer { get; set; }
    public AnalysisResultEnum? AnalysisResult { get; set; }
    public string? Comment { get; set; }
}