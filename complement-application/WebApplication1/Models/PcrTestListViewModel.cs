using WebApplication1.Enums;

namespace WebApplication1.Models;

public class PcrTestListViewModel
{
    public int AnalyzedSamplesCount { get; set; }
    public List<PcrTestListItemViewModel> Items { get; set; }
}

public class PcrTestListItemViewModel
{
    public int Id { get; set; }
    public string SampleNumber { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime SamplingDate { get; set; }
    public DateTime? ReceptionDate { get; set; }
    public DateTime? AnalysisDate { get; set; }
    public string Performer { get; set; }
    public AnalysisResultEnum? AnalysisResult { get; set; }
}