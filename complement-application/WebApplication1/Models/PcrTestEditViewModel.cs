namespace WebApplication1.Models;

public class PcrTestEditViewModel
{
    public string SampleNumber { get; set; }
    public DateTime SamplingDate { get; set; }
    public DateTime ReceptionDate { get; set; }
    public DateTime AnalysisDate { get; set; }
    public string Performer { get; set; }
    public int AnalysisResult { get; set; }
    public string Comment { get; set; }
}